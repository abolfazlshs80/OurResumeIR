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
        public async Task AddExperienceAsync(Experience experience)
        {
            _context.Add(experience);
            await _context.SaveChangesAsync();
        }

        public Task DeleteExperienceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeletExperienceAsync(Experience experience)
        {
            _context.Remove(experience);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<MyExperiences>> GetAllExperiencesAsync()
        {
            return _context.MyExperiences.AsQueryable();
        }

        public Task<MyExperiences> GetExperienceByIdAsync(int id)
        {
            return _context.MyExperiences.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangeAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task UpdateExperienceAsync(Experience experience)
        {
            _context.Update(experience);
            await SaveChangeAsync();
        }
    }
}
