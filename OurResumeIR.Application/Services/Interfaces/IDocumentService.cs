using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OurResumeIR.Application.ViewModels.Document;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<ICollection<DocumentVM>> GetAll(string userId);
        Task<bool> Create(CreateDocumentVM model);
        Task<bool> Update(UpdateDocumentVM model);
        Task<bool> UploadFile(IFormFile File,int Id);
        Task<bool> Delete(int Id);
    }
}
