using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    [Authorize]
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<IntranetUser> _userManager;
        //protected readonly RoleManager<IntranetUser> _roleManager;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly SignInManager<IntranetUser> _signInManager;
        protected readonly IMapper _map;
        public BaseIdentityController
            (
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IMapper map
            )
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
            _map = map;
        }

        protected int GetSignInUserId()
        {
            return _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
        }
        //protected string GetSignInUserRole()
        //{
        //    return _userManager.GetRolesAsync()
        //}


        protected void AddError(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
        protected async Task<string> AddFile(string root, IFormFile file)
        {
            string imageName = Guid.NewGuid() + Path.GetFileNameWithoutExtension(file.FileName)
                + Path.GetExtension(file.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), root + imageName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return imageName;
        }
        protected string AddResizedImage(string root, IFormFile file)
        {
            string imageName = Guid.NewGuid()
                + Path.GetExtension(file.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), root + imageName);
            using (var image = Image.Load(file.OpenReadStream()))
            {
                string newSize = ImageResize(image, 600, 600);
                string[] sizeArray = newSize.Split(",");
                image.Mutate(i => i.Resize(Convert.ToInt32(sizeArray[1]), Convert.ToInt32(sizeArray[0])));
                image.Save(path);
            }

            return imageName;
        }
        protected string ImageResize(Image img, int MaxWidth, int MaxHeight)
        {
            if (img.Width > MaxWidth || img.Height > MaxHeight)
            {
                double widthratio = (double)img.Width / (double)MaxWidth;
                double heightratio = (double)img.Height / (double)MaxHeight;
                double ratio = Math.Max(widthratio, heightratio);
                int newWidth = (int)(img.Width / ratio);
                int newHeight = (int)(img.Height / ratio);
                return newHeight.ToString() + "," + newWidth.ToString();
            }
            else
            {
                return img.Height.ToString() + "," + img.Width.ToString();
            }
        }
    }
}
