using Microsoft.EntityFrameworkCore;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Blog;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.ContactUs;
using static System.Net.Mime.MediaTypeNames;

namespace OurResumeIR.Application.Services.Implementation
{
    public class ContactUsService(IUnitOfWork unitOfWork) : IContactUsService
    {
        public async Task<List<AdminItemContactUsViewModel>> GetAllAsync(string userId)
        {
           var res= await unitOfWork.ContactUsRepository.GetAllAsync(userId);
           return res.Select(c => new AdminItemContactUsViewModel
           {
               Id = c.Id,
               UserId = c.UserId,
               Name = c.Name,
               Family = c.Family,
               Subject = c.Subject,
               Text = c.Text,
               Email = c.Email,

           }).ToList();

        }

        public async Task<AdminItemContactUsViewModel> GetAsync(int Id, string userId)
        {
         var contact=   await unitOfWork.ContactUsRepository.GetAsync(Id, userId);
         var model = new AdminItemContactUsViewModel
         {
             Id = contact.Id,
             Name = contact.Name,
             Family = contact.Family,
             Email = contact.Email,
             Subject = contact.Subject,
             Text = contact.Text,
             UserId = contact.UserId,

         };
         return model;
        }

        public async Task<bool> CreateContactUsAsync(CreateContactUsViewModel model)
        {
            await unitOfWork.ContactUsRepository.CreateAsync(new ContactUs()
            {
                Email = model.Email,
                Text = model.Text,
                Subject = model.Subject,
                Name = model.Name,
                Family = model.Family,
                UserId = model.UserId
            });
            return true;
        }
    }
}
