using OurResumeIR.Domain.Models;
using System.Linq.Expressions;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseRepository
{

    Task<IQueryable<Expertise>> FindAsync(Expression<Func<Expertise, bool>> predicate);
    Task<Expertise> CreateExpertise(Expertise Expertise);
    Task<Expertise> UpdateExpertise(Expertise Expertise);
    Task<Expertise> DeleteExpertise(int ExpertiseId);
    Task<Expertise> SaveChanges();
}