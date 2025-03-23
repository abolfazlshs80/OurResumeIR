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
    public class DocumentRepository : IDocumentsRepository
    {

        private AppDbContext _context;
        public DocumentRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task AddDocumentAsync(Documents documents)
        {
            _context.Add(documents);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocumentAsync(Documents documents)
        {
            _context?.Remove(documents);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocumentByIdAsync(int id)
        {
          _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Documents>> GetAllDocumentsAsync()
        {
            return _context.Documents.AsQueryable();
        }

        public async Task GetDocumentByIdAsync(int id)
        {
            await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDocumentAsync(Documents documents)
        {
            _context.Update(documents);
            await SaveChangeAsync();
        }
    }
}
