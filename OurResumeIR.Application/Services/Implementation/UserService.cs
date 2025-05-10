using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public class UserService(IUserRepository _userRepository
        , UserManager<User> _userManager
        , SignInManager<User> _signInManager
        , IFileUploaderService _uploaderService)
        : IUserService
    {


        //private readonly RoleManager<ApplicationRole> _roleManager;

        public async Task<RegisterResult> RegisterUser(RegisterViewModel viewModel)
        {
            if (await _userRepository.EmailIsExist(viewModel.Email))
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

            var status = await _userManager.CreateAsync(user, viewModel.Password);
            if (status.Succeeded)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Email),
                         new Claim("CodeMeli", "3"),

                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await _signInManager.SignInAsync(user, properties);

            }

            return RegisterResult.Success;
        }




        public async Task<LoginResult> LoginUser(LoginViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);

            if (user == null)
                return LoginResult.UserNotFound;

            var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);

            if (result.Succeeded)
            {
                return LoginResult.Success;
            }

            return LoginResult.InvalidPassword;
        }

        public async Task<string> UploadProfile(IFormFile file, string userId)
        {
            var result = await _uploaderService.UploadFileAsync(file, "Profile", userId);
            var User = await _userManager.FindByIdAsync(userId);
            if (User == null)
                return string.Empty;
            User.ImageName = result;
            await _userManager.UpdateAsync(User);
            return result ?? string.Empty;
        }

        public async Task<bool> UpdateFullNameProfile(string Name, string userId)
        {
          
            var User = await _userManager.FindByIdAsync(userId);
            if (User == null)
                return false;
            User.FullName = Name;
            await _userManager.UpdateAsync(User);
            return true;
        }

        public async Task<UserProfileVM> LoadProfile( string userId)
        {
            var model = new UserProfileVM();
            var User = await _userManager.Users
                .Include(a => a.UserToSkill)
                .Include(a => a.Documents)
                .Include(a => a.Blog)
                .FirstOrDefaultAsync(a => a.Id.Equals(userId));
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

        public async Task<UserResumeVM> LoadResume(string slug)
        {
            var currentUser = await _userRepository.GetUserBySlug(slug);
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
           var user = await _userRepository.GetUserById(userId);
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

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }
    }
} 
