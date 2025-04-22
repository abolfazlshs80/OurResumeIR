using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IFileUploaderService
    {


        Task<string> UpdloadFile(IFormFile file, string directoryName,  string Name);
        Task DeleteFile(string directoryName, string Name);
        string DownloadFile(string filename, string type);

    }
}
