using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Context;
using OurResumeIR.Infra.Data.Repositories;

namespace OurResumeIR.Application.Services.Interfaces
{

    public class SkillService(IUnitOfWork unitOfWork,
        IMapper mapper,
        ISkillRepository rep_Skill, IMySkillsRepository mySkills)
        : ISkillService
    {


        #region Specialties Layer
        public async Task<List<SkillLevelVM>> GetAll()
        {
            var rep_SkillLevel = unitOfWork.SkillLevelRepository;
            try
            {
                var list = (await rep_SkillLevel.FindAsync(a => a.Id != 0)).ToList();
                return mapper.Map<List<SkillLevelVM>>(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<SkillLevelVM> GetById(int Id)
        {
            var rep_SkillLevel = unitOfWork.SkillLevelRepository;
            return mapper.Map<SkillLevelVM>((await rep_SkillLevel.FindAsync(a => a.Id == Id)).FirstOrDefault());
        }

        public async Task<bool> Update(UpdateSkillLevelVM model)
        {
            var rep_SkillLevel = unitOfWork.SkillLevelRepository;
            var newModel = mapper.Map<SkillLevel>(model);
            bool status = await rep_SkillLevel.UpdateSkillLevelLevel(newModel);
            await rep_SkillLevel.SaveChanges();

            return status;
        }

        public async Task<bool> Create(CreateSkillLevelVM model)
        {
            var rep_SkillLevel = unitOfWork.SkillLevelRepository;
            var newModel = mapper.Map<SkillLevel>(model);
            int id = await rep_SkillLevel.CreateSkillLevelLevel(newModel);
            await rep_SkillLevel.SaveChanges();
            if (newModel.Id != 0)
                return true;

            return false;

        }

        public async Task<bool> Delete(int Id)
        {
            var rep_SkillLevel = unitOfWork.SkillLevelRepository;
            var status = await rep_SkillLevel.DeleteSkillLevelLevel(Id);
            await rep_SkillLevel.SaveChanges();
            return status;

        }


        #endregion



        #region Specialties 

        public Task<List<SkillFormViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(SkillFormViewModel model)
        {
            Skill newSkill = new Skill()
            {
                Name = model.Name,

            };

            await rep_Skill.AddSkillAsync(newSkill);
            await rep_Skill.SaveChangesAsync();

        }

        public async Task<SkillFormViewModel> GetAllSkillLevelAsync()
        {
            var layers = await rep_Skill.GetAllSkillLevelAsync();
            return new SkillFormViewModel
            {
                ExpertiseLayerOptions = layers.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                }).ToList(),
            };
        }

        public async Task AddSkillAsync(SkillFormViewModel model)
        {
            var experience = new Skill
            {
                Name = model.Name,
            };

            await rep_Skill.AddSkillAsync(experience);
        }

        public async Task<List<SkillListViewModel>> GetAllSkillAsync()
        {
            var experiences = await rep_Skill.GetAllSkillAsync();

            //return experiences.Select(e => new SkillListViewModel
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    ExpertiseLayerTitle = e.SkillLevel.Name
            //}).ToList();
            return mapper.Map<List<SkillListViewModel>>(experiences);
        }



        public async Task<SkillFormViewModel> GetSkillFormByIdAsync(int id)
        {
            var experience = await rep_Skill.GetByIdAsync(id);
            var layers = await rep_Skill.GetAllSkillLevelAsync();

            if (experience == null)
                return null;

            return new SkillFormViewModel
            {
                Id = experience.Id,
                Name = experience.Name,
                ExpertiseLayerOptions = layers.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                }).ToList()
            };
        }

        public async Task<bool> UpdateSkillAsync(SkillFormViewModel model)
        {
            var experience = await rep_Skill.GetByIdAsync(model.Id);
            if (experience == null)
                return false;

            experience.Name = model.Name;


            await rep_Skill.UpdateAsync(experience);
            return true;
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var experience = await rep_Skill.GetByIdAsync(id);
            if (experience == null)
                return false;

            await rep_Skill.DeleteAsync(experience);
            return true;
        }


        #endregion


        #region My Skills

        public async Task<List<MySkillsForListViewModel>> GetAllSkillAndSkillLevelForViewAsync(string userId)
        {
            var userSkills = await mySkills.GetAllSkillAndSkillLevelAsync(userId);

            return userSkills.Select(x => new MySkillsForListViewModel
            {
                Id = x.Id,
                SkillName = x.Skill.Name,
                SkillLevelName = x.SkillLevel.Name,


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

        public async Task<bool> AddMySkillAsync(AddMySkillsViewModel model , string userId)
        {
            // چک کردن اینکه تخصص و سطح تخصص وارد شده برای کاربر تکراری است؟
            var isDuplicate = await mySkills.IsDuplicateSkillAsync(userId, model.SelectedSkillId, model.SelectedSkillLevelId);
            if (isDuplicate)
                return false;

            var UserSkills = new UserToSkill
            {
                UserId = userId,
                SkillId = model.SelectedSkillId,
                SkillLevelId = model.SelectedSkillLevelId,
            
            };

            await mySkills.AddMySkillsAsync(UserSkills);
            return true;
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

        public async Task FillDropDownsAsync(AddMySkillsViewModel model)
        {
            var skills = await unitOfWork.SkillRepository.GetAllSkillAsync();
            var skillLevels = await unitOfWork.SkillRepository.GetAllSkillLevelAsync();

            model.Skills = skills.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();

            model.SkillLevels = skillLevels.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
        }


        #endregion


    }


}
