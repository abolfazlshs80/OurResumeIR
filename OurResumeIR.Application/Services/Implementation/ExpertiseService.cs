using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Context;
using OurResumeIR.Infra.Data.Repositories;
using ExpertiseLayerVM = OurResumeIR.Application.ViewModels.ExpertiseLayers.ExpertiseLayerVM;

namespace OurResumeIR.Application.Services.Interfaces
{
   
    public class ExpertiseService(ISkillLevelRepository rep_SkillLevel, 
        IMapper mapper ,
        ISkillRepository rep_Skill) 
        : IExpertiseService
    {
      
        
        #region Specialties Layer
        public async Task<List<ExpertiseLayerVM>> GetAll()
        {
            try
            {
                var list = (await rep_SkillLevel.FindAsync(a => a.Id != 0)).ToList();
                return mapper.Map<List<ExpertiseLayerVM>>(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<ExpertiseLayerVM> GetById(int Id)
        {
            return mapper.Map<ExpertiseLayerVM>((await rep_SkillLevel.FindAsync(a => a.Id == Id)).FirstOrDefault());
        }

        public async Task<bool> Update(UpdateExpertiseLayerVM model)
        {
            var newModel = mapper.Map<SkillLevel>(model);
            bool status = await rep_SkillLevel.UpdateSkillLevelLevel(newModel);
            await rep_SkillLevel.SaveChanges();

            return status;
        }

        public async Task<bool> Create(CreateExpertiseLayerVM model)
        {
            var newModel = mapper.Map<SkillLevel>(model);
            int id = await rep_SkillLevel.CreateSkillLevelLevel(newModel);
            await rep_SkillLevel.SaveChanges();
            if (newModel.Id != 0)
                return true;

            return false;

        }

        public async Task<bool> Delete(int Id)
        {
            var status = await rep_SkillLevel.DeleteSkillLevelLevel(Id);
            await rep_SkillLevel.SaveChanges();
            return status;

        }


        #endregion



        #region Specialties 

        public Task<List<ExperienceFormViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(ExperienceFormViewModel model)
        {
            Skill newSkill = new Skill()
            {
                Name = model.Name,
                //ExpertiseLayerId = model.ExpertiseLayerId,
            };

     await       rep_Skill.AddSkillAsync(newSkill);
           await rep_Skill.SaveChangesAsync();
           
        }

        public async Task<ExperienceFormViewModel> GetAllExperiencesLayerAsync()
        {
            var layers = await rep_Skill.GetAllSkillLevelAsync();
            return new ExperienceFormViewModel
            {
                ExpertiseLayerOptions = layers.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                }).ToList(),
            };
        }

        public async Task AddExperienceAsync(ExperienceFormViewModel model)
        {
            var experience = new Skill
            {
                Name = model.Name,
                //ExpertiseLayerId = model.ExpertiseLayerId 
            };

            await rep_Skill.AddSkillAsync(experience);
        }

        public async Task<List<ExperienceListViewModel>> GetAllExperiencesAsync()
        {
            var experiences = await rep_Skill.GetAllSkillAsync();

            //return experiences.Select(e => new ExperienceListViewModel
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    ExpertiseLayerTitle = e.SkillLevel.Name
            //}).ToList();
            return mapper.Map<List<ExperienceListViewModel>>(experiences);
        }

        //public Task<ExperienceFormViewModel> GetExperienceByIdAsync(int id)
        //{
        //    //return await _repository.GetExperienceFormByIdAsync(id);
        //    throw new NotImplementedException();
        //}

        public async Task<ExperienceFormViewModel> GetExperienceFormByIdAsync(int id)
        {
            var experience = await rep_Skill.GetByIdAsync(id);
            var layers = await rep_Skill.GetAllSkillLevelAsync();

            if (experience == null)
                return null;

            return new ExperienceFormViewModel
            {
                Id = experience.Id,
                Name = experience.Name,
                //ExpertiseLayerId = experience.ExpertiseLayerId,
                ExpertiseLayerOptions = layers.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                }).ToList()
            };
        }

        public async Task<bool> UpdateExperienceAsync(ExperienceFormViewModel model)
        {
            var experience = await rep_Skill.GetByIdAsync(model.Id);
            if (experience == null)
                return false;

            experience.Name = model.Name;
            //experience.ExpertiseLayerId = model.ExpertiseLayerId;

            await rep_Skill.UpdateAsync(experience);
            return true;
        }

        public async Task<bool> DeleteExperienceAsync(int id)
        {
            var experience = await rep_Skill.GetByIdAsync(id);
            if (experience == null)
                return false;

            await rep_Skill.DeleteAsync(experience);
            return true;
        }


        #endregion


    }


}
