using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface ISkillLevelRepository
{

    Task<IQueryable<SkillLevel>> FindAsync(Expression<Func<SkillLevel, bool>> predicate);
    Task<int> CreateSkillLevelLevel(SkillLevel skillLevel);
    Task<bool> UpdateSkillLevelLevel(SkillLevel skillLevel);
    Task<bool> DeleteSkillLevelLevel(int SkillLevelLevelId);
    Task<SkillLevel> GetSkillLevelById(int SkillLevelLevelId);
    Task<List<SkillLevel>> GetAllSkillLevelAsync();
    Task<List<SkillLevel>> GetAllSkillLevelAsync(string userId);
    Task<bool> SaveChanges();
}