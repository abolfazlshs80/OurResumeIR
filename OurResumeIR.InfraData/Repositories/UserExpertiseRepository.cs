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
                _context.Add(UserExpertise);
                return UserExpertise.Id;
       
      
            
        }

        public async Task<bool> UpdateUserExpertise(UserExpertise UserExpertise)
        {
                _context.Update(UserExpertise);
                return true;
      
           
        }

        public async Task<bool> DeleteUserExpertise(int UserExpertiseId)
        {
                _context.Remove(await _context.UserExpertises.FindAsync(UserExpertiseId));
                return true;
          
           
        }

        public async Task<bool> SaveChanges()
        {
                await _context.SaveChangesAsync();
                return true;
      
        }
    }
}
