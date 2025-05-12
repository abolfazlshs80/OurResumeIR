using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface ISkillService
    {
     

        Task<List<SkillFormViewModel>> GetAllAsync();
        Task<List<SkillListViewModel>> GetAllAsyncByUserId(string userId);
        Task CreateAsync(SkillFormViewModel model);
        Task<SkillFormViewModel> GetAllSkillLevelAsync(); // برای نمایش لیست تمام سطح های تخصص
        Task AddSkillAsync(SkillFormViewModel model);
        Task<List<SkillListViewModel>> GetAllSkillAsync();
        Task<SkillFormViewModel> GetSkillFormByIdAsync(int id);
        Task<bool> UpdateSkillAsync(SkillFormViewModel model);
        Task<bool> DeleteSkillAsync(int id,string userId);

   


        

    }
}
