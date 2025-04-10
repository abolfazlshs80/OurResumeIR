using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using ExpertiseLayerVM = OurResumeIR.Application.ViewModels.ExpertiseLayers.ExpertiseLayerVM;

namespace OurResumeIR.Application.Services.Interfaces
{
    public class ExpertiseLayersService(IExpertiseLayerRepository rep_expertiseLayer, IMapper mapper) : IExpertiseLayersService
    {
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
            return mapper.Map<ExpertiseLayerVM>(await rep_expertiseLayer.FindAsync(a => a.Id == Id));
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
    }
}
