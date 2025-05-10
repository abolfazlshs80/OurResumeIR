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
using OurResumeIR.Application.Static;

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
                Document.FileName = await uploaderService.UploadFileAsync(model.File, FolderNameExtentions.Document, "File" + model.Name+DateTime.Now.ToString("yyyy-M-d dddd"));
                Document.ImageName = await uploaderService.UploadFileAsync(model.Image, FolderNameExtentions.Document, "Image" + model.Name + model.Name + DateTime.Now.ToString("yyyy-M-d dddd"));
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
                if (model.File != null)
                {

                    await uploaderService.DeleteFile(FolderNameExtentions.Document, curentDocument.FileName);
                    curentDocument.FileName = await uploaderService.UploadFileAsync(model.File, FolderNameExtentions.Document, "File" + model.Name + DateTime.Now.ToString("yyyy-M-d dddd"));

                }

                if (model.Image != null)
                {
                    await uploaderService.DeleteFile(FolderNameExtentions.Document, curentDocument.ImageName);
                    curentDocument.ImageName = await uploaderService.UploadFileAsync(model.Image, FolderNameExtentions.Document, "Image" + model.Name + model.Name + DateTime.Now.ToString("yyyy-M-d dddd"));

                }

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

        public async Task<UpdateDocumentVM> GetUpdate(int Id)
        {
            UpdateDocumentVM model = new();
            var curentRep = unitOfWork.DocumentsRepository;
            var curentDocument = await curentRep.GetDocumentByIdAsync(Id);
            if (curentDocument != null)
            {
                model.Name=curentDocument.Name;
                model.Id=Id;
                model.UserId = curentDocument.UserId;
            }

            return model;
        }

        public async Task<bool> UploadFile(IFormFile File, int Id)
        {
            if (File != null)
            {
                var curentRep = unitOfWork.DocumentsRepository;
                var curentDocument = await curentRep.GetDocumentByIdAsync(Id);
                await uploaderService.DeleteFile(FolderNameExtentions.Document, curentDocument.ImageName);
                curentDocument.ImageName = await uploaderService.UploadFileAsync(File, FolderNameExtentions.Document, curentDocument.Name);
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
                await uploaderService.DeleteFile(FolderNameExtentions.Document, Document.ImageName);
                await uploaderService.DeleteFile(FolderNameExtentions.Document, Document.FileName);
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
