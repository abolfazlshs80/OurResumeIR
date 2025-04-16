using OurResumeIR.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Implementation
{
    public class AboutMeService(IUnitOfWork unitOfWork, IMapper mapper) : IAboutMeService
    {
        public async Task<AboutMeVM> GetAll(string userId)
        {
            var curentRep = unitOfWork.AboutMeRepository;
            var aboutMe = await curentRep.GetByUserIdAsync(userId);

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
                var aboutMe = mapper.Map<AboutMe>(model);
                await curentRep.UpdateAsync(aboutMe);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async Task<bool> Delete(string userId)
        {
            try
            {
                var curentRep = unitOfWork.AboutMeRepository;
                var aboutMe = await curentRep.GetByUserIdAsync(userId);
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
