using OurResumeIR.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.Cookies;
using OurResumeIR.Domain.Models;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;

namespace OurResumeIR.Infrastructure.Services
{
    public class AuthService(     SignInManager<User> _signInManager) : IAuthService
    {
 
        public async Task<bool> PasswordSignInAsync(User user, string Password, bool RememberMe, bool IsLock)
        {
            await _signInManager.PasswordSignInAsync(user, Password, RememberMe, false);
            return true;
        }

        public async Task<bool> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return true;

        }
    }
}
