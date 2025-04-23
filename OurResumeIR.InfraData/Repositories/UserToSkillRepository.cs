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
    public class UserToSkillRepository : IUserToSkillRepository
    {
        private AppDbContext _context;

        public UserToSkillRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<UserToSkill?> FindAsync(Expression<Func<UserToSkill, bool>> predicate)
        {
            var result = await _context.UserToSkill
               .Include(u => u.Skill)
               .Include(u => u.SkillLevel)
               .FirstOrDefaultAsync(predicate);
            return result;
        }

        public async Task<int> CreateUserToSkill(UserToSkill userToSkill)
        {
            _context.Add(userToSkill);
            return userToSkill.Id;

        }

        public async Task<bool> UpdateUserToSkill(UserToSkill userToSkill)
        {
            _context.Update(userToSkill);
            return true;
        }

        public async Task<bool> DeleteUserToSkill(int UserToSkillId)
        {
            _context.Remove(await _context.UserToSkill.FindAsync(UserToSkillId));
            return true;
        }

        public async Task<bool> SaveChanges()
        {
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task DeleteUserSkillAsync(UserToSkill userSkill)
        {
            _context.UserToSkill.Remove(userSkill);
            await _context.SaveChangesAsync();
        }
    }
}
