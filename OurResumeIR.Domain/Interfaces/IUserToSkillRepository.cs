using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface IUserToSkillRepository
{
    Task<UserToSkill> FindAsync(Expression<Func<UserToSkill, bool>> predicate);
    Task<int> CreateUserToSkill(UserToSkill userToSkill);
    Task<bool> UpdateUserToSkill(UserToSkill userToSkill);
    Task<bool> DeleteUserToSkill(int UserToSkillId);
  
    Task<bool> SaveChanges();
}