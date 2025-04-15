using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Repositories;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class ManageSkillController(IExpertiseService expertiseLayersService, IMapper mapper) : Controller
    {
        #region SkillLevel Layer

        public async Task<IActionResult> SkillLevelList()
        {
            var list = await expertiseLayersService.GetAll();

            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> SkillLevelCreate() => View();

        [HttpPost]
        public async Task<IActionResult> SkillLevelCreate(CreateSkillLevelVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            bool status = await expertiseLayersService.Create(model);
            if (status)
                return RedirectToAction("SkillLevelList");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SkillLevelUpdate(int id)
        {

            var find_xpertiseLayers = await expertiseLayersService.GetById(id);
            if (find_xpertiseLayers == null)
                return NotFound();
            return View(mapper.Map<UpdateSkillLevelVM>(find_xpertiseLayers));



        }

        [HttpPost]
        public async Task<IActionResult> SkillLevelUpdate(UpdateSkillLevelVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            bool status = await expertiseLayersService.Update(model);
            if (status)
                return RedirectToAction("SkillLevelList");

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> SkillLevelDelete(int id)
        {
            bool status = await expertiseLayersService.Delete(id);
            return RedirectToAction("SkillLevelList");

        }

        #endregion


        #region Specialties 


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await expertiseLayersService.GetAllExperiencesAsync();
            return View(list);
        }


        [HttpGet]
        public async Task<IActionResult> AddExperiences()
        {
            var viewModel = await expertiseLayersService.GetAllExperiencesLayerAsync();
            return View(viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExperiences(SkillFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // دوباره لیست سطح‌ها رو برای DropDown پر می‌کنیم
                model = await expertiseLayersService.GetAllExperiencesLayerAsync();
                model.Name = model.Name; // چون ممکنه کاربر مقداری وارد کرده باشد
                model.ExpertiseLayerId = model.ExpertiseLayerId;
                return View(model);
            }

            await expertiseLayersService.AddExperienceAsync(model);
            return RedirectToAction("Index"); 
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await expertiseLayersService.GetExperienceFormByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkillFormViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    model = await expertiseLayersService.GetCreateFormAsync(model);
            //    return View(model);
            //}

            //await expertiseLayersService.UpdateExperienceAsync(model);
            //return RedirectToAction("Index");



            if (!ModelState.IsValid)
            {
                //// لیست سطح‌ها رو دوباره بارگذاری می‌کنیم
                //var layers = await expertiseLayersService.GetAllExperiencesLayerAsync();
                //model.ExpertiseLayerOptions = layers.Select(l => new SelectListItem
                //{
                //    Value = l.Id.ToString(),
                //    Text = l.Title
                //}).ToList();

                return View(model);
            }

            var result = await expertiseLayersService.UpdateExperienceAsync(model);
            if (!result)
                return NotFound();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteExperiences(int id)
        {
            var result = await expertiseLayersService.DeleteExperienceAsync(id);
            if (!result)
                return NotFound();

            return RedirectToAction("Index");
        }


        #endregion


    }
}
