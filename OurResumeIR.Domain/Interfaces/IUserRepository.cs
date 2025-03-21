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
        Task<User> CreateUser(User User);
        Task<User> UpdateUser(User User);
        Task<User> DeleteUser(int UserId);
        Task<User> SaveChanges();
    }
}
