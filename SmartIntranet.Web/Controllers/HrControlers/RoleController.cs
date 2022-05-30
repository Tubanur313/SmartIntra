using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Business.Provider;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class RoleController : BaseIdentityController
    {
        private readonly IntranetContext _db;
        private readonly IAppRoleService _roleService;
        private readonly RoleManager<IntranetRole> _roleManager;

        public RoleController(IntranetContext db, RoleManager<IntranetRole> roleManager, UserManager<IntranetUser> userManager,
            IMapper map,
            IAppRoleService roleService,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager) : base(userManager, httpContextAccessor, signInManager, map)
        {
            _db = db;
            _roleService = roleService;
            _roleManager = roleManager;
        }

        [Authorize(Policy = "role.list")]
        public async Task<IActionResult> List()
        {
            var model = await _roleService.GetAllAsync();
            if (model.Count > 0)
            {
                return View(_map.Map<List<AppRoleListDto>>(model));
            }
            return View(new List<AppRoleListDto>());
        }
        [HttpGet]
        [Authorize(Policy = "role.add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "role.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AppRoleAddDto model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            else
            {
                model.CreatedByUserId = GetSignInUserId();
                model.IsDeleted = false;
                await _roleManager.CreateAsync(_map.Map<IntranetRole>(model));
                //await _roleService.AddAsync(_map.Map<IntranetRole>(model));
                TempData["success"] = Messages.Add.Added;
                return RedirectToAction("List");

            }
        }
        [HttpGet]
        [Authorize(Policy = "role.update")]
        public async Task<IActionResult> Update(int id)
        {
            var model = _map.Map<AppRoleUpdateDto>(await _roleService.FindByIdAsync(id));
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "role.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AppRoleUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = Messages.Error.notComplete;
                return RedirectToAction("List");
            }
            else
            {
                var updateRole = _roleManager.Roles.FirstOrDefault(I => I.Id == model.Id);
                var current = GetSignInUserId();
                updateRole.Name = model.Name;
                updateRole.IsDeleted = model.IsDeleted;
                updateRole.UpdateDate = DateTime.Now;
                updateRole.UpdateByUserId = current;

                IdentityResult result = await _roleManager.UpdateAsync(updateRole);
                return RedirectToAction("List");
            }
        }
        [HttpGet]
        [Authorize(Policy = "role.permission")]
        public async Task<IActionResult> Permission(int id)
        {
            var role = await _roleService.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var vm = new AppRoleClaimsDto
            {
                Role = role
            };



            vm.Claims = (from p in AppClaimProvider.policies
                         join uc in _db.RoleClaims.Where(_ => _.RoleId == role.Id && _.ClaimValue.Equals("1")) on p equals uc.ClaimType into ljUc
                         from jUc in ljUc.DefaultIfEmpty()
                         select Tuple.Create(p, jUc != null)).ToList();


            return View(vm);
        }
        [Authorize(Policy = "role.delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionModel = _roleManager.Roles.FirstOrDefault(I => I.Id == id);
            var current = GetSignInUserId();
            transactionModel.DeleteDate = DateTime.UtcNow.AddHours(4);
            transactionModel.DeleteByUserId = current;
            transactionModel.IsDeleted = true;
            IdentityResult result = await _roleManager.UpdateAsync(transactionModel);
            return RedirectToAction("List");

        }
        [Authorize(Policy = "role.setclaim")]
        public async Task<IActionResult> SetClaim(int roleId, string claimName, bool selected)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(u => u.Id == roleId);

            if (role == null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu rol movcud deyil"
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

            var roleClaim = await _db.RoleClaims.FirstOrDefaultAsync(uc => uc.RoleId == roleId && uc.ClaimType.Equals(claimName));

            if (selected == true && roleClaim != null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu imtiyaz artiq teyin edilib"
                });
            }
            else if (selected == false && roleClaim == null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Bu imtiyaz rola aid deyil"
                });
            }


            if (selected)
            {
                _db.RoleClaims.Add(new IntranetRoleClaim
                {
                    RoleId = roleId,
                    ClaimType = claimName,
                    ClaimValue = "1"
                });

                await _db.SaveChangesAsync();
                var name = string.IsNullOrWhiteSpace(role.Name);

                return Ok(new
                {
                    error = false,
                    message = $"{name} roluna {claimName} imtiyazi teyin edildi"
                });
            }
            else
            {
                _db.RoleClaims.Remove(roleClaim);

                await _db.SaveChangesAsync();
                var name = string.IsNullOrWhiteSpace(role.Name);

                return Ok(new
                {
                    error = false,
                    message = $"{name} roluna {claimName} imtiyazi alindi"
                });
            }
        }
    }
}
