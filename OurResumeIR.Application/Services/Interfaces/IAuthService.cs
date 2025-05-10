using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> PasswordSignInAsync(User user,string password,bool RemeberMe,bool IsLock);
        Task<bool> SignOutAsync();
    }
}
