using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Core.Extensions;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Web.GoogleRecaptcha;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class UserController : BaseIdentityController
    {
        private readonly IConfiguration _configuration;
        private readonly GoogleConfigModel _googleConfig;
        private readonly IAppUserService _appUserService;
        private readonly ICompanyService _companyService;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionService _positionService;
        private readonly IFileService _uploadService;
        private IPasswordHasher<IntranetUser> _passwordHasher;
        public UserController(IOptions<GoogleConfigModel> googleConfig,  UserManager<IntranetUser> userManager,
             IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager,
            IMapper map, IPasswordHasher<IntranetUser> passwordHasher, IAppUserService appUserService, IFileService uploadService,
            IConfiguration configuration, ICompanyService companyService, IDepartmentService departmentService,
            IPositionService positionService) : base(userManager, httpContextAccessor, signInManager,map)
        {

            _googleConfig = googleConfig.Value;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _appUserService = appUserService;
            _uploadService = uploadService;
            _companyService = companyService;
            _departmentService = departmentService;
            _positionService = positionService;
        }
        [HttpGet]
        [Authorize(Policy = "user.profile")]
        public async Task<IActionResult> Profile(int id)
        {
            AppUserProfileUpdateDto appUserProfileUpdateDto = new AppUserProfileUpdateDto()
            {
                AppUserPassDto = _map.Map<AppUserPassDto>(await _appUserService.FindByUserAllInc(id)),
                AppUserProfileDto = _map.Map<AppUserProfileDto>(await _appUserService.FindByUserAllInc(id)),
                AppUserImageDto = _map.Map<AppUserImageDto>(await _appUserService.FindByUserAllInc(id))

            };


            return View(appUserProfileUpdateDto);
        }

        [HttpPost]
        [Authorize(Policy = "user.profileUpdate")]
        public async Task<IActionResult> Profile(AppUserProfileAddDto model/*, IFormFile profile*/)
        {
            var current = GetSignInUserId();
            var updateUser = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);

            if (updateUser != null)
            {
                updateUser.PhoneNumber = model.PhoneNumber;
                updateUser.UpdateByUserId = current;

                IdentityResult result = await _userManager.UpdateAsync(updateUser);
            }
            else
                TempData["error"] = " İstifadəçi tapılmadı !";
            return RedirectToAction("Profile");
        }


        [AllowAnonymous]
        [Route("signin.html")]
        public IActionResult SignIn()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("signin.html")]
        public async Task<IActionResult> SignIn(AppUserSignInDto model)
        {
            var isValid = IsReCaptchValidV3(model.captcha);
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user.IsDeleted != true && user.DeleteByUserId == null && isValid)
                {
                    if (user != null)
                    {
                        await _signInManager.SignOutAsync();
                        var identityResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, true);
                        if (identityResult.Succeeded)
                        {
                            var roller = await _userManager.GetRolesAsync(user);
                            return RedirectToAction("Info", "News");
                        }
                    }
                    ViewBag.error = "Email ve ya şifre sehvdir";
                }
                else
                {
                    ViewBag.error = "Sizin Akkount Deaktiv edilib";
                    return View("SignIn", model);
                }
            }
            return View("SignIn", model);
        }
        private bool IsReCaptchValidV3(string captchaResponse)
        {
            var result = false;
            var secretKey = _googleConfig.Secret;
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = isSuccess ? true : false;
                }
            }
            return result;
        }
        //[AllowAnonymous]
        //[Route("User/RecaptchaVerify")]
        //public JsonResult RecaptchaVerify(string token)
        //{
        //    return new JsonResult(_recaptchaValidator.IsRecaptchaValid(token));
        //}
        [HttpGet]
        [Route("accessdenied.html")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("signout")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        [Authorize(Policy = "user.newPassword")]
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
        [Authorize(Policy = "user.imageUpdate")]
        public async Task<IActionResult> ImageUpdate(IFormFile profile)
        {
            var updateUser = _userManager.Users.FirstOrDefault(I => I.Id == GetSignInUserId());

            if (profile != null && profile.FileName != "default.png")
            {
                if (!MimeTypeCheckExtension.İsImage(profile))
                {
                    return Ok(" Daxil edilən Profil rəsmi image, png və ya gif formatında olmalıdır !");
                }
                updateUser.Picture = _uploadService.UploadResizedImg(profile, "wwwroot/profile/");
                await _userManager.UpdateAsync(updateUser);
                return Ok(" Uğurla yeniləndi !");
            }
            else
            {
                updateUser.Picture = "default.png";
                await _userManager.UpdateAsync(updateUser);
                return Ok(" Profil rəsmi Uğurla yeniləndi !");
            }

        }

        [HttpPost]
        [Authorize(Policy = "user.newPassword")]
        public async Task<IActionResult> NewPassword(AppUserPassDto appUserPass)
        {
            var model = appUserPass.Id;
            if (ModelState.IsValid)
            {
                var updateUser = _userManager.Users.FirstOrDefault(I => I.Id == appUserPass.Id);
                if (!string.IsNullOrEmpty(appUserPass.Password))
                    updateUser.PasswordHash = _passwordHasher.HashPassword(updateUser, appUserPass.Password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                IdentityResult result = await _userManager.UpdateAsync(updateUser);
                return RedirectToAction("Profile", new { id = appUserPass.Id });
            }
            else
            {
                TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
                return RedirectToAction("Profile", new { id = appUserPass.Id });
            }

        }



        [HttpGet]
        [Authorize(Policy = "user.update")]
        public async Task<IActionResult> Update(int id)
        {
            var model = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted != true));
           ViewBag.companies = _map.Map<ICollection<CompanyListDto>>(await _companyService.GetAllAsync(x => x.IsDeleted != true));
            ViewBag.departments = _map.Map<ICollection<DepartmentListDto>>(await _departmentService.GetAllAsync(x => x.IsDeleted != true));
            ViewBag.position = _map.Map<ICollection<PositionListDto>>(await _positionService.GetAllAsync(x => x.IsDeleted != true));
           var listModel = _map.Map<AppUserUpdateDto>(await _appUserService.FindByIdAsync(id));
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }


        [HttpPost]
        [Authorize(Policy = "user.update")]
        public async Task<IActionResult> Update(AppUserUpdateDto model, IFormFile profile)
        {

            if (ModelState.IsValid)
            {
                if (profile != null && profile.FileName != "default.png")
                {
                    if (!MimeTypeCheckExtension.İsImage(profile))
                    {
                        TempData["error"] = " Daxil edilən Profil rəsmi image, png və ya gif formatında olmalıdır !";
                        return RedirectToAction("List");
                    }

                    model.Picture = _uploadService.UploadResizedImg(profile, "wwwroot/profile/");
                }

                else if (profile != null)
                {
                    if (MimeTypeCheckExtension.İsImage(profile))
                    {
                        model.Picture = "logoDefault.png";

                    }
                    else
                    {
                        TempData["error"] = " Daxil edilən Profil rəsmi image, png və ya gif formatında olmalıdır !";
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


                if (updateUser != null)
                {

                    if (!string.IsNullOrEmpty(model.Email))
                        updateUser.Email = model.Email;
                    else
                        ModelState.AddModelError("", "Email boş ola bilməz !");

                    if (!string.IsNullOrEmpty(model.Email))
                    {
                        updateUser.CompanyId = model.CompanyId;
                        updateUser.DepartmentId = model.DepartmentId;
                        updateUser.PositionId = model.PositionId;
                        updateUser.PhoneNumber = model.PhoneNumber;
                        updateUser.Picture = model.Picture;
                        updateUser.UpdateByUserId = current;

                        IdentityResult result = await _userManager.UpdateAsync(updateUser);

                       
                    }
                }
                else
                    TempData["error"] = " İstifadəçi tapılmadı !";
                return RedirectToAction("List");

            }

            //TempData["error"] = " Daxil edilən fayllar image, png və ya gif formatında olmalıdır !";
            TempData["error"] = " Daxil edilən məlumatlar tam deyil !";
            return RedirectToAction("List");
        }

    }
}
