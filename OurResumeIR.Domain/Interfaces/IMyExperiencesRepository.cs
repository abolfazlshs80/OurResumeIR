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
        Task<IQueryable<History>> GetAllExperiencesAsync();
        Task<History> GetExperienceByIdAsync(int id);
        Task AddExperienceAsync(Skill skill);
        Task UpdateExperienceAsync(Skill skill);
        Task DeletExperienceAsync(Skill skill);
        Task DeleteExperienceByIdAsync(int id);
        Task SaveChangeAsync();
    }
}
