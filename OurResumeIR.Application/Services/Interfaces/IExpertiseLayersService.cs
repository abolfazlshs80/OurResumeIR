using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Interfaces
{
    public  interface IExpertiseLayersService
    {
        Task<List<ExpertiseLayerVM>> GetAll();
        Task<ExpertiseLayerVM> GetById(int Id);
        Task<bool> Update(ExpertiseLayerVM model);
        Task<bool> Create(ExpertiseLayerVM model);
        Task<List<ExpertiseLayerVM>> Delete(int Id);
    }
}
