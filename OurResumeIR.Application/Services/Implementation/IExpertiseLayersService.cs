using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Interfaces
{
    public class ExpertiseLayersService(IExpertiseLayerRepository rep_expertiseLayer) : IExpertiseLayersService
    {
        public Task<List<ExpertiseLayerVM>> GetAll()
        {
           
        }

        public Task<ExpertiseLayerVM> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ExpertiseLayerVM model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(ExpertiseLayerVM model)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExpertiseLayerVM>> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
