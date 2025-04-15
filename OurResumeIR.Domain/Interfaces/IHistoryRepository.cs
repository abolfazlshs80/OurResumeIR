using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IHistoryRepository
    {
        Task<IQueryable<History>> GetAllHistoryAsync();
        Task<History> GetHistoryByIdAsync(int id);
        Task AddHistoryAsync(History History);
        Task UpdateHistoryAsync(History History);
        Task DeletHistoryAsync(History History);
        Task DeleteHistoryByIdAsync(int id);
        Task SaveChangeAsync();
    }
}
