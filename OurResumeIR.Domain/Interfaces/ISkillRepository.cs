using OurResumeIR.Domain.Models;
using System.Linq.Expressions;

namespace OurResumeIR.Domain.Interfaces;

public interface ISkillRepository
{

    Task<IQueryable<Skill>> FindAsync(Expression<Func<Skill, bool>> predicate);
    Task AddSkillAsync(Skill skill);
    Task SaveChangesAsync();
    Task<List<SkillLevel>> GetAllSkillLevelAsync();
    Task<List<Skill>> GetAllSkillAsync();
    Task<Skill> GetByIdAsync(int id);
    Task UpdateAsync(Skill skill);
    Task DeleteAsync(Skill skill);



}