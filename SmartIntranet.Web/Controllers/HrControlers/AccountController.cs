﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Business.Provider;
using SmartIntranet.Core.Extensions;
using SmartIntranet.Core.Utilities.FileUploader;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.GradeDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.DTO.DTOs.UserContractDto;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    [Authorize]
    public class AccountController : BaseIdentityController
    {
        private readonly IAppUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IGradeService _gradeService;
        private readonly IFileManager _upload;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionService _positionService;
        private readonly IUserContractService _userContractService;
        private readonly IntranetContext _db;
        private IPasswordHasher<IntranetUser> _passwordHasher;
        public AccountController(
            IMapper map,
            IAppUserService userService,
            ICompanyService companyService,
            IGradeService gradeService,
            IFileManager upload,
            IDepartmentService departmentService,
            IPositionService positionService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IPasswordHasher<IntranetUser> passwordHasher,
            IUserContractService userContractService,
            IntranetContext db
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _userService = userService;
            _companyService = companyService;
            _gradeService = gradeService;
            _upload = upload;
            _departmentService = departmentService;
            _positionService = positionService;
            _passwordHasher = passwordHasher;
            _userContractService = userContractService;
            _db = db;
        }

        [HttpGet]
        [Authorize(Policy = "account.list")]
        public async Task<IActionResult> List()
        {
            var model = await _userService.GetAllIncludeAsync();
            if (model.Count > 0)
            {
                return View(_map.Map<List<AppUserListDto>>(model));
            }
            return View(new List<AppUserListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "account.permission")]
        public async Task<IActionResult> Permission(int id)
        {
            var user = await _userService.FindByIdAsync(id);

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
            var user = await _userService.FindByIdAsync(id);

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
        [Authorize(Policy = "account.add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.companies = _map
                .Map<List<CompanyListDto>>(await _companyService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.grades = _map
                .Map<List<GradeListDto>>(await _gradeService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.departments = _map
                .Map<List<DepartmentListDto>>(await _departmentService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.position = _map
                .Map<List<PositionListDto>>(await _positionService.GetAllAsync(x => !x.IsDeleted));

            return View();
        }
        [HttpPost]
        [Authorize(Policy = "account.add")]
        public async Task<IActionResult> Add(AppUserAddDto model, IFormFile profile)
        {
            if (ModelState.IsValid)
            {
                if (!(profile is null) && profile.FileName != "default.png")
                {
                    if (!MimeTypeCheckExtension.İsImage(profile))
                    {
                        TempData["error"] = " Daxil edilən fayllar image, jpeg, png və ya gif formatında olmalıdır !";
                    }
                    else
                    {
                        model.Picture = _upload.UploadResizedImg(profile, "wwwroot/profile/");
                    }
                }

                IntranetUser appUser = _map.Map<IntranetUser>(model);
                appUser.UserName = CreateUsername.FixUsername(model.FirstName + "." + model.LastName);
                appUser.CreatedByUserId=GetSignInUserId();
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    TempData["success"] = "Əlavə olundu";
                    return RedirectToAction("List");
                }
                TempData["error"] = " Məlumat əlavə olunmadı";
                return RedirectToAction("List");
            }
            else
            {
                TempData["error"] = " Daxil edilən məlumatlar tam deyil";
                return RedirectToAction("List");
            }
        }
        [HttpGet]
        [Authorize(Policy = "account.update")]
        public async Task<IActionResult> Update(int Id)
        {
            var data = _map.Map<AppUserUpdateDto>(await _userService.FindByUserAllInc(Id));
            if (data is null)
            {
                TempData["error"] = " Məlumat tapılmadı";
                return RedirectToAction("List");
            }
            ViewBag.companies = _map
                .Map<List<CompanyListDto>>(await _companyService
                .GetAllAsync(x => !x.IsDeleted));

            ViewBag.departments = _map
                .Map<List<DepartmentListDto>>(await _departmentService
                .GetAllAsync(x => !x.IsDeleted
                && x.CompanyId == data.CompanyId));

            ViewBag.position = _map
                .Map<List<PositionListDto>>(await _positionService
                .GetAllAsync(x => !x.IsDeleted
                && x.CompanyId == data.CompanyId
                && x.DepartmentId == data.DepartmentId));
            ViewBag.grades = _map
                .Map<List<GradeListDto>>(await _gradeService.GetAllAsync(x => !x.IsDeleted));
            ViewBag.docs = _map.Map<ICollection<UserContractListDto>>(await _userContractService.GetContractsByActiveUserIdAsync(Id));
            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "account.update")]
        public async Task<IActionResult> Update(AppUserUpdateDto model, IFormFile profile, IFormFile pdf)
        {
            if (ModelState.IsValid)
            {
                IntranetUser user = _map.Map<IntranetUser>(model);
                var update = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (profile !=null && profile.FileName != "default.png")
                {
                    _upload.Delete(update.Picture, "wwwroot/profile/");
                    user.Picture = _upload.UploadResizedImg(profile, "wwwroot/profile/");
                }
                else if (profile != null)
                {
                    user.Picture = "default.png";
                }
                else
                {
                    user.Picture = update.Picture;
                }
                update.UpdateByUserId = GetSignInUserId();
                update.UpdateDate = DateTime.Now;
                update.FirstName = user.FirstName;
                update.LastName = user.LastName;
                update.Picture = user.Picture;
                update.Email = user.Email;
                update.PhoneNumber = user.PhoneNumber;
                update.Birthday = user.Birthday;
                update.GradeId = user.GradeId;
                update.CompanyId = user.CompanyId;
                update.DepartmentId = user.DepartmentId;
                update.PositionId = user.PositionId;
                update.IsDeleted = user.IsDeleted;

                if (await _userManager.UpdateAsync(update) is null)
                {
                    TempData["error"] = " Məlumat yenilənmədi";
                    return View(model);
                }

                if (pdf != null && MimeTypeCheckExtension.İsDocument(pdf))
                {

                    UserContractAddDto appContract = new UserContractAddDto
                    {
                        FilePath = await _upload.Upload( pdf , "wwwroot/userContractDocs/"),
                        AppUserId = model.Id,
                    };
                    var add = _map.Map<UserContractFile>(appContract);
                    add.CreatedByUserId = GetSignInUserId();
                    await _userContractService.AddAsync(add);
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
                            TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                        }
                        else
                        {
                            TempData["error"] = " Daxil edilən fayl pdf, docx və ya xlsx formatında olmalıdır !";
                        }
                        return RedirectToAction("List");
                    }
                }

                TempData["success"] = "Yeniləndi";
                return RedirectToAction("List");
            }
            TempData["error"] = " Daxil edilən məlumatlar tam deyil";
            return RedirectToAction("List");

        }
        [HttpGet]
        [Authorize(Policy = "account.newPassword")]
        public async Task<IActionResult> NewPassword(int id)
        {
            var data = _map.Map<AppUserPassDto>(await _userService.FindByIdAsync(id));
            if (data == null)
            {
                TempData["error"] = " Məlumat tapılmadı";
                return RedirectToAction("List");
            }

            return View(data);
        }
        [HttpPost]
        [Authorize(Policy = "account.newPassword")]
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
                TempData["error"] = " Daxil edilən məlumatlar tam deyil";
                return RedirectToAction("List");
            }
        }
        [Authorize(Policy = "account.delete")]
        public async Task Delete(int id)
        {
            var delete = await _userService.FindByIdAsync(id);
            //delete.DeleteByUserId = 1;
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _userService.UpdateAsync(delete);
        }
        [HttpGet]
        public async Task<IActionResult> GetPosition(int departmentId)
        {
            var position = await _positionService
                .GetAllAsync(x => x.IsDeleted == false
                && x.DepartmentId == departmentId);
            return Ok(position.Select(x => new { x.Id, x.Name }));
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartment(int companyId)
        {
            var department = await _departmentService
                .GetAllAsync(x => x.IsDeleted == false
                && x.CompanyId == companyId);
            return Ok(department.Select(x => new { x.Id, x.Name }));
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
