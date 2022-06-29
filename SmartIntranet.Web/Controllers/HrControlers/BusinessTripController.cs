using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.BusinessTripDto;
using SmartIntranet.DTO.DTOs.CauseDto;
using SmartIntranet.DTO.DTOs.ClauseDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.NonWorkingDayDto;
using SmartIntranet.DTO.DTOs.PlaceDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class BusinessTripController : BaseIdentityController
    {
        private readonly IBusinessTripService _businessTripService;
        private readonly ICompanyService _companyService;
        private readonly ICauseService _causeService;
        private readonly IAppUserService _userService;
        private readonly IClauseService _clauseService;
        private readonly IBusinessTripFileService _businessTripFileService;
        private readonly IPlaceService _placeService;
        private readonly IntranetContext _db;
        private readonly IAppUserService _appUserService;
        public BusinessTripController(UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IMapper mapper, IBusinessTripService businessTripService,
            ICompanyService companyService, ICauseService causeService,
            IAppUserService userService, IClauseService clauseService,
            IBusinessTripFileService businessTripFileService, IPlaceService placeService,
            IntranetContext db, IAppUserService appUserService) 
            : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _businessTripService = businessTripService;
            _companyService = companyService;
            _causeService = causeService;
            _userService = userService;
            _clauseService = clauseService;
            _businessTripFileService = businessTripFileService;
            _placeService = placeService;
            _db = db;
            _appUserService = appUserService;
        }

        [HttpGet]
        [Authorize(Policy = "businessTrip.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.causes = _map.Map<ICollection<CauseListDto>>(await _causeService.GetAllAsync(x => !x.IsDeleted));
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "businessTrip.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BusinessTripAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var current = GetSignInUserId();
                model.CreatedByUserId = current;
                model.CreatedDate = DateTime.UtcNow;
                model.IsDeleted = false;

                var result_model = _map.Map<BusinessTrip>(model);
                foreach (var item in result_model.BusinessTripUsers)
                {
                    item.IsDeleted = false;
                }
                result_model.CreatedDate = DateTime.UtcNow;
                result_model = _businessTripService.AddReturnEntityAsync(result_model).Result;
                List<BusinessTripUser> businessTripUsers = result_model.BusinessTripUsers.ToList();
                List<IntranetUser> users = new List<IntranetUser>();
                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

                formatKeys.Add("commandDate", model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", model.CommandNumber);
                for (int i = 0; i < businessTripUsers.Count; i++)
                {
                    users.Add(await _userService.FindByUserAllInc(businessTripUsers[i].UserId));
                    formatKeys.Add($"startDate_{i}", businessTripUsers[i].StartDate.ToString("dd.MM.yyyy"));
                    formatKeys.Add($"dayCount_{i}", (businessTripUsers[i].EndDate - businessTripUsers[i].StartDate).TotalDays.ToString());
                    formatKeys.Add($"place_{i}", (await _placeService.FindByIdAsync(businessTripUsers[i].PlaceId)).Name);
                    formatKeys.Add($"companyName_{i}", (await _companyService.FindByIdAsync((int)users[0].CompanyId)).Name);
                }

                for (int i = 0; i < users.Count; i++)
                {
                    formatKeys.Add($"employeeFull_{i}", $"{users[i].Surname} {users[i].Name} {users[i].Fathername} {(users[i].Gender == "MALE" ? "oğlu" : users[i].Gender == "FEMALE" ? "qızı" : "")}");
                    formatKeys.Add($"position_{i}", users[i].Position.Name);
                }
                var company = await _companyService.FindByIdAsync((int)users[0].CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                formatKeys.Add("cause", (await _causeService.FindByIdAsync(result_model.CauseId)).Name);
                formatKeys = PdfStaticKeys(formatKeys, users[0], company, company_director);

                var clause = ContractFileReadyConst.business_trip_command;
                var file = new BusinessTripFile();
                file.BusinessTripId = result_model.Id;
                file.IsDeleted = false;
                file.CreatedDate = DateTime.UtcNow;
                var clause_result = (await _clauseService.GetAllIncCompAsync(x => x.Key == clause && !x.IsDeleted))[0];
                file.ClauseId = clause_result.Id;
                StringBuilder content = await GetDocxContent(clause_result.FilePath, formatKeys);
                file.FilePath = await AddContractFile(clause_result.FilePath, PdfFormatKeys(formatKeys, content, businessTripUsers.Count));
                file.CreatedDate= DateTime.UtcNow;
                await _businessTripFileService.AddAsync(file);
                return RedirectToAction("List", "Contract");
            }
        }

        [HttpGet]
        [Authorize(Policy = "businessTrip.update")]
        public async Task<IActionResult> Update(int id)
        {
            var listModel = _map.Map<BusinessTripUpdateDto>(await _businessTripService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }
            ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.causes = _map.Map<ICollection<CauseListDto>>(await _causeService.GetAllAsync(x => x.IsDeleted  == false));
            ViewBag.users = _map.Map<ICollection<AppUserListDto>>(await _appUserService.GetAllIncludeAsync(x => !x.IsDeleted && x.Email != "tahiroglumahir@gmail.com"));
            ViewBag.places =_map.Map<ICollection<PlaceListDto>>(await _placeService.GetAllIncAsync(x => !x.IsDeleted));
            ViewBag.contractFiles = await _businessTripFileService.GetAllIncAsync(x => x.BusinessTripId == id && !x.IsDeleted);
            listModel.BusinessTripUsers = await _db.BusinessTripUsers.Where(x => x.BusinessTripId == listModel.Id).ToListAsync();
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "businessTrip.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BusinessTripUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List");
            }
            else
            {
                var current = GetSignInUserId();

                model.UpdateDate = DateTime.UtcNow;
                model.UpdateByUserId = current;

                IEnumerable<BusinessTripUser> businessTripUsersDb = _db.BusinessTripUsers.Where(x => x.BusinessTripId == model.Id);
                _db.BusinessTripUsers.RemoveRange(businessTripUsersDb);
                _db.SaveChanges();

                await _businessTripService.UpdateAsync(_map.Map<BusinessTrip>(model));

                List<BusinessTripUser> businessTripUsers = model.BusinessTripUsers.ToList();
                List<IntranetUser> users = new List<IntranetUser>();
                Dictionary<string, string> formatKeys = new Dictionary<string, string>();

                formatKeys.Add("commandDate", model.CommandDate.ToString("dd.MM.yyyy"));
                formatKeys.Add("commandNumber", model.CommandNumber);
                for (int i = 0; i < businessTripUsers.Count; i++)
                {
                    users.Add(await _userService.FindByUserAllInc(businessTripUsers[i].UserId));
                    formatKeys.Add($"startDate_{i}", businessTripUsers[i].StartDate.ToString("dd.MM.yyyy"));
                    formatKeys.Add($"dayCount_{i}", (businessTripUsers[i].EndDate - businessTripUsers[i].StartDate).TotalDays.ToString());
                    formatKeys.Add($"place_{i}", (await _placeService.FindByIdAsync(businessTripUsers[i].PlaceId)).Name);
                    formatKeys.Add($"companyName_{i}", (await _companyService.FindByIdAsync((int)users[0].CompanyId)).Name);
                }

                for (int i = 0; i < users.Count; i++)
                {
                    formatKeys.Add($"employeeFull_{i}", $"{users[i].Surname} {users[i].Name} {users[i].Fathername} {(users[i].Gender == "MALE" ? "oğlu" : users[i].Gender == "FEMALE" ? "qızı" : "")}");
                    formatKeys.Add($"position_{i}", users[i].Position.Name);
                }
                var company = await _companyService.FindByIdAsync((int)users[0].CompanyId);
                var company_director = await _userManager.FindByIdAsync(company.LeaderId.ToString());

                formatKeys.Add("cause", (await _causeService.FindByIdAsync(model.CauseId)).Name);
                formatKeys = PdfStaticKeys(formatKeys, users[0], company, company_director);

                var contract_files = await _businessTripFileService.GetAllIncAsync(x => x.BusinessTripId == model.Id && !x.IsDeleted);
                foreach (var el in contract_files)
                {
                    var clause = _clauseService.GetAllIncCompAsync(x => x.Id == el.ClauseId && !x.IsDeleted).Result[0];
                    DeleteFile("wwwroot/contractDocs/", el.FilePath);
                    StringBuilder content = await GetDocxContent(el.Clause.FilePath, formatKeys);
                    el.FilePath = await AddContractFile(el.Clause.FilePath, PdfFormatKeys(formatKeys, content, businessTripUsers.Count));
                    await _businessTripFileService.UpdateAsync(el);
                }

                return RedirectToAction("List", "Contract");
            }
        }

        [Authorize(Policy = "businessTrip.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _map.Map<BusinessTripListDto>(await _businessTripService.FindByIdAsync(id));
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow;
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            await _businessTripService.UpdateAsync(_map.Map<BusinessTrip>(transactionModel));
            return Ok();
        }
    }
}
