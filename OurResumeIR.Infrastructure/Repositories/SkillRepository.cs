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
    public class SkillRepository : ISkillRepository
    {

        private AppDbContext _context;
        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Skill>> FindAsync(Expression<Func<Skill, bool>> predicate)
        {
        return    _context.Skill.Where(predicate);
        }

        public async Task AddSkillAsync(Skill skill)
        {
            _context.Add(skill);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        public async Task<List<SkillLevel>> GetAllSkillLevelAsync()
        {
            return _context.SkillLevel.ToList();
        }

        public async Task<List<Skill>> GetAllSkillAsync()
        {
            return await _context.Skill.ToListAsync();
        }

        public async Task<List<Skill>> GetAllSkillAsyncByUserId(string userId)
        {
            return await _context.Skill.Where(_=> _.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _context.Skill.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Skill skill)
        {
            _context.Update(skill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Skill skill)
        {
            _context.Remove(skill);
            await _context.SaveChangesAsync();
        }

  

     

     
        public async Task SaveChangeAsync()
        {
           await _context.SaveChangesAsync();
        }


    }
}
