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


        public async Task AddExpertise(Skill Expertise)
        {
            _context.Add(Expertise);
            await _context.SaveChangesAsync();
        }

        public async Task AddExpertiseAsync(Skill skill)
        {
            _context.Skill.Add(skill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Skill skill)
        {
            _context.Skill.Remove(skill);
            _context.SaveChanges();
        }

        public Task<IQueryable<Skill>> FindAsync(Expression<Func<Skill, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Skill>> GetAllExperiencesAsync()
        {
            return await _context.Skill
                          //.Include(e => e.SkillLevel)
                          .ToListAsync();
        }

        public async Task<List<SkillLevel>> GetAllExpertiseLayersAsync()
        {
            return await _context.SkillLevel.ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _context.Skill
                  //.Include(e => e.SkillLevel) // برای جلوگیری از خطای null
                  .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<Skill> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Skill skill)
        {
            _context.Skill.Update(skill);
            await _context.SaveChangesAsync();
        }

    
    }
}
