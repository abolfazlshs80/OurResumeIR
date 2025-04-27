using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IDocumentsRepository
    {
        Task<IQueryable<Documents>> GetAllDocumentsAsync(string userId);
        Task<IQueryable<Documents>> GetAllDocumentsAsync();
        Task<Documents> GetDocumentByIdAsync(int id);
        Task AddDocumentAsync(Documents documents);
        Task UpdateDocumentAsync(Documents documents);
        //Task DeleteDocumentByIdAsync(int id);
        Task DeleteDocumentAsync(Documents documents);
        Task SaveChangeAsync();
    }
}
