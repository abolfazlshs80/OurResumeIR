using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;

namespace OurResumeIR.Application.Services.Interfaces;

public interface ISkillLevelService
{
    Task<List<SkillLevelVM>> GetAll();
    Task<SkillLevelVM> GetById(int Id);
    Task<bool> Update(UpdateSkillLevelVM model);
    Task<bool> Create(CreateSkillLevelVM model);
    Task<bool> Delete(int Id);
}