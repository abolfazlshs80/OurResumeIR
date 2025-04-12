using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Domain.Models;
using ExpertiseLayerVM = OurResumeIR.Application.ViewModels.ExpertiseLayers.ExpertiseLayerVM;

namespace OurResumeIR.Application.Services.Interfaces
{
    public  interface IExpertiseService
    {
        #region Specialties Layer

        Task<List<ExpertiseLayerVM>> GetAll();
        Task<ExpertiseLayerVM> GetById(int Id);
        Task<bool> Update(UpdateExpertiseLayerVM model);
        Task<bool> Create(CreateExpertiseLayerVM model);
        Task<bool> Delete(int Id);

        #endregion




    }
}
