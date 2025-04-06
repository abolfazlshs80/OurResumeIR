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
        Task<string> CreateUser(User User);
        Task<bool> UpdateUser(User User);
        Task<bool> DeleteUser(string UserId);
        Task<bool> SaveChanges();
    }
}
