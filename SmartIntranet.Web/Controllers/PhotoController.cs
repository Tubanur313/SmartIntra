using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DTO.DTOs.PhotoDto;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    public class PhotoController : BaseIdentityController
    {
        private readonly IPhotoService _photoService;
        public PhotoController
            (
            IMapper map,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IPhotoService photoService
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _photoService = photoService;
        }
        [HttpGet]
        [Authorize(Policy = "Photo.GetPhoto")]
        public async Task<IActionResult> GetPhoto(int ticketId)
        {
            var photo =_map.Map<List<PhotoListDto>>( await _photoService.GetAllByTicketAsync(ticketId));
            return PartialView("_photo", photo);
        }
    }
}
