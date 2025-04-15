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

        public async Task AddExpertiseAsync(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Experience experience)
        {
            _context.Experiences.Remove(experience);
            _context.SaveChanges();
        }

        public Task<IQueryable<Experience>> FindAsync(Expression<Func<Experience, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Experience>> GetAllExperiencesAsync()
        {
            return await _context.Experiences
                          .Include(e => e.ExpertiseLayer)
                          .ToListAsync();
        }

        public async Task<List<ExpertiseLayer>> GetAllExpertiseLayersAsync()
        {
            return await _context.ExpertiseLayers.ToListAsync();
        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            return await _context.Experiences
                  .Include(e => e.ExpertiseLayer) // برای جلوگیری از خطای null
                  .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<Experience> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Experience experience)
        {
            _context.Experiences.Update(experience);
            await _context.SaveChangesAsync();
        }

    
    }
}
