using OurResumeIR.Domain.Enums;
using OurResumeIR.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> FindAsync(Expression<Func<User, bool>> predicate);
        Task<string> CreateUser(User user, string Password);
        Task<bool> UpdateUserAsync(User User);
        Task<bool> DeleteUser(string UserId);
        Task<bool> SaveChangesAsync();
        Task<bool> EmailIsExist(string email);
        User UserIsExistForLogin(string email , string password);
        Task<User> GetUserBySlug(string? slug, string? userId);
        Task<User> GetUserById(string userId);
        Task<User> GetUserByEmail(string email);
        Task<User> LoadProfileByUserId(string userId);
    }
}
