using OurResumeIR.Domain.Models;
using System.Linq.Expressions;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseRepository
{

    Task<IEnumerable<Expertise>> FindAsync(Expression<Func<Expertise, bool>> predicate);
    Task<IQueryable<Expertise>> GetAll();
    Task<IQueryable<Expertise>> GetAllDetails();
    Task<Expertise> GetById(int Id);
    Task<Expertise> GetByExpertiseLayerId(int ExpertiseLayerId);
    Task<Expertise> GetExpertiseByName(string Name);

    Task<Expertise> CreateExpertise(Expertise Expertise);
    Task<Expertise> UpdateExpertise(Expertise Expertise);
    Task<Expertise> DeleteExpertise(int ExpertiseId);
    Task<Expertise> SaveChanges();
}