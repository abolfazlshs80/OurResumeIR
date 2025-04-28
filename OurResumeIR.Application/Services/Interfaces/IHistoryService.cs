using OurResumeIR.Application.ViewModels.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<List<HistoryListViewModel>> GetAlHistoryForListAsync();
       Task<bool> CreateHistoryAsync(AddHistoryViewModel model, string userId);
    }
}
