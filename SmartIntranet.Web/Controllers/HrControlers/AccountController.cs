using AutoMapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.GradeDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.DTO.DTOs.UserContractDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Business.Provider;
using SmartIntranet.Business.Extension;

namespace SmartIntranet.Web.Controllers
{
    public class AccountController : BaseIdentityController
    {
        private readonly IConfiguration _configuration;
        private readonly IntranetContext _db;
        private readonly IAppUserService _appUserService;
        private readonly IWorkGraphicService _workGraphicService;
        private readonly IAppRoleService _appRoleService;
        private readonly IUserVacationRemainService _userVacationRemains;
        private readonly Business.Interfaces.Membership.IUserContractService _userContractService;
        private readonly ICompanyService _companyService;
        private readonly IGradeService _gradeService;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionService _positionService;
        private IPasswordHasher<IntranetUser> _passwordHasher;
        public AccountController(IntranetContext db, IAppRoleService appRoleService, IUserVacationRemainService userVacationRemains, Business.Interfaces.Membership.IUserContractService userContractService, UserManager<IntranetUser> userManager,
            IGradeService gradeService, IWorkGraphicService workGraphicService, IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager,
            IMapper mapper, IPasswordHasher<IntranetUser> passwordHasher, IAppUserService appUserService,
            IConfiguration configuration, ICompanyService companyService, IDepartmentService departmentService,
            IPositionService positionService) : base(userManager, httpContextAccessor, signInManager, mapper)
        {
            _appRoleService = appRoleService;
            _workGraphicService = workGraphicService;
            _userVacationRemains = userVacationRemains;
            _db = db;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _appUserService = appUserService;
            _userContractService = userContractService;
            _gradeService = gradeService;
            _companyService = companyService;
            _departmentService = departmentService;
            _positionService = positionService;
        }

        [HttpGet]
        [Authorize(Policy = "account.list")]
        public async Task<IActionResult> List()
        {
            return View(_map.Map<ICollection<AppUserListDto>>(await _appUserService.GetAllIncludeAsync(x => x.Email != "tahiroglumahir@gmail.com" && !x.IsDeleted)).OrderByDescending(x => x.UpdateDate > x.CreatedDate ? x.UpdateDate : x.CreatedDate).ToList());
        }

        [HttpGet]
        [Authorize(Policy = "account.permission")]
        public async Task<IActionResult> Permission(int id)
        {
            var user = await _appUserService.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var vm = new AppUserClaimsDto
            {
                User = user
            };



            vm.Roles = await (from r in _db.Roles
                              join ur in _db.UserRoles.Where(_ => _.UserId == user.Id) on r.Id equals ur.RoleId into ljUr
                              from jUr in ljUr.DefaultIfEmpty()
                              select Tuple.Create(r, jUr != null)).ToListAsync();

            vm.Claims = (from p in AppClaimProvider.policies
                         join uc in _db.UserClaims.Where(_ => _.UserId == user.Id && _.ClaimValue.Equals("1")) on p equals uc.ClaimType into ljUc
                         from jUc in ljUc.DefaultIfEmpty()
                         select Tuple.Create(p, jUc != null)).ToList();


            return View(vm);
        }

        [Authorize(Policy = "account.role")]
        public async Task<IActionResult> Role(int id)
        {

            var user = await _appUserService.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var vm = new AppUserClaimsDto
            {
                User = user
            };

            vm.Roles = (from r in _db.Roles
                        join ur in _db.UserRoles.Where(_ => _.UserId == user.Id) on r.Id equals ur.RoleId into ljUr
                        from jUr in ljUr.DefaultIfEmpty()
                        select Tuple.Create(r, jUr != null)).ToList();






            return View(vm);
        }


        [HttpGet]
        [Authorize(Policy = "account.newPassword")]
        public async Task<IActionResult> NewPassword(int id)
        {

            var listModel = _map.Map<AppUserPassDto>(await _appUserService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }


        [HttpPost]
        [Authorize(Policy = "account.newPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewPassword(AppUserPassDto appUserPass)
        {
            if (ModelState.IsValid)
            {
                var updateUser = _userManager.Users.FirstOrDefault(I => I.Id == appUserPass.Id);
                if (!string.IsNullOrEmpty(appUserPass.Password))
                    updateUser.PasswordHash = _passwordHasher.HashPassword(updateUser, appUserPass.Password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                IdentityResult result = await _userManager.UpdateAsync(updateUser);
                return RedirectToAction("List");
            }
            else
            {
                TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("List");
            }

        }

        [HttpGet]
        [Authorize(Policy = "account.add")]
        public async Task<IActionResult> Add()
        {
            var levels = new List<LevelType>();
            levels.Add(new LevelType() { Id = EducationLevelConstant.GENERAL_SECONDARY, Name = "Ümumi orta" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.BACHELORS, Name = "Bakalavr" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.MASTER, Name = "Magistratura" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.VOCATIONAL, Name = "Orta ixtisas" });

            ViewBag.educationLevels = levels;

            var idCardTypes = new List<LevelType>();
            idCardTypes.Add(new LevelType() { Id = IdCardTypeConstant.NATIVE, Name = "Şəxsiyyət vəsiqəsi" });
            idCardTypes.Add(new LevelType() { Id = IdCardTypeConstant.DYI, Name = "Daimi yaşayış icazəsi vəsiqəsi" });
            idCardTypes.Add(new LevelType() { Id = IdCardTypeConstant.MYI, Name = "Müvəqqəti yaşayış icazəsi vəsiqəsi" });

            ViewBag.idCardTypes = idCardTypes;

            ViewBag.grades = _map.Map<ICollection<GradeListDto>>(await _gradeService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);

            return View();
        }

        [HttpPost]
        [Authorize(Policy = "account.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AppUserAddDto user, IFormFile profile)
        {
            if (profile != null)
            {

                if (!MimeTypeCheckExtension.İsImage(profile))
                {
                    TempData["msg"] = " Daxil edilən fayllar image, png və ya gif formatında olmalıdır !";
                    return RedirectToAction("List");
                }
            }


            if (ModelState.IsValid)
            {
                var sendUserEmailExist = await _appUserService.IsExistEmail(user.Email);

                if (sendUserEmailExist)
                {
                    TempData["msg"] = " Daxil edilən email istifadə olunur !";
                    return RedirectToAction("List");
                }

                if (profile != null && profile.FileName != "default.png")
                {
                   // user.Picture = AddResizedImage("wwwroot/profile/", profile);
                }
                var current = GetSignInUserId();
                List<UserVacationRemain> UserVacationRemainsNew = new List<UserVacationRemain>();
                if (user.UserVacationRemains!=null && user.UserVacationRemains.Count() > 0)
                {
                   foreach (var el in user.UserVacationRemains)
                    {
                        el.IsDeleted = false;
                        el.IsEditable = true;
                        el.CreatedByUserId = current;
                        el.CreatedDate = DateTime.Now;
                        el.VacationCount = el.RemainCount;
                        UserVacationRemainsNew.Add(el);
                    }

                }


                var gender = user.Gender == "MALE" ? " oğlu" : "qızı";
                IntranetUser appUser = new IntranetUser
                {
                    UserName = CreateUsername.FixUsername(user.Name + "." + user.Surname),
                    Name = user.Name,
                    Surname = user.Surname,
                    Fathername = user.Fathername,
                    Gender = user.Gender,
                    Fullname = user.Name + " " + user.Surname + " " + user.Fathername + " " + gender,
                    EducationLevel = user.EducationLevel,
                    GraduatedPlace = user.GraduatedPlace,
                    IdCardExpireDate = user.IdCardExpireDate,
                    IdCardGiveDate = user.IdCardGiveDate,
                    IdCardGivePlace = user.IdCardGivePlace,
                    IdCardNumber = user.IdCardNumber,
                    Profession = user.Profession,
                    IdCardType = user.IdCardType,
                    Citizenship = user.Citizenship,
                    RegisterAdress = user.RegisterAdress,
                    Salary = user.Salary,
                    VacationMainDay = user.VacationMainDay,
                    VacationExtraChild = user.VacationExtraChild,
                    VacationExtraExperience = user.VacationExtraExperience,
                    VacationExtraNature = user.VacationExtraNature,
                    CompanyId = user.CompanyId,
                    DepartmentId = user.DepartmentId,
                    WorkGraphicId = user.WorkGraphicId,
                    PositionId = user.PositionId,
                    GradeId = user.GradeId,
                    Email = user.Email,
                    Pin = user.Pin,
                    StartWorkDate = user.StartWorkDate,
                    Birthday = user.Birthday,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    Picture = user.Picture,
                    CreatedByUserId = current,
                    UserExperiences = user.UserExperiences,
                    UserVacationRemains = UserVacationRemainsNew
                };

                var result = await _userManager.CreateAsync(appUser, user.Password);
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.grades = _map.Map<ICollection<GradeListDto>>(await _gradeService.GetAllAsync(x => x.IsDeleted  == false));
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";

                return RedirectToAction("List", user);
            }
        }

        public async Task<IActionResult> GetCompanyTree()
        {
            var tree = DropDownTreeExtensions.BuildTrees(await _companyService
                .GetAllAsync(x => !x.IsDeleted));
            return new JsonResult(tree);
        }
        public async Task<IActionResult> GetDepartmentTree(int companyId)
        {
            var tree = DropDownTreeExtensions.BuildTrees(await _departmentService
                .GetAllAsync(x => x.CompanyId == companyId && !x.IsDeleted));
            return new JsonResult(tree);
        }
        public async Task<IActionResult> GetPositionTree(int departmentId)
        {
            var tree = DropDownTreeExtensions.BuildTrees(await _positionService
                .GetAllAsync(x => x.DepartmentId == departmentId && !x.IsDeleted));
            return new JsonResult(tree);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCompanyUsers(int companyId)
        {
            var usrs = _map.Map<ICollection<AppUserListDto>>(
                await _appUserService.GetAllIncludeAsync(x => !x.IsDeleted && x.CompanyId == companyId))
                .Select(x => new { x.Id, Name = x.Name + " " + x.Surname + "/" + x.Company.Name + "/" + x.Department.Name + "/" + x.Position.Name });
            return Ok(usrs);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserVacationDay(int userId)
        {
            var usr = await _appUserService.FindByUserAllInc(userId);
            double experienceYears = (usr.UserExperiences.Sum(x => (x.ExperienceEnd - x.ExperienceStart).TotalDays) + (DateTime.Now - usr.StartWorkDate).TotalDays) / 365;
            int vacationDay = 0;
            if (experienceYears >= 5 && experienceYears <= 10)
                vacationDay = 2;
            else if (experienceYears > 10 && experienceYears <= 15)
                vacationDay = 4;
            else if (experienceYears > 15)
                vacationDay = 6;
            return Ok(vacationDay);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPositionWithUser(int userId)
        {
            var usr = await _userManager.FindByIdAsync(userId.ToString());
            var position = _map.Map<ICollection<PositionListDto>>(
                await _positionService.GetAllAsync(x => x.IsDeleted  == false && x.DepartmentId == usr.DepartmentId))
                 .Select(x => new { x.Id, x.Name });

            return Ok(position);
        }

        [HttpGet]
        [Authorize(Policy = "account.update")]
        public async Task<IActionResult> Update(int id)
        {
            var model = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted  == false));
            var listModel = _map.Map<AppUserUpdateDto>(await _appUserService.FindByUserAllInc(id));
            if (listModel == null)
            {
                return NotFound();
            }

            DateTime work_start_date = listModel.StartWorkDate;
          
            if (work_start_date != null)
            {
                DateTime start_interval;
                DateTime end_interval;
                if (DateTime.Now.Month > work_start_date.Month || (DateTime.Now.Month == work_start_date.Month && DateTime.Now.Day >= work_start_date.Day))
                {
                    start_interval = new DateTime(DateTime.Now.Year, work_start_date.Month, work_start_date.Day);
                    end_interval = new DateTime(DateTime.Now.Year + 1, work_start_date.Month, work_start_date.Day);
                }
                else
                {
                    start_interval = new DateTime(DateTime.Now.Year - 1, work_start_date.Month, work_start_date.Day);
                    end_interval = new DateTime(DateTime.Now.Year, work_start_date.Month, work_start_date.Day);
                }

                var remains =  _db.UserVacationRemains.Any(x => x.AppUserId == id && x.FromDate == start_interval);

                if (!remains)
                {
                    UserVacationRemain ur = new UserVacationRemain();
                    ur.FromDate = start_interval;
                    ur.ToDate = end_interval;
                    ur.IsDeleted = false;
                    ur.CreatedDate = DateTime.Now;
                    ur.AppUserId = id;
                    ur.UsedCount = 0;
                    ur.VacationCount = listModel.VacationMainDay + listModel.VacationExtraNature + listModel.VacationExtraExperience
                         + listModel.VacationExtraChild; 
                    ur.RemainCount = ur.VacationCount;

                    await _userVacationRemains.AddAsync(ur);
                }

            }

                var levels = new List<LevelType>();
            levels.Add(new LevelType() { Id = EducationLevelConstant.GENERAL_SECONDARY, Name = "Ümumi orta" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.BACHELORS, Name = "Bakalavr" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.MASTER, Name = "Magistratura" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.VOCATIONAL, Name = "Orta ixtisas" });

            ViewBag.educationLevels = levels;

            var idCardTypes = new List<LevelType>();
            idCardTypes.Add(new LevelType() { Id = IdCardTypeConstant.NATIVE, Name = "Şəxsiyyət vəsiqəsi" });
            idCardTypes.Add(new LevelType() { Id = IdCardTypeConstant.DYI, Name = "Daimi yaşayış icazəsi vəsiqəsi" });
            idCardTypes.Add(new LevelType() { Id = IdCardTypeConstant.MYI, Name = "Müvəqqəti yaşayış icazəsi vəsiqəsi" });

            ViewBag.idCardTypes = idCardTypes;

            ViewBag.grades = _map.Map<ICollection<GradeListDto>>(await _gradeService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.docs = _map.Map<ICollection<UserContractListDto>>(await _userContractService.GetContractsByActiveUserIdAsync(id));

            listModel.UserVacationRemains = await _db.UserVacationRemains.Where(x => x.AppUserId == id && x.IsEditable).ToListAsync();
            ViewBag.userVacationDisable = await _db.UserVacationRemains.Where(x => x.AppUserId == id && !x.IsEditable).ToListAsync();

            ViewBag.workGraphics = await _workGraphicService.GetAllAsync(x => !x.IsDeleted);
            return View(listModel);
        }

        [HttpPost]
        [Authorize(Policy = "account.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AppUserUpdateDto model, IFormFile profile, IFormFile pdf)
        {
            ViewBag.userVacationDisable = await _db.UserVacationRemains.Where(x => x.AppUserId == model.Id && !x.IsEditable).ToListAsync();
            if (ModelState.IsValid)
            {
                if (profile != null && profile.FileName != "default.png")
                {
                    if (!MimeTypeCheckExtension.İsImage(profile))
                    {
                        TempData["msg"] = " Daxil edilən Profil rəsmi image, png və ya gif formatında olmalıdır !";
                        return RedirectToAction("List");
                    }

                   // model.Picture = AddResizedImage("wwwroot/profile/", profile);
                }

                else if (profile != null)
                {
                    if (MimeTypeCheckExtension.İsImage(profile))
                    {
                        model.Picture = "logoDefault.png";

                    }
                    else
                    {
                        TempData["msg"] = " Daxil edilən Profil rəsmi image, png və ya gif formatında olmalıdır !";
                        return RedirectToAction("List");
                    }
                }
                else
                {
                    var user = await _appUserService.FindByIdAsync(model.Id);
                    model.Picture = user.Picture;

                }

                var current = GetSignInUserId();
                var updateUser = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                var oldFileImage = updateUser.Picture;

                if (updateUser != null)
                {

                    if (!string.IsNullOrEmpty(model.Email))
                        updateUser.Email = model.Email;
                    else
                        ModelState.AddModelError("", "Email boş ola bilməz !");



                    if (!string.IsNullOrEmpty(model.Email))
                    {
                        var gender = model.Gender == "MALE" ? " oğlu" : "qızı";
                        List<UserExperience> userExperiences = await _db.UserExperiences.Where(x => x.UserId == model.Id).ToListAsync();
                        _db.UserExperiences.RemoveRange(userExperiences);

                        List<UserVacationRemain> userVacRemains = await _db.UserVacationRemains.Where(x => x.AppUserId == model.Id && x.IsEditable).ToListAsync();
                        _db.UserVacationRemains.RemoveRange(userVacRemains);

                        List<UserVacationRemain> userVacRemainsDisable = await _db.UserVacationRemains.Where(x => x.AppUserId == model.Id && !x.IsEditable).ToListAsync();

                        List<UserVacationRemain> UserVacationRemainsNew = new List<UserVacationRemain>();
                        if (model.UserVacationRemains != null && model.UserVacationRemains.Count() > 0)
                        {
                            foreach (var el in model.UserVacationRemains)
                            {
                                el.IsEditable = true;
                                el.IsDeleted = false;
                                el.CreatedByUserId = current;
                                el.CreatedDate = DateTime.Now;
                                el.UpdateByUserId = current;
                                el.UpdateDate = DateTime.Now;
                                el.VacationCount = el.RemainCount;
                                UserVacationRemainsNew.Add(el);
                            }
                        }
                        if (userVacRemainsDisable != null && userVacRemainsDisable.Count() > 0)
                        {
                            foreach (var el in userVacRemainsDisable)
                            {
                                UserVacationRemainsNew.Add(el);
                            }
                        }

                        updateUser.IsDeleted = model.IsDeleted;
                        updateUser.UserName = CreateUsername.FixUsername(model.Name + "." + model.Surname);
                        updateUser.Fathername = model.Fathername;
                        updateUser.Gender = model.Gender;
                        updateUser.Fullname = model.Name + " " + model.Surname + " " + model.Fathername + " " + gender;
                        updateUser.EducationLevel = model.EducationLevel;
                        updateUser.GraduatedPlace = model.GraduatedPlace;
                        updateUser.IdCardExpireDate = model.IdCardExpireDate;
                        updateUser.IdCardGiveDate = model.IdCardGiveDate;
                        updateUser.IdCardGivePlace = model.IdCardGivePlace;
                        updateUser.IdCardNumber = model.IdCardNumber;
                        updateUser.Profession = model.Profession;
                        updateUser.RegisterAdress = model.RegisterAdress;
                        updateUser.VacationMainDay = model.VacationMainDay;
                        updateUser.VacationExtraChild = model.VacationExtraChild;
                        updateUser.VacationExtraExperience = model.VacationExtraExperience;
                        updateUser.VacationExtraNature = model.VacationExtraNature;
                        updateUser.IdCardType = model.IdCardType;
                        updateUser.Citizenship = model.Citizenship;
                        updateUser.CompanyId = model.CompanyId;
                        updateUser.DepartmentId = model.DepartmentId;
                        updateUser.PositionId = model.PositionId;
                        updateUser.GradeId = model.GradeId;
                        updateUser.Name = model.Name;
                        updateUser.Surname = model.Surname;
                        updateUser.Pin = model.Pin;
                        updateUser.StartWorkDate = model.StartWorkDate;
                        updateUser.IsDeleted = model.IsDeleted;
                        updateUser.Birthday = model.Birthday;
                        updateUser.PhoneNumber = model.PhoneNumber;
                        updateUser.Address = model.Address;
                        updateUser.Picture = model.Picture;
                        updateUser.UpdateDate = DateTime.UtcNow.AddHours(4);
                        updateUser.UpdateByUserId = current;
                        updateUser.UserExperiences = model.UserExperiences;
                        updateUser.UserVacationRemains = UserVacationRemainsNew;

                        IdentityResult result = await _userManager.UpdateAsync(updateUser);
                        if (result.Succeeded && oldFileImage != "default.png")
                        {
                            TempData["msg"] = DeleteFile("wwwroot/profile/", oldFileImage);
                        }

                        if (pdf != null && MimeTypeCheckExtension.İsDocument(pdf))
                        {

                            UserContractAddDto appContract = new UserContractAddDto
                            {
                                FilePath = await AddFile("wwwroot/userContractDocs/", pdf),
                                AppUserId = model.Id,
                                CreatedByUserId = current,
                                CreatedDate = DateTime.UtcNow.AddHours(4)
                            };
                            await _userContractService.AddAsync(_map.Map<UserContractFile>(appContract));
                        }
                        else
                        {
                            if (pdf == null)
                            {
                                return RedirectToAction("List");
                            }
                            else
                            {
                                if (MimeTypeCheckExtension.İsDocument(pdf))
                                {
                                    TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
                                }
                                else
                                {
                                    TempData["msg"] = " Daxil edilən fayl pdf, docx və ya xlsx formatında olmalıdır !";
                                }
                                return RedirectToAction("List");
                            }
                        }
                    }
                }
                else
                    TempData["msg"] = " İstifadəçi tapılmadı !";
                return RedirectToAction("List");

            }

            TempData["msg"] = " Daxil edilən məlumatlar tam deyil !";
            return RedirectToAction("List");
        }

        [Authorize(Policy = "account.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var current = GetSignInUserId();
            var updateUser = _userManager.Users.FirstOrDefault(I => I.Id == id);
            updateUser.IsDeleted = true;
            updateUser.DeleteByUserId = current;
            updateUser.DeleteDate = DateTime.UtcNow.AddHours(4);
            await _userManager.UpdateAsync(updateUser);
            return Ok();

        }

        [Authorize(Policy = "account.deleteUserContract")]
        public async Task<IActionResult> DeleteUserContract(int id)
        {
            var updateUser = await _userContractService.FindByIdAsync(id);
            updateUser.IsDeleted = true;
            updateUser.DeleteByUserId = GetSignInUserId();
            updateUser.DeleteDate = DateTime.UtcNow.AddHours(4);
            await _userContractService.UpdateAsync(updateUser);
            return Ok("Uğurla silindi!");

        }

        [Authorize(Policy = "account.setrole")]
        public async Task<IActionResult> SetRole(int userId, int roleId, bool selected)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu istifadeci movcud deyil"
                });
            }

            int? currentUserId = User.GetPrincipalId();

            if (userId == currentUserId)
            {
                return Ok(new
                {
                    error = true,
                    message = "Cari istifadeci ozunu selahiyyetlendire bilmez"
                });
            }

            var role = await _db.Roles.FirstOrDefaultAsync(u => u.Id == roleId);

            if (role == null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu role movcud deyil"
                });
            }

            var userRole = await _db.UserRoles.FirstOrDefaultAsync(u => u.RoleId == roleId && u.UserId == userId);

            if (selected == true && userRole != null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu role artiq teyin edilib"
                });
            }
            else if (selected == false && userRole == null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu role bu istifadeciye aid deyil"
                });
            }


            if (selected)
            {
                _db.UserRoles.Add(new IntranetUserRole
                {
                    UserId = userId,
                    RoleId = roleId
                });

                await _db.SaveChangesAsync();
                var name = string.IsNullOrWhiteSpace(user.Email)
                    ? user.PhoneNumber
                    : user.Email;

                return Ok(new
                {
                    error = false,
                    message = $"{name} istifadeci {role.Name} rola elave edildi"
                });
            }
            else
            {
                _db.UserRoles.Remove(userRole);
                await _db.SaveChangesAsync();
                var name = string.IsNullOrWhiteSpace(user.Email)
                    ? user.PhoneNumber
                    : user.Email;

                return Ok(new
                {
                    error = false,
                    message = $"{name} istifadeci {role.Name} roldan cixarildi"
                });
            }
        }

        [Authorize(Policy = "account.setclaim")]
        public async Task<IActionResult> SetClaim(int userId, string claimName, bool selected)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu istifadeci movcud deyil"
                });
            }

            int? currentUserId = User.GetPrincipalId();
            if (userId == currentUserId)
            {
                return Ok(new
                {
                    error = true,
                    message = "Cari istifadeci ozunu selahiyyetlendire bilmez"
                });
            }

            if (!AppClaimProvider.policies.Contains(claimName))
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu imtiyaz movcud deyil"
                });
            }

            var userClaim = await _db.UserClaims.FirstOrDefaultAsync(uc => uc.UserId == userId && uc.ClaimType.Equals(claimName));

            if (selected == true && userClaim != null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu imtiyaz artiq teyin edilib"
                });
            }
            else if (selected == false && userClaim == null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu imtiyaz istifadeciye aid deyil"
                });
            }


            if (selected)
            {
                _db.UserClaims.Add(new IntranetUserClaim
                {
                    UserId = userId,
                    ClaimType = claimName,
                    ClaimValue = "1"
                });

                await _db.SaveChangesAsync();
                var name = string.IsNullOrWhiteSpace(user.Email)
                    ? user.PhoneNumber
                    : user.Email;

                return Ok(new
                {
                    error = false,
                    message = $"{name} istifadeciye {claimName} imtiyazi teyin edildi"
                });
            }
            else
            {
                _db.UserClaims.Remove(userClaim);

                await _db.SaveChangesAsync();
                var name = string.IsNullOrWhiteSpace(user.Email)
                    ? user.PhoneNumber
                    : user.Email;

                return Ok(new
                {
                    error = false,
                    message = $"{name} istifadeciden {claimName} imtiyazi alindi"
                });
            }
        }
    }
}
