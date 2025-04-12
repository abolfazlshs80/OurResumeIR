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
        private AppDbContext _Context;
        public ExpertiseRepository(AppDbContext Context) 
        {
            _Context = Context;
        }

        
        public async Task AddExpertise(Experience Expertise)
        {
            _Context.Add(Expertise);
            await _Context.SaveChangesAsync();
        }

        public Task<Experience> DeleteExpertise(int ExpertiseId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Experience>> FindAsync(Expression<Func<Experience, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Experience> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<Experience> UpdateExpertise(Experience Expertise)
        {
            throw new NotImplementedException();
        }
    }
}
