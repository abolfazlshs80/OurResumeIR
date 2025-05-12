using Microsoft.EntityFrameworkCore;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
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
    public class SkillLevelRepository : ISkillLevelRepository
    {
        private AppDbContext _context;

        public SkillLevelRepository( AppDbContext context) 
        {
            _context = context;
        }



 
        public async Task<IQueryable<SkillLevel>> FindAsync(Expression<Func<SkillLevel, bool>> predicate)
        {
            return  _context.SkillLevel.Where(predicate).AsQueryable();
        }

        public async Task<int> CreateSkillLevelLevel(SkillLevel skillLevel)
        {
            _context.Add(skillLevel);
            return skillLevel.Id;


        }

        public async Task<bool> UpdateSkillLevelLevel(SkillLevel skillLevel)
        {
            _context.Update(skillLevel);
            return true;
        }

        public async Task<bool> DeleteSkillLevelLevel(int SkillLevelId)
        {
            _context.Remove(await _context.SkillLevel.FindAsync(SkillLevelId));
            return true;
        }

        public async Task<SkillLevel> GetSkillLevelById(int SkillLevelLevelId)
        {
            return await _context.SkillLevel.Where(a=>a.Id.Equals(SkillLevelLevelId)).FirstOrDefaultAsync();
        }


        public async Task<List<SkillLevel>> GetAllSkillLevelAsync(string userId)
        {
            return await _context.SkillLevel.Where(_=>_.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
                await _context.SaveChangesAsync();
                return true;
 
            
        }

        public async Task<List<SkillLevel>> GetAllSkillLevelAsync()
        {
            return await _context.SkillLevel.ToListAsync();
        }
    }
}
