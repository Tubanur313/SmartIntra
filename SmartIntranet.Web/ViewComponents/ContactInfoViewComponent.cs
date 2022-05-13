using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.DTO.DTOs.AppUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Web.ViewComponents
{
    public class ContactInfoViewComponent : ViewComponent
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public ContactInfoViewComponent(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<ICollection<AppUserContactListDto>>( _appUserService.GetAllIncludeAsync().Result
                .OrderBy(x => new Random().Next()).ToList()));
        }
    }
}
