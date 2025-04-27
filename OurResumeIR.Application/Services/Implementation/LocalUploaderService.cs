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
        public async Task<string> UpdloadFile(IFormFile file, string directoryName ,string Name)
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

        public  string DownloadFile(string filename, string type)
        {
            throw new NotImplementedException();
        }
    }
}
