using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IFileUploader
    {
        Task<string> UploadFileAsync(IFormFile file , string folderName);
    }
}
