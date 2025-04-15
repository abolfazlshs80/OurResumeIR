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
    public class MyExperienceRepository : IMyExperiencesRepository
    {

        private AppDbContext _context;
        public MyExperienceRepository() 
        {

        }
        public async Task AddExperienceAsync(Skill skill)
        {
            _context.Add(skill);
            await _context.SaveChangesAsync();
        }

        public Task DeleteExperienceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeletExperienceAsync(Skill skill)
        {
            _context.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<History>> GetAllExperiencesAsync()
        {
            return _context.History.AsQueryable();
        }

        public Task<History> GetExperienceByIdAsync(int id)
        {
            return _context.History.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangeAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task UpdateExperienceAsync(Skill skill)
        {
            _context.Update(skill);
            await SaveChangeAsync();
        }
    }
}
