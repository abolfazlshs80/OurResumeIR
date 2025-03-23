using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IMyExperiencesRepository
    {
        Task<IQueryable<MyExperiences>> GetAllExperiencesAsync();
        Task<MyExperiences> GetExperienceByIdAsync(int id);
        Task AddExperienceAsync(Experience experience);
        Task UpdateExperienceAsync(Experience experience);
        Task DeletExperienceAsync(Experience experience);
        Task DeleteExperienceByIdAsync(int id);
        Task SaveChangeAsync();
    }
}
