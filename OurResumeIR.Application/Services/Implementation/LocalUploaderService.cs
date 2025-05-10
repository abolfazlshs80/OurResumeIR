using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OurResumeIR.Application.Services.Interfaces;

namespace OurResumeIR.Application.Services.Implementation
{
    public class LocalUploaderService:IFileUploaderService
    {
        public async Task<string> UploadFileAsync(IFormFile file, string directoryName ,string Name)
        {
            Name = Name.Replace(" ", "-");
            string name = Name   + Path.GetExtension(file.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", directoryName, name);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return name;
        }

        public async Task DeleteFile(string directoryName, string Name)
        {
            if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", directoryName, Name)))
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", directoryName, Name));
            }
            else if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploder", directoryName, Name)))
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploder", directoryName, Name));
            }
        }
        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0) return null;

            // ساخت نام جدید و گرفتن اکستنشن فایل 
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, uniqueName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            return uniqueName;
        }
        public  string DownloadFile(string filename, string type)
        {
            throw new NotImplementedException();
        }
    }
}
