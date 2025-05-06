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
using Microsoft.EntityFrameworkCore.Internal;

namespace OurResumeIR.Infra.Data.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private AppDbContext _context;
        public HistoryRepository(AppDbContext Context)
        {
            _context = Context;
        }


        public async Task<IQueryable<History>> GetAllHistoryAsync()
        {
            return _context.History.AsQueryable();
        }

        public async Task<History> GetHistoryByIdAsync(int id)
        {
            return await _context.History.FindAsync(id);
        }

        public async Task AddHistoryAsync(History History)
        {
            await _context.History.AddAsync(History);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHistoryAsync(History History)
        {
            _context.History.Update(History);
            await _context.SaveChangesAsync();
        }

        public async Task DeletHistoryAsync(History History)
        {
            _context.History.Remove(History);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHistoryByIdAsync(int id)
        {
            _context.History.Remove(await GetHistoryByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangeAsync()
        {
            _context.SaveChanges();
        }

        public Task<History> GetHistoryByIdAndUserIdAsync(int id, string userId)
        {
            return _context.History.FirstOrDefaultAsync(h => h.Id == id && h.UserId == userId);
        }
    }
}
