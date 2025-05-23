﻿using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Identity;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Domain.Enums;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Application.ViewModels.Account;
using OurResumeIR.Application.ViewModels.Blog;
using OurResumeIR.Application.ViewModels.Document;
using OurResumeIR.Application.ViewModels.MySkills;
using LoginViewModel = OurResumeIR.Application.ViewModels.Account.LoginViewModel;
using RegisterViewModel = OurResumeIR.Application.ViewModels.Account.RegisterViewModel;

namespace OurResumeIR.Application.Services.Implementation
{
    public class UserService(IUnitOfWork unitOfWork
   
        ,IAuthService authService
        , IFileUploaderService _uploaderService)
        : IUserService
    {
        public async Task<bool> Logout()
        {
          
          return await authService.SignOutAsync();
        }

        public async Task<RegisterResult> RegisterUser(RegisterViewModel viewModel)
        {
            if (await unitOfWork.UserRepository.EmailIsExist(viewModel.Email))
            {
                return RegisterResult.DupplicateEmail;
            }

            if (viewModel.Password != viewModel.RePassword)
            {
                return RegisterResult.UnequalPassAndRePass;
            }


            var user = new User
            {
                Email = viewModel.Email,
                UserName = viewModel.Email,
                FullName = viewModel.Email,

            };

            var status = await unitOfWork.UserRepository.CreateUser(user, viewModel.Password);
            if (status != null)
            {

                await authService.PasswordSignInAsync(user, viewModel.Password, false, false);

            }

            return RegisterResult.Success;
        }




        public async Task<LoginResult> LoginUser(LoginViewModel viewModel)
        {
            var user = await unitOfWork.UserRepository.GetUserByEmail(viewModel.Email);

            if (user == null)
                return LoginResult.UserNotFound;

            var result =await authService.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);

            if (result)
            {
                return LoginResult.Success;
            }

            return LoginResult.InvalidPassword;
        }

        public async Task<string> UploadProfile(IFormFile file, string userId)
        {
            var result = await _uploaderService.UploadFileAsync(file, "Profile", userId);
            var User = await unitOfWork.UserRepository.GetUserById(userId);
            if (User == null)
                return string.Empty;
            User.ImageName = result;
            await unitOfWork.UserRepository.UpdateUserAsync(User);
            await unitOfWork.SaveChangesAsync();
            return result ?? string.Empty;
        }

        public async Task<bool> UpdateFullNameProfile(string Name, string userId)
        {
          
            var User =  await unitOfWork.UserRepository.GetUserById(userId);
            if (User == null)
                return false;
            User.FullName = Name;
            await unitOfWork.UserRepository.UpdateUserAsync(User);
            return true;
        }

        public async Task<UserProfileVM> LoadProfile( string userId)
        {
            var model = new UserProfileVM();

            var User = await unitOfWork.UserRepository.LoadProfileByUserId(userId);
            if (User == null)
                return model;

            model.ImagePath = User?.ImageName;
            model.FullName = User?.FullName;
            model.UserId = User?.Id;
            model.BlogCount = User.Blog.Count;
            model.DocumentCount = User.Documents.Count;
            model.SkillCount = User.UserToSkill.Count;
            model.Slug = User?.Slug;
            model.ResumeFile = User?.ResumeFile;
            model.bio = User?.bio;
            model.LinkInstagram = User?.LinkInstagram;
            model.LinkLinkdin = User?.LinkLinkdin;
            model.LinkX = User?.LinkX;
            model.LinkTelegram = User?.LinkTelegram;
            return model;
        }

        public async Task<UserResumeVM> LoadResume(string? slug,string? userId)
        {
            User currentUser=new();

            if (!string.IsNullOrEmpty(userId))
                 currentUser = await unitOfWork.UserRepository.GetUserBySlug(null,userId);
            else if (!string.IsNullOrEmpty(slug))
                currentUser = await unitOfWork.UserRepository.GetUserBySlug(slug, null);
            if (currentUser == null) return null;
            var model = new UserResumeVM();
            model.FullName=currentUser.FullName;
            model.Slug = slug;
            model.UserId = currentUser.Id;
            model.ImageName=currentUser.ImageName??"";
            model.ResumeFile=currentUser.ResumeFile;
            model.bio=currentUser.bio;
            model.LinkInstagram=currentUser.LinkInstagram;
            model.LinkLinkdin=currentUser.LinkLinkdin;
            model.LinkTelegram=currentUser.LinkTelegram;
            model.LinkX=currentUser.LinkX;
            if (currentUser.AboutMe != null)
            {
                model.AboutMe = new AboutMeVM()
                {
                    ImageName = currentUser.AboutMe?.ImageName,
                    UserId = currentUser.AboutMe?.UserId,
                    Description = currentUser.AboutMe?.Description,
                    Id = currentUser.AboutMe.Id
                };
            }
            else
                model.AboutMe = new();

            if (currentUser.Documents != null)
            {
                model.Documents = currentUser.Documents.Select(_ => new DocumentVM()
                {
                    Name = _.Name,
                    UserId = _.UserId,
                    Id = _.Id,
                    FileName = _.FileName,
                    ImageName = _.ImageName
                }).ToList();
            }
            else
                model.Documents = new List<DocumentVM>();
            if (currentUser.Blog != null)
                {
                    model.Blog = currentUser.Blog.Select(_ => new BlogVM()
                    {
                        ImageName = _.ImageName,
                        Title = _.Title,
                        Desc = _.Description,
                        Text = _.Text,
                        Id = _.Id
                    }).ToList();
            }
            else
                model.Blog = new List<BlogVM>();
            if (currentUser.History != null)
            {
                model.History = currentUser.History.Select(_ => new History()
                {
                    Name = _.Name,
                    UserId = _.UserId,
                    Id = _.Id
                }).ToList();
            }
            else
                model.History = new List<History>();

            if (currentUser.UserToSkill != null)
            {
                model.MySkill = currentUser.UserToSkill.Select(_ => new MySkillsForListViewModel()
                {
                    Percentage = _.SkillLevel.Percentage,
                    SkillName = _.Skill.Name,
                    SkillLevelName = _.SkillLevel.Name,
                    Id = _.Id
                }).ToList();
            }
            else
                model.MySkill = new List<MySkillsForListViewModel>();
            return model;

        }


        public async Task<bool> UpdateUserProfileAsync(UserProfileVM profile, string userId)
        {
           var user = await unitOfWork.UserRepository.GetUserById(userId);
            if (user == null) 
            {
                return false;
            }

            user.FullName = profile.FullName;
            user.Slug = profile.Slug;
            user.ResumeFile = profile.ResumeFile;
            user.bio = profile.bio;
            user.LinkLinkdin = profile.LinkLinkdin;
            user.LinkInstagram = profile.LinkInstagram;
            user.LinkX = profile.LinkX;
            user.LinkTelegram = profile.LinkTelegram;

            await unitOfWork.UserRepository.UpdateUserAsync(user);
            await unitOfWork.UserRepository.SaveChangesAsync();

            return true;
        }
    }
} 
