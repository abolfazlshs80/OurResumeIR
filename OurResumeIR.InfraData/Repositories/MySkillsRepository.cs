using Microsoft.EntityFrameworkCore;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Data.Repositories
{
    public class MySkillsRepository : IMySkillsRepository
    {
        private AppDbContext _Context;

        public MySkillsRepository(AppDbContext context)
        {
            _Context = context;
        }
        public async Task<List<UserToSkill>> GetAllSkillAndSkillLevelAsync(string userId)
        {
            return await _Context.UserToSkill
                .Include(u => u.Skill)
                .Include(u => u.SkillLevel)
                .Where(u => u.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<UserToSkill>> GetAllSkillAndSkillLevelAsync()
        {
             var result = await _Context.UserToSkill
                .Include(u => u.Skill)
                .Include(u => u.SkillLevel)
                .ToListAsync(); 
            return result;
        }
    }
}
