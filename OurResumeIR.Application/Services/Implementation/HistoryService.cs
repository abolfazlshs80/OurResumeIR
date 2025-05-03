using Microsoft.EntityFrameworkCore;
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

        public async Task<List<HistoryListViewModel>> GetAlHistoryForListAsync()
        {
            var history = await _repository.GetAllHistoryAsync();

            return history.Select(h => new HistoryListViewModel
            {
                Id = h.Id,
                Name = h.Name,
            }).ToList();
        }

        public async Task<EditHistoryViewModel> GetHistoryShowForEditAsync(int id)
        {
            var history = await _repository.GetHistoryByIdAsync(id);

            if (history == null) 
            {
                return null;
            }

            var model = new EditHistoryViewModel
            {
                Id = history.Id,
                Name = history.Name,
                              
            };

            return model;
        }
    }
}
