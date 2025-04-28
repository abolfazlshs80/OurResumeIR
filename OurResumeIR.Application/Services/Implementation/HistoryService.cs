using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.History;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Implementation
{
    public class HistoryService : IHistoryService
    {
        private IHistoryRepository _repository;
        public HistoryService(IHistoryRepository historyRepository)
        {
            _repository = historyRepository;
        }
        public async Task<bool> CreateHistoryAsync(AddHistoryViewModel model, string userId)
        {
            var History = new History
            {
                Name = model.Name,
                UserId = userId,
            };

           await _repository.AddHistoryAsync(History);
            return true;
        }
    }
}
