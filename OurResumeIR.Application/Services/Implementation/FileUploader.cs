using Microsoft.AspNetCore.Http;
using OurResumeIR.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Implementation
{
    public class FileUploader : IFileUploader
    {
        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
           if(file == null || file.Length == 0)  return null; 

           // ساخت نام جدید و گرفتن اکستنشن فایل 
           var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(file.Name);
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" , folderName);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, uniqueName);
            using(var stream = new FileStream(filePath , FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            return uniqueName;
        }
    }
}
