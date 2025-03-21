using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IAboutMeRepository
    {
        Task GetByUserIdAsync(int userId);
        Task AddAsync(AboutMe aboutMe);
        Task UpdateAsync(AboutMe aboutMe);
        Task DeleteAsync(int userId);
        Task SaveChangesAsync();
    }
}
