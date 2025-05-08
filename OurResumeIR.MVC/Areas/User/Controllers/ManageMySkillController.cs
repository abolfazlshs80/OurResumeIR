using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.MySkills;
using System.Security.Claims;
using OurResumeIR.Application.Static;
using OurResumeIR.MVC.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageMySkillController(ISkillService skillLayersService) : BaseController
    {

        #region My skills

        public async Task<IActionResult> MySkillsList()
        {

            var userId = User.GetUserId();

            var model = await skillLayersService.GetAllSkillAndSkillLevelForViewAsync(userId);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddMySkills()
        {

            var model = await skillLayersService.GetAllSkillAndSkillLevelForDropDownAsync();
            model.UserId = User.GetUserId();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMySkills(AddMySkillsViewModel viewModel)
        {


            if (!ModelState.IsValid)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.MySkill,
                    UserPanelMessage.MessageType.AddError));
                return View(viewModel);
            }

            await skillLayersService.AddMySkillAsync(viewModel);
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.MySkill,
                UserPanelMessage.MessageType.AddSuccess), Url.ActionLink(nameof(MySkillsList)));
            return RedirectToAction(nameof(MySkillsList));
        }



        [HttpGet]
        public async Task<IActionResult> EditMySkills(int id)
        {

            var model = skillLayersService.GetSkillForEditAsync(id, out var skill, out var skillLevel);
            ViewBag.SkillLevel = skillLevel;
            ViewBag.Skill = skill;
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMySkills(EditMySkillsViewModel viewModel)
        {

            // ذخیره ویرایش از طریق سرویس
            await skillLayersService.UpdateUserSkillAsync(viewModel);
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.MySkill,
                UserPanelMessage.MessageType.EditSuccess), Url.ActionLink(nameof(MySkillsList)));
            return RedirectToAction(nameof(MySkillsList));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMySkill(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await skillLayersService.DeleteUserSkillAsync(id, userId);
            if (!result)
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.MySkill,
                    UserPanelMessage.MessageType.DeleteError));

            SendSuccessMessage(UserPanelMessage.GetMessage(
                        UserPanelMessage.MySkill,
                        UserPanelMessage.MessageType.DeleteSuccess)
                    , Url.ActionLink(nameof(MySkillsList)));
            return RedirectToAction(nameof(MySkillsList));
        }

        #endregion
    }
}
