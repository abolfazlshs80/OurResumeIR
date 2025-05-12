using AutoMapper;
using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using OurResumeIR.Application.Services.Implementation;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Repositories;
using System.Security.Claims;
using OurResumeIR.Application.Static;
using OurResumeIR.MVC.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageSkillController(ISkillService skillLayersService, IMapper mapper) : BaseController
    {
        


        #region Skill 


        [HttpGet]
        public async Task<IActionResult> SkillIndex()=>View(await skillLayersService.GetAllAsyncByUserId(User.GetUserId()));


        [HttpGet]
        public async Task<IActionResult> AddSkill()=>View(await skillLayersService.GetAllSkillLevelAsync());
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill(SkillFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // دوباره لیست سطح‌ها رو برای DropDown پر می‌کنیم
                model = await skillLayersService.GetAllSkillLevelAsync();
                model.Name = model.Name; // چون ممکنه کاربر مقداری وارد کرده باشد
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Skill,
                    UserPanelMessage.MessageType.AddError));
                return View(model);
            }
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Skill,
                UserPanelMessage.MessageType.AddSuccess), Url.ActionLink(nameof(SkillIndex)));
            await skillLayersService.AddSkillAsync(model);
            return RedirectToAction(nameof(SkillIndex));
        }



        [HttpGet]
        public async Task<IActionResult> SkillEdit(int id)
        {
            var model = await skillLayersService.GetSkillFormByIdAsync(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SkillEdit(SkillFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //// لیست سطح‌ها رو دوباره بارگذاری می‌کنیم
                //var layers = await skillLayersService.GetAllSkillLevelAsync();
                //model.ExpertiseLayerOptions = layers.Select(l => new SelectListItem
                //{
                //    Value = l.Id.ToString(),
                //    Text = l.Title
                //}).ToList();

                return View(model);
            }

            var result = await skillLayersService.UpdateSkillAsync(model);
            if (!result)
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Skill,
                    UserPanelMessage.MessageType.EditError));
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Skill,
                UserPanelMessage.MessageType.EditSuccess), Url.ActionLink(nameof(SkillIndex)));
            return RedirectToAction(nameof(SkillIndex));
        }
        //todo seed data create role admin and roletoUsers
  
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await skillLayersService.DeleteSkillAsync(id,User.GetUserId());
            if (!result)
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Skill,
                    UserPanelMessage.MessageType.DeleteError));
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Skill,
                UserPanelMessage.MessageType.DeleteSuccess), Url.ActionLink(nameof(SkillIndex)));
            return RedirectToAction(nameof(SkillIndex));
        }


        #endregion





    }
}
