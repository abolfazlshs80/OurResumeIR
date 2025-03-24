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
    public class ExpertiseLayerRepository : IExpertiseLayerRepository
    {
        private AppDbContext _context;

        public ExpertiseLayerRepository( AppDbContext context) 
        {
            _context = context;
        }



 
        public async Task<IQueryable<ExpertiseLayer>> FindAsync(Expression<Func<ExpertiseLayer, bool>> predicate)
        {
            return  _context.ExpertiseLayers.Where(predicate).AsQueryable();
        }

        public async Task<int> CreateExpertiseLayer(ExpertiseLayer ExpertiseLayer)
        {
                _context.Add(ExpertiseLayer);
                return ExpertiseLayer.Id;
        
      
            
        }

        public async Task<bool> UpdateExpertiseLayer(ExpertiseLayer ExpertiseLayer)
        {
                _context.Update(ExpertiseLayer);
                return true;
         
           
        }

        public async Task<bool> DeleteExpertiseLayer(int ExpertiseLayerId)
        {
                _context.Remove(await _context.ExpertiseLayers.FindAsync(ExpertiseLayerId));
                return true;
          
           
        }

        public async Task<bool> SaveChanges()
        {
                await _context.SaveChangesAsync();
                return true;
 
            
        }
    }
}
