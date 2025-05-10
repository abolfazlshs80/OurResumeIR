using Microsoft.EntityFrameworkCore;
using OurResumeIR.Domain.Enums;
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

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IQueryable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate).AsQueryable();
        }

        public async Task<string> CreateUser(User User)
        {
            _context.Add(User);
            return "";
        }

        public async Task<bool> UpdateUserAsync(User User)
        {
            _context.Update(User);
            return true;
        }

        public async Task<bool> DeleteUser(string UserId)
        {
            _context.Remove(await _context.Users.FindAsync(UserId));
            return true;

        }

        public async Task<bool> SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmailIsExist(string email)
        {
            return _context.Users.Where(x => x.Email == email).Any();
        }
        public async Task<User> GetUserBySlug(string? slug)
        {
            var user = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(slug))
                user = user.Where(x => x.Slug.Equals(slug)).AsQueryable();



            return await user.Include(a => a.AboutMe)
               .Include(a => a.UserToSkill)
               .ThenInclude(a => a.SkillLevel)
               .Include(a => a.UserToSkill)
               .ThenInclude(a => a.Skill)

               .Include(a => a.Documents)
               .Include(a => a.History)
               .Include(a => a.Blog)

               .FirstOrDefaultAsync();
        }
        public User UserIsExistForLogin(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }

        public async Task<User> GetUserById(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
