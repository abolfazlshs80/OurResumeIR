using Microsoft.AspNetCore.Identity;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Domain.Enums;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Implementation
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private readonly RoleManager<ApplicationRole> _roleManager;
        public UserService(IUserRepository userRepository,
            UserManager<User> userManager , 
            SignInManager<User> signInManager )
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
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

            };

            var status = await _userManager.CreateAsync(user, viewModel.Password);
            if (status.Succeeded)
            {
                var additionalClaims = new List<Claim>
                {
                   /* new Claim(ClaimTypes.Name, user.FullName ),*/ // افزودن claim سفارشی
                    new Claim(ClaimTypes.Email, user.Email) ,        // افزودن نقش کاربر
                   /* new Claim("UserName", user.UserName)     */    // افزودن نقش کاربر
                };
                await _signInManager.SignInAsync(user, true);
              
            }
            return RegisterResult.Success;
        }
    }
}
