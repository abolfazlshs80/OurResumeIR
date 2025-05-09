using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Interfaces;

public class MySkillService(IUnitOfWork unitOfWork,
 IMapper mapper) : IMySkillService
{





    public async Task<List<MySkillsForListViewModel>> GetAllSkillAndSkillLevelForViewAsync(string userId)
    {
        var userSkills = await unitOfWork.SkillRepository.GetAllSkillAndSkillLevelAsync(userId);

        return userSkills.Select(x => new MySkillsForListViewModel
        {
            SkillName = x.Skill.Name,
            SkillLevelName = x.SkillLevel.Name,
            Id = x.Id,

        }).ToList();
    }

    public async Task<AddMySkillsViewModel> GetAllSkillAndSkillLevelForDropDownAsync()
    {
        var skill = await unitOfWork.SkillRepository.GetAllSkillAsync();
        var skillLevel = await unitOfWork.SkillRepository.GetAllSkillLevelAsync();

        var model = new AddMySkillsViewModel
        {
            // پر کردن SelectListItem برای دراپ دان ها داخل ویو
            Skills = skill.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name,

            }).ToList(),

            SkillLevels = skillLevel.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name,
            }).ToList()
        };

        return model;
    }

    public async Task AddMySkillAsync(AddMySkillsViewModel model)
    {
        var UserSkills = new UserToSkill
        {
            SkillId = model.SelectedSkillId,
            SkillLevelId = model.SelectedSkillLevelId,
            UserId = model.UserId.ToString(),
        };

        await unitOfWork.sk.AddMySkillsAsync(UserSkills);

    }

    public EditMySkillsViewModel GetSkillForEditAsync(int userToSkillId, out List<SelectListItem> skill, out List<SelectListItem> skillLevel)
    {
        // حالا FindAsync خودش یک UserToSkill برمی‌گردونه
        var selected = unitOfWork.UserToSkillRepository.FindAsync(u => u.Id == userToSkillId).Result;

        if (selected == null)
        {
            skill = new List<SelectListItem>();
            skillLevel = new List<SelectListItem>();
            return new EditMySkillsViewModel();
        }


        // گرفتن لیست کامل برای DropDown ها
        var skillList = unitOfWork.SkillRepository.GetAllSkillAsync().Result;
        var skillLevelList = unitOfWork.SkillLevelRepository.GetAllSkillLevelAsync().Result;

        // ساخت ViewModel با پر کردن DropDown و مقادیر انتخاب‌شده
        var model = new EditMySkillsViewModel
        {
            Id = selected.Id,
            SkillId = selected.SkillId,
            SkillLevelId = selected.SkillLevelId,
            //UserId = selected.UserId.ToString(),

            //Skills = skillList.Select(s => new SelectListItem
            //{
            //    Value = s.Id.ToString(),
            //    Text = s.Name,
            //    Selected = s.Id == selected.SkillId
            //}).ToList(),

            //SkillLevels = skillLevelList.Select(s => new SelectListItem
            //{
            //    Value = s.Id.ToString(),
            //    Text = s.Name,
            //    Selected = s.Id == selected.SkillLevelId
            //}).ToList(),
        };
        skill = skillList.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.Name,
            Selected = s.Id == selected.SkillId
        }).ToList();

        skillLevel = skillLevelList.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.Name,
            Selected = s.Id == selected.SkillId
        }).ToList();


        return model;
    }

    public async Task FillDropDownsForEditViewModel(EditMySkillsViewModel model)
    {
        var skillList = await unitOfWork.SkillRepository.GetAllSkillAsync();
        var skillLevelList = await unitOfWork.SkillLevelRepository.GetAllSkillLevelAsync();

        //model.Skills = skillList.Select(s => new SelectListItem
        //{
        //    Value = s.Id.ToString(),
        //    Text = s.Name,
        //    Selected = s.Id == model.SkillId
        //}).ToList();

        //model.SkillLevels = skillLevelList.Select(s => new SelectListItem
        //{
        //    Value = s.Id.ToString(),
        //    Text = s.Name,
        //    Selected = s.Id == model.SkillLevelId
        //}).ToList();
    }

    public async Task UpdateUserSkillAsync(EditMySkillsViewModel model)
    {
        var userSkill = await unitOfWork.UserToSkillRepository.FindAsync(u => u.Id == model.Id);

        if (userSkill == null)
            return;

        userSkill.SkillId = model.SkillId;
        userSkill.SkillLevelId = model.SkillLevelId;

        unitOfWork.UserToSkillRepository.UpdateUserToSkill(userSkill);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> DeleteUserSkillAsync(int id, string userId)
    {
        var userSkill = await mySkills.GetUserSkillByIdAsync(id, userId);
        if (userSkill == null)
            return false;

        await mySkills.DeleteUserSkillAsync(userSkill);
        return true;
    }

}