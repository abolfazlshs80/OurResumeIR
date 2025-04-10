using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using ExpertiseLayerVM = OurResumeIR.Application.ViewModels.ExpertiseLayers.ExpertiseLayerVM;

namespace OurResumeIR.Application.Services.Interfaces
{
    public class ExpertiseLayersService(IExpertiseLayerRepository rep_expertiseLayer ,IMapper mapper) : IExpertiseLayersService
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

        public async  Task<ExpertiseLayerVM> GetById(int Id)
        {
            return mapper.Map<ExpertiseLayerVM>(await rep_expertiseLayer.FindAsync(a => a.Id == Id));
        }

        public async Task<bool> Update(ExpertiseLayerVM model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(ExpertiseLayerVM model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
