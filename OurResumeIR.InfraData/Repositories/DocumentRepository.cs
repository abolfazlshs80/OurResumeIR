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

        //public async Task DeleteDocumentByIdAsync(int id)
        //{
        //    int documentid = await GetDocumentByIdAsync(id);
        //    await DeleteDocumentAsync(documentid);
        //}

        //public async Task<IQueryable<Documents>> GetAllDocumentsAsync()
        //{
        //    return await _context.Documents.ToListAsync();
        //}

        public Task GetDocumentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangeAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateDocumentAsync(Documents documents)
        {
            throw new NotImplementedException();
        }
    }
}
