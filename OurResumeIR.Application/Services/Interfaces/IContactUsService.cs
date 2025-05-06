using OurResumeIR.Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.ContactUs;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IContactUsService
    {
        Task<List<AdminItemContactUsViewModel>> GetAllAsync(string userId);
        Task<bool> CreateContactUsAsync(CreateContactUsViewModel model);
       

    }
}
