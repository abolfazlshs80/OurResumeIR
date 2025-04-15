using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Interfaces
{
    public  interface IExpertiseService
    {
        #region Specialties Layer

        Task<List<SkillLevelVM>> GetAll();
        Task<SkillLevelVM> GetById(int Id);
        Task<bool> Update(UpdateSkillLevelVM model);
        Task<bool> Create(CreateSkillLevelVM model);
        Task<bool> Delete(int Id);

        #endregion


        #region Specialties 

        // TO DO Interface
    
        Task<List<SkillFormViewModel>> GetAllAsync();
        Task CreateAsync(SkillFormViewModel model);
        Task<SkillFormViewModel> GetAllExperiencesLayerAsync(); // برای نمایش لیست تمام سطح های تخصص
        Task AddExperienceAsync(SkillFormViewModel model);
        Task<List<SkillListViewModel>> GetAllExperiencesAsync();
        Task<SkillFormViewModel> GetExperienceFormByIdAsync(int id);
        Task<bool> UpdateExperienceAsync(SkillFormViewModel model);
        Task<bool> DeleteExperienceAsync(int id);

        #endregion

    }
}
