using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;


namespace OurResumeIR.Application.Services.Interfaces
{

    public class SkillService(IUnitOfWork unitOfWork,
        IMapper mapper
        )
        : ISkillService
    {




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

            await unitOfWork.SkillRepository.AddSkillAsync(newSkill);
            await unitOfWork.SkillRepository.SaveChangesAsync();

        }

        public async Task<SkillFormViewModel> GetAllSkillLevelAsync()
        {
            var layers = await unitOfWork.SkillRepository.GetAllSkillLevelAsync();
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

            await unitOfWork.SkillRepository.AddSkillAsync(experience);
        }

        public async Task<List<SkillListViewModel>> GetAllSkillAsync()
        {
            var experiences = await unitOfWork.SkillRepository.GetAllSkillAsync();

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
            var experience = await unitOfWork.SkillRepository.GetByIdAsync(id);
            var layers = await unitOfWork.SkillRepository.GetAllSkillLevelAsync();

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
            var experience = await unitOfWork.SkillRepository.GetByIdAsync(model.Id);
            if (experience == null)
                return false;

            experience.Name = model.Name;


            await unitOfWork.SkillRepository.UpdateAsync(experience);
            return true;
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var experience = await unitOfWork.SkillRepository.GetByIdAsync(id);
            if (experience == null)
                return false;

            await unitOfWork.SkillRepository.DeleteAsync(experience);
            return true;
        }


        #endregion


   


    }
}
