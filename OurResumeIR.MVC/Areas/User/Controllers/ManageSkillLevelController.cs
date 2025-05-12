using AutoMapper;
using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.Static;
using OurResumeIR.Application.ViewModels.SkillLevel;
using OurResumeIR.MVC.Controllers;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageSkillLevelController(ISkillLevelService skillLayersService, IMapper mapper) : BaseController
    {
        #region SkillLevel Layer

        public async Task<IActionResult> SkillLevelList()=>View(await skillLayersService.GetAll(User.GetUserId()));

        [HttpGet]
        public async Task<IActionResult> SkillLevelCreate() => View(new CreateSkillLevelVM());

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> SkillLevelCreate(CreateSkillLevelVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            bool status = await skillLayersService.Create(model);
            if (status)
            {
                SendSuccessMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Skill_Level,
                    UserPanelMessage.MessageType.AddSuccess), Url.ActionLink(nameof(SkillLevelList)));
                return RedirectToAction(nameof(SkillLevelList));
            }

            SendErrorMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Skill_Level,
                UserPanelMessage.MessageType.AddError));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SkillLevelUpdate(int id)
        {

            var find_xpertiseLayers = await skillLayersService.GetById(id);
            if (find_xpertiseLayers == null)
                return NotFound();
            return View(mapper.Map<UpdateSkillLevelVM>(find_xpertiseLayers));



        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> SkillLevelUpdate(UpdateSkillLevelVM model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);


            bool status = await skillLayersService.Update(model);
            if (status)
            {
                SendSuccessMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Skill_Level,
                    UserPanelMessage.MessageType.EditSuccess), Url.ActionLink(nameof(SkillLevelList)));
                return RedirectToAction(nameof(SkillLevelList));
            }


            SendErrorMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Skill_Level,
                UserPanelMessage.MessageType.EditError));
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> SkillLevelDelete(int id)
        {
            bool status = await skillLayersService.Delete(id,User.GetUserId());
            if (!status)
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Skill_Level,
                    UserPanelMessage.MessageType.DeleteError));

            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Skill_Level,
                UserPanelMessage.MessageType.EditSuccess), Url.ActionLink(nameof(SkillLevelList)));
            return RedirectToAction(nameof(SkillLevelList));

        }

        #endregion
    }
}
