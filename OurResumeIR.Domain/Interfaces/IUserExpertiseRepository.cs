using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface IUserExpertiseRepository
{
    Task<IQueryable<UserToSkill>> FindAsync(Expression<Func<UserToSkill, bool>> predicate);
    Task<int> CreateUserExpertise(UserToSkill userToSkill);
    Task<bool> UpdateUserExpertise(UserToSkill userToSkill);
    Task<bool> DeleteUserExpertise(int UserExpertiseId);
    Task<bool> SaveChanges();
}