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
        Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate);
        Task<IQueryable<User>> GetAll();
        Task<IQueryable<User>> GetAllDetails();
        Task<User> GetByUserId(int UserId);
        Task<User> GetUserByUserName(string UserName);
        Task<User> GetUserByEmail(string Email);
        Task<User> CreateUser(User User);
        Task<User> UpdateUser(User User);
        Task<User> DeleteUser(int UserId);
        Task<User> SaveChanges();
    }
}
