using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface ISkillService
    {
        #region Specialties Layer

        Task<List<SkillLevelVM>> GetAll();
        Task<SkillLevelVM> GetById(int Id);
        Task<bool> Update(UpdateSkillLevelVM model);
        Task<bool> Create(CreateSkillLevelVM model);
        Task<bool> Delete(int Id);

        #endregion


        #region Specialties 
           

        Task<List<SkillFormViewModel>> GetAllAsync();
        Task CreateAsync(SkillFormViewModel model);
        Task<SkillFormViewModel> GetAllSkillLevelAsync(); // برای نمایش لیست تمام سطح های تخصص
        Task AddSkillAsync(SkillFormViewModel model);
        Task<List<SkillListViewModel>> GetAllSkillAsync();
        Task<SkillFormViewModel> GetSkillFormByIdAsync(int id);
        Task<bool> UpdateSkillAsync(SkillFormViewModel model);
        Task<bool> DeleteSkillAsync(int id);

        #endregion


        #region My Skills
        Task<List<MySkillsForListViewModel>> GetAllSkillAndSkillLevelForViewAsync(string userId);
        Task<AddMySkillsViewModel> GetAllSkillAndSkillLevelForDropDownAsync();
        Task<bool> AddMySkillAsync(AddMySkillsViewModel model , string userId);
        EditMySkillsViewModel GetSkillForEditAsync(int userToSkillId ,out  List<SelectListItem> skill , out List<SelectListItem> skillLevel);
        Task FillDropDownsForEditViewModel(EditMySkillsViewModel model);
        Task UpdateUserSkillAsync(EditMySkillsViewModel model);
        Task<bool> DeleteUserSkillAsync(int id, string userId);
        Task FillDropDownsAsync(AddMySkillsViewModel model);
        #endregion

    }
}
