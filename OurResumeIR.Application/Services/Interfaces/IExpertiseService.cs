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


        #region Specialties 

        // TO DO Interface
    
        Task<List<ExperienceFormViewModel>> GetAllAsync();
        Task CreateAsync(ExperienceFormViewModel model);
        Task<ExperienceFormViewModel> GetAllExpertiseLayers(); // برای نمایش لیست تمام سطح های تخصص
        Task AddExperienceAsync(ExperienceFormViewModel model);

        #endregion

    }
}
