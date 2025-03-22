using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseLayerRepository
{

    Task<IQueryable<ExpertiseLayer>> FindAsync(Expression<Func<ExpertiseLayer, bool>> predicate);
    Task<int> CreateExpertiseLayer(ExpertiseLayer ExpertiseLayer);
    Task<bool> UpdateExpertiseLayer(ExpertiseLayer ExpertiseLayer);
    Task<bool> DeleteExpertiseLayer(int ExpertiseLayerId);
    Task<bool> SaveChanges();
}