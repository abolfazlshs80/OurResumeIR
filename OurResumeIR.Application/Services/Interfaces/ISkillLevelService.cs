using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Application.ViewModels.SkillLevel;

namespace OurResumeIR.Application.Services.Interfaces;

public interface ISkillLevelService
{
    Task<List<SkillLevelVM>> GetAll();
    Task<List<SkillLevelVM>> GetAll(string userId);
    Task<SkillLevelVM> GetById(int Id);
    Task<bool> Update(UpdateSkillLevelVM model);
    Task<bool> Create(CreateSkillLevelVM model);
    Task<bool> Delete(int Id, string userId);
}