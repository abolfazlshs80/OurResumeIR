using OurResumeIR.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Implementation
{
    public class AboutMeService(IUnitOfWork unitOfWork, IFileUploaderService uploaderService, IMapper mapper) : IAboutMeService
    {
        public async Task<AboutMeVM> GetAll(string userId)
        {
            var curentRep = unitOfWork.AboutMeRepository;
            var aboutMe = await curentRep.GetByUserIdAsync(userId);
            if (aboutMe == null)
            {
                await curentRep.AddAsync(new AboutMe()
                {
                    Description = "-",
                    ImageName = "-",
                    UserId = userId
                });
                await unitOfWork.SaveChangesAsync();
                aboutMe = await curentRep.GetByUserIdAsync(userId);
            }
            return mapper.Map<AboutMeVM>(aboutMe);
        }

        public async Task<bool> Create(CreateAboutMeVM model)
        {
            try
            {
                var curentRep = unitOfWork.AboutMeRepository;
                var aboutMe = mapper.Map<AboutMe>(model);
                await curentRep.AddAsync(aboutMe);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public async Task<bool> Update(UpdateAboutMeVM model)
        {
            try
            {
                var curentRep = unitOfWork.AboutMeRepository;
                var curentAboutMe =await curentRep.GetByUserIdAsync(model.UserId);
                curentAboutMe.Description=model.Description;
              
                curentAboutMe.Id=model.Id;
                await curentRep.UpdateAsync(curentAboutMe);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UploadFile(IFormFile File, string UserId)
        {
            if (File != null)
            {
                var curentRep = unitOfWork.AboutMeRepository;
                var curentAboutMe = await curentRep.GetByUserIdAsync(UserId);
                await uploaderService.DeleteFile("AboutMe", curentAboutMe.ImageName);
                curentAboutMe.ImageName = await uploaderService.UploadFileAsync(File, "AboutMe", UserId);
                await curentRep.UpdateAsync(curentAboutMe);
                await unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;

        }


        public async Task<bool> Delete(string userId)
        {
            try
            {
                var curentRep = unitOfWork.AboutMeRepository;
                var aboutMe = await curentRep.GetByUserIdAsync(userId);
                await uploaderService.DeleteFile("AboutMe", aboutMe.ImageName);
                await curentRep.DeleteAsync(aboutMe);
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
