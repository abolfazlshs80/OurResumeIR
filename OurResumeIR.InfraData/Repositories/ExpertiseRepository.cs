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
    public class ExpertiseRepository : IExpertiseRepository
    {
        private AppDbContext _context;
        public ExpertiseRepository(AppDbContext Context) 
        {
            _context = Context;
        }

        
        public async Task AddExpertise(Experience Expertise)
        {
            _context.Add(Expertise);
            await _context.SaveChangesAsync();
        }

        public Task AddExpertiseAsync(Experience Expertise)
        {
            throw new NotImplementedException();
        }

        public Task<Experience> DeleteExpertise(int ExpertiseId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Experience>> FindAsync(Expression<Func<Experience, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExpertiseLayer>> GetAllExpertiseLayersAsync()
        {
            return await _context.ExpertiseLayers.ToListAsync();
        }

   
        public Task<Experience> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Experience> UpdateExpertise(Experience Expertise)
        {
            throw new NotImplementedException();
        }
    }
}
