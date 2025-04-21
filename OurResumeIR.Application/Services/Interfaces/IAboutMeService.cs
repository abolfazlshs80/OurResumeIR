using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OurResumeIR.Application.ViewModels.AboutMe;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IAboutMeService
    {
        Task<AboutMeVM> GetAll(string userId);
        Task<bool> Create(CreateAboutMeVM model);
        Task<bool> Update(UpdateAboutMeVM model);
        Task<bool> UploadFile(IFormFile File,string UserId);
        Task<bool> Delete(string userId);
    }
}
