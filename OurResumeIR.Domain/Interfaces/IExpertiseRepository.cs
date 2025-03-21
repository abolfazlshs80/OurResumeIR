using OurResumeIR.Domain.Models;
using System.Linq.Expressions;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseRepository
{

    Task<IQueryable<Experience>> FindAsync(Expression<Func<Experience, bool>> predicate);
    Task<IQueryable<Experience>> GetAll();
    Task<IQueryable<Experience>> GetAllDetails();
    Task<Experience> GetById(int Id);
    Task<Experience> GetByExpertiseLayerId(int ExpertiseLayerId);
    Task<Experience> GetExpertiseByName(string Name);

    Task<Experience> CreateExpertise(Experience Expertise);
    Task<Experience> UpdateExpertise(Experience Expertise);
    Task<Experience> DeleteExpertise(int ExpertiseId);
    Task<Experience> SaveChanges();
}