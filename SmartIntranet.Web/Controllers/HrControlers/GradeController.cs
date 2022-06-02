using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Core.Utilities.Messages;
using SmartIntranet.DTO.DTOs.GradeDto;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers.HrControlers
{
    public class GradeController : BaseIdentityController
    {
        private readonly IGradeService _gradeService;
        public GradeController(UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor, SignInManager<IntranetUser> signInManager,
            IMapper map, IGradeService gradeService) : base(userManager, httpContextAccessor,
                signInManager, map)
        {
            _gradeService = gradeService;
        }

        [Authorize(Policy = "grade.list")]
        public async Task<IActionResult> List()
        {
            var model = (await _gradeService.GetAllAsync()).Where(x => !x.IsDeleted).ToList();
            if (model.Count > 0)
            {
                return View(_map.Map<List<GradeListDto>>(model));
            }
            return View(new List<GradeListDto>());
        }

        [HttpGet]
        [Authorize(Policy = "grade.add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "grade.add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GradeAddDto model)
        {
            if (ModelState.IsValid)
            {
                var add = _map.Map<Grade>(model);
                add.CreatedByUserId = GetSignInUserId();
                if (await _gradeService.AddReturnEntityAsync(add) is null)
                {
                    TempData["error"] = Messages.Add.notAdded;
                    return RedirectToAction("List");
                }
                TempData["success"] = Messages.Add.Added;
                return RedirectToAction("List");
            }
            else
            {
                TempData["error"] = Messages.Error.notComplete;
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        [Authorize(Policy = "grade.update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = _map.Map<GradeUpdateDto>(await _gradeService.FindByIdAsync(id));
            if (data is null)
            {
                TempData["error"] = Messages.Error.notFound;
                return RedirectToAction("List");
            }
            return View(data);
        }

        [HttpPost]
        [Authorize(Policy = "grade.update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(GradeUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var data = await _gradeService.FindByIdAsync(model.Id);
                var update = _map.Map<Grade>(model);
                update.UpdateByUserId = GetSignInUserId();
                update.CreatedByUserId = data.CreatedByUserId;
                update.DeleteByUserId = data.DeleteByUserId;
                update.CreatedDate = data.CreatedDate;
                update.UpdateDate = DateTime.Now;
                update.DeleteDate = data.DeleteDate;

                await _gradeService.UpdateAsync(update);
                TempData["success"] = Messages.Update.Updated;
                return RedirectToAction("List");
            }
            TempData["error"] = Messages.Error.notComplete;
            return RedirectToAction("List");
        }

        [Authorize(Policy = "grade.delete")]
        public async Task Delete(int id)
        {
            var delete = await _gradeService.FindByIdAsync(id);
            delete.DeleteByUserId = GetSignInUserId();
            delete.DeleteDate = DateTime.Now;
            delete.IsDeleted = true;
            await _gradeService.UpdateAsync(delete);
        }
    }
}
