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
    public class UserExpertiseRepository : IUserExpertiseRepository
    {
        private AppDbContext _context;

        public UserExpertiseRepository( AppDbContext context) 
        {
            _context = context;
        }



 
        public async Task<IQueryable<UserExpertise>> FindAsync(Expression<Func<UserExpertise, bool>> predicate)
        {
            return  _context.UserExpertises.Where(predicate).AsQueryable();
        }

        public async Task<int> CreateUserExpertise(UserExpertise UserExpertise)
        {
            try
            {
                _context.Add(UserExpertise);
                return UserExpertise.Id;
            }
            catch (Exception e)
            {
                return 0;
            }
      
            
        }

        public async Task<bool> UpdateUserExpertise(UserExpertise UserExpertise)
        {
            try
            {
                _context.Update(UserExpertise);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public async Task<bool> DeleteUserExpertise(int UserExpertiseId)
        {
            try
            {
                _context.Remove(await _context.UserExpertises.FindAsync(UserExpertiseId));
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
