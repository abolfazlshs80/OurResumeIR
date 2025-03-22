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

    public class AboutRepository : IAboutMeRepository
    {
        private AppDbContext _context;
        public AboutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AboutMe aboutMe)
        {
            _context.Add(aboutMe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            _context.Remove(userId);
            await _context.SaveChangesAsync();

        }

        public async Task<AboutMe> GetByUserIdAsync(int userId)
        {
            return await _context.AboutMes.FirstOrDefaultAsync(a => a.UserId == userId);
 
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AboutMe aboutMe)
        {
             _context.Update(aboutMe);
            await _context.SaveChangesAsync();
        }
    }
}
