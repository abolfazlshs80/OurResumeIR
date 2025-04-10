using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Domain.Models;
using ExpertiseLayerVM = OurResumeIR.Application.ViewModels.ExpertiseLayers.ExpertiseLayerVM;

namespace OurResumeIR.Application.Services.Interfaces
{
    public  interface IExpertiseLayersService
    {
        Task<List<ExpertiseLayerVM>> GetAll();
        Task<ExpertiseLayerVM> GetById(int Id);
        Task<bool> Update(ExpertiseLayerVM model);
        Task<bool> Create(ExpertiseLayerVM model);
        Task<bool> Delete(int Id);
    }
}
