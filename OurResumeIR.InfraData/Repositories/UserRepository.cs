using Microsoft.EntityFrameworkCore;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;

        public UserRepository( AppDbContext context) 
        {
            _context = context;
        }



 
        public async Task<IQueryable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return  _context.Users.Where(predicate).AsQueryable();
        }

        public async Task<int> CreateUser(User User)
        {
            try
            {
                _context.Add(User);
                return User.Id;
            }
            catch (Exception e)
            {
                return 0;
            }
      
            
        }

        public async Task<bool> UpdateUser(User User)
        {
            try
            {
                _context.Update(User);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public async Task<bool> DeleteUser(int UserId)
        {
            try
            {
                _context.Remove(await _context.Users.FindAsync(UserId));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
         
           
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
