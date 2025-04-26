using Microsoft.AspNetCore.Http;
using OurResumeIR.Application.ViewModels.Account;
using OurResumeIR.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginViewModel = OurResumeIR.Application.ViewModels.Account.LoginViewModel;
using RegisterViewModel = OurResumeIR.Application.ViewModels.Account.RegisterViewModel;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResult> LoginUser(LoginViewModel model);
        Task<RegisterResult> RegisterUser(RegisterViewModel viewModel);
        Task<string> UploadProfile(IFormFile file, string userId);
        Task<bool> UpdateFullNameProfile(string Name, string userId);
        Task<UserProfileVM> LoadPrifile( string userId);
    }
}
