using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface IUserExpertiseRepository
{
    Task<IQueryable<UserExpertise>> FindAsync(Expression<Func<UserExpertise, bool>> predicate);
    Task<int> CreateUserExpertise(UserExpertise UserExpertise);
    Task<bool> UpdateUserExpertise(UserExpertise UserExpertise);
    Task<bool> DeleteUserExpertise(int UserExpertiseId);
    Task<bool> SaveChanges();
}