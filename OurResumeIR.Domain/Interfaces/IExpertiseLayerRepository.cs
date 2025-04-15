using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseLayerRepository
{

    Task<IQueryable<SkillLevel>> FindAsync(Expression<Func<SkillLevel, bool>> predicate);
    Task<int> CreateExpertiseLayer(SkillLevel skillLevel);
    Task<bool> UpdateExpertiseLayer(SkillLevel skillLevel);
    Task<bool> DeleteExpertiseLayer(int ExpertiseLayerId);
    Task<bool> SaveChanges();
}