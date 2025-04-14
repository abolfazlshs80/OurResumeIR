using OurResumeIR.Domain.Models;
using System.Linq.Expressions;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseRepository 
{

    Task<IQueryable<Experience>> FindAsync(Expression<Func<Experience, bool>> predicate);
    Task AddExpertiseAsync(Experience experience);
    Task<Experience> UpdateExpertise(Experience Expertise);
    Task<Experience> DeleteExpertise(int ExpertiseId);
    Task<Experience> SaveChangesAsync();
    Task<List<ExpertiseLayer>> GetAllExpertiseLayersAsync();
    Task<List<Experience>> GetAllExperiencesAsync();
    Task<Experience> GetByIdAsync(int id);


}