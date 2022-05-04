using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DTO.DTOs.CheckListDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SmartIntranet.Web.Controllers
{
    public class WatchersController : BaseIdentityController
    {
        private readonly IWatcherService _watcherService;
        public WatchersController(
            IMapper map,
            IWatcherService watcherService,
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager
            ) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _watcherService = watcherService;
        }
        [Authorize(Policy = "watchers.delete")]
        public async Task Delete(int id)
        {
            await _watcherService.DeleteByIdAsync(id);
        }

    }
}
