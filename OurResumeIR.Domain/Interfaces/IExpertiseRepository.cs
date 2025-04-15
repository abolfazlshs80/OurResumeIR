using OurResumeIR.Domain.Models;
using System.Linq.Expressions;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseRepository
{

    Task<IQueryable<Skill>> FindAsync(Expression<Func<Skill, bool>> predicate);
    Task AddExpertiseAsync(Skill skill);
    Task<Skill> SaveChangesAsync();
    Task<List<SkillLevel>> GetAllExpertiseLayersAsync();
    Task<List<Skill>> GetAllExperiencesAsync();
    Task<Skill> GetByIdAsync(int id);
    Task UpdateAsync(Skill skill);
    Task DeleteAsync(Skill skill);



}