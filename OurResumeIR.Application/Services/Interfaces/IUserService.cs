using OurResumeIR.Domain.Enums;
using OurResumeIR.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResult> LoginUser(LoginViewModel model);
        Task<RegisterResult> RegisterUser(RegisterViewModel viewModel);
    }
}
