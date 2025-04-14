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
   
    public class ExpertiseService(IExpertiseLayerRepository rep_expertiseLayer, 
        IMapper mapper ,
        IExpertiseRepository expertise) 
        : IExpertiseService
    {
      
        
        #region Specialties Layer
        public async Task<List<ExpertiseLayerVM>> GetAll()
        {
            try
            {
                var list = (await rep_expertiseLayer.FindAsync(a => a.Id != 0)).ToList();
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
            return mapper.Map<ExpertiseLayerVM>((await rep_expertiseLayer.FindAsync(a => a.Id == Id)).FirstOrDefault());
        }

        public async Task<bool> Update(UpdateExpertiseLayerVM model)
        {
            var newModel = mapper.Map<ExpertiseLayer>(model);
            bool status = await rep_expertiseLayer.UpdateExpertiseLayer(newModel);
            await rep_expertiseLayer.SaveChanges();

            return status;
        }

        public async Task<bool> Create(CreateExpertiseLayerVM model)
        {
            var newModel = mapper.Map<ExpertiseLayer>(model);
            int id = await rep_expertiseLayer.CreateExpertiseLayer(newModel);
            await rep_expertiseLayer.SaveChanges();
            if (newModel.Id != 0)
                return true;

            return false;

        }

        public async Task<bool> Delete(int Id)
        {
            var status = await rep_expertiseLayer.DeleteExpertiseLayer(Id);
            await rep_expertiseLayer.SaveChanges();
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
            Experience newExperience = new Experience()
            {
                Name = model.Name,
                ExpertiseLayerId = model.ExpertiseLayerId,
            };

            expertise.AddExpertiseAsync(newExperience);
           await expertise.SaveChangesAsync();
           
        }

        public async Task<ExperienceFormViewModel> GetAllExperiencesLayerAsync()
        {
            var layers = await expertise.GetAllExpertiseLayersAsync();
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
            var experience = new Experience
            {
                Name = model.Name,
                ExpertiseLayerId = model.ExpertiseLayerId 
            };

            await expertise.AddExpertiseAsync(experience);
        }

        public async Task<List<ExperienceListViewModel>> GetAllExperiencesAsync()
        {
            var experiences = await expertise.GetAllExperiencesAsync();

            //return experiences.Select(e => new ExperienceListViewModel
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    ExpertiseLayerTitle = e.ExpertiseLayer.Name
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
            var experience = await expertise.GetByIdAsync(id);
            var layers = await expertise.GetAllExpertiseLayersAsync();

            if (experience == null)
                return null;

            return new ExperienceFormViewModel
            {
                Id = experience.Id,
                Name = experience.Name,
                ExpertiseLayerId = experience.ExpertiseLayerId,
                ExpertiseLayerOptions = layers.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                }).ToList()
            };
        }


        #endregion


    }


}
