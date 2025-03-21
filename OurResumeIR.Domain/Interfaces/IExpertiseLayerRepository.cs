using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseLayerLayerRepository
{

    Task<IQueryable<ExpertiseLayer>> FindAsync(Expression<Func<ExpertiseLayer, bool>> predicate);
    Task<ExpertiseLayer> CreateExpertiseLayer(ExpertiseLayer ExpertiseLayer);
    Task<ExpertiseLayer> UpdateExpertiseLayer(ExpertiseLayer ExpertiseLayer);
    Task<ExpertiseLayer> DeleteExpertiseLayer(int ExpertiseLayerId);
    Task<ExpertiseLayer> SaveChanges();
}