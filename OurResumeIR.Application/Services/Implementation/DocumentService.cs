using OurResumeIR.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using OurResumeIR.Application.ViewModels.Document;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Implementation
{
    public class DocumentService(IUnitOfWork unitOfWork, IFileUploaderService uploaderService, IMapper mapper) : IDocumentService
    {
        public async Task<ICollection<DocumentVM>> GetAll(string userId)
        {
            var curentRep = unitOfWork.DocumentsRepository;
            var Document = await curentRep.GetAllDocumentsAsync(userId);
     
            return mapper.Map<ICollection< DocumentVM>>(Document);
        }

        public async Task<bool> Create(CreateDocumentVM model)
        {
            try
            {
                var curentRep = unitOfWork.DocumentsRepository;
                var Document = new Documents();
                Document.Name=model.Name;
                Document.UserId = model.UserId;
                Document.FileName = await uploaderService.UpdloadFile(model.File, "Document", "File" + model.Name+DateTime.Now.ToString("yyyy-M-d dddd"));
                Document.ImageName = await uploaderService.UpdloadFile(model.Image, "Document", "Image" + model.Name + model.Name + DateTime.Now.ToString("yyyy-M-d dddd"));
                await curentRep.AddDocumentAsync(Document);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public async Task<bool> Update(UpdateDocumentVM model)
        {
            try
            {
                var curentRep = unitOfWork.DocumentsRepository;
                var curentDocument =await curentRep.GetDocumentByIdAsync(model.Id);
                curentDocument.UserId=model.UserId;
              
                curentDocument.Id=model.Id;
                curentDocument.ImageName=model.ImageName;
                curentDocument.FileName=model.FileName;
                curentDocument.Name=model.Name;
                await curentRep.UpdateDocumentAsync(curentDocument);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UploadFile(IFormFile File, int Id)
        {
            if (File != null)
            {
                var curentRep = unitOfWork.DocumentsRepository;
                var curentDocument = await curentRep.GetDocumentByIdAsync(Id);
                await uploaderService.DeleteFile("Document", curentDocument.ImageName);
                curentDocument.ImageName = await uploaderService.UpdloadFile(File, "Document", curentDocument.Name);
                await curentRep.UpdateDocumentAsync(curentDocument);
                await unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;

        }


        public async Task<bool> Delete(int Id)
        {
            try
            {
                var curentRep = unitOfWork.DocumentsRepository;
                var Document = await curentRep.GetDocumentByIdAsync(Id);
                await uploaderService.DeleteFile("Document", Document.ImageName);
                await curentRep.DeleteDocumentAsync(Document);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
