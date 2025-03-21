using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface IUserExpertiseRepository
{
    Task<IQueryable<UserExpertise>> FindAsync(Expression<Func<UserExpertise, bool>> predicate);
    Task<UserExpertise> CreateUserExpertise(UserExpertise UserExpertise);
    Task<UserExpertise> UpdateUserExpertise(UserExpertise UserExpertise);
    Task<UserExpertise> DeleteUserExpertise(int UserExpertiseId);
    Task<UserExpertise> SaveChanges();
}