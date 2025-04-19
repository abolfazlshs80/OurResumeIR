using AutoMapper;
using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using OurResumeIR.Application.Services.Implementation;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Repositories;
using System.Security.Claims;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class ManageSkillController(ISkillService skillLayersService, IMapper mapper) : Controller
    {
        #region SkillLevel Layer

        public async Task<IActionResult> SkillLevelList()
        {
            var list = await skillLayersService.GetAll();

            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> SkillLevelCreate() => View();

        [HttpPost]
        public async Task<IActionResult> SkillLevelCreate(CreateSkillLevelVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            bool status = await skillLayersService.Create(model);
            if (status)
                return RedirectToAction("SkillLevelList");

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

        [HttpPost]
        public async Task<IActionResult> SkillLevelUpdate(UpdateSkillLevelVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            bool status = await skillLayersService.Update(model);
            if (status)
                return RedirectToAction("SkillLevelList");

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> SkillLevelDelete(int id)
        {
            bool status = await skillLayersService.Delete(id);
            return RedirectToAction("SkillLevelList");

        }

        #endregion


        #region Specialties 


        [HttpGet]
        public async Task<IActionResult> SkillIndex()
        {
            var list = await skillLayersService.GetAllSkillAsync();
            return View(list);
        }


        [HttpGet]
        public async Task<IActionResult> AddSkill()
        {
            var viewModel = await skillLayersService.GetAllSkillLevelAsync();
            return View(viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill(SkillFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // دوباره لیست سطح‌ها رو برای DropDown پر می‌کنیم
                model = await skillLayersService.GetAllSkillLevelAsync();
                model.Name = model.Name; // چون ممکنه کاربر مقداری وارد کرده باشد
                return View(model);
            }

            await skillLayersService.AddSkillAsync(model);
            return RedirectToAction("SkillIndex");
        }



        [HttpGet]
        public async Task<IActionResult> SkillEdit(int id)
        {
            var model = await skillLayersService.GetSkillFormByIdAsync(id);
            return View(model);
        }

        [HttpPost]
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
                return NotFound();

            return RedirectToAction("SkillIndex");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await skillLayersService.DeleteSkillAsync(id);
            if (!result)
                return NotFound();

            return RedirectToAction("SkillIndex");
        }


        #endregion



        #region My skills

        public async Task<IActionResult> MySkillsList()
        {
            // گرفتن ویو مدل از لایه سرویس برای نمایش نام تخصص و سطح تخصص داخل یک لیست
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var model = await skillLayersService.GetAllSkillAndSkillLevelForViewAsync(userId);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddMySkills()
        {
            // گرفتن نام تخصص ها و سطح تخصص ها از لایه سرویس و نمایش آن ها داخل دراپ دان ویو
            var model = await skillLayersService.GetAllSkillAndSkillLevelForDropDownAsync();
            model.UserId = User.GetUserId();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMySkills(AddMySkillsViewModel viewModel)
        {
            // گرفتن نام تخصص و سطح تخصص از کاربر و  برای لایه سرویس و تبدیل ویو مدل به مدل در لایه سرویس

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
       
            await skillLayersService.AddMySkillAsync(viewModel);

            return RedirectToAction("MySkillsList");
        }

        #endregion


    }
}
