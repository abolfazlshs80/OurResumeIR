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
    public class HistoryService (IUnitOfWork unitOfWork) : IHistoryService
    {
        
        public async Task<bool> CreateHistoryAsync(AddHistoryViewModel model, string userId)
        {
            var History = new History
            {
                Name = model.Name,
                UserId = userId,
            };

            await unitOfWork.HistoryRepository.AddHistoryAsync(History);
            return true;
        }

        public async Task<bool> DeleteHistoryAsync(int id, string userId)
        {
            var history = await unitOfWork.HistoryRepository.GetHistoryByIdAndUserIdAsync(id, userId);
            if (history == null)
            {
                return false;
            }

            await unitOfWork.HistoryRepository.DeletHistoryAsync(history);

            return true;

        }
        public async Task<List<HistoryListViewModel>> GetAlHistoryForListAsync()
        {
            var history = await unitOfWork.HistoryRepository.GetAllHistoryAsync();

            return history.Select(h => new HistoryListViewModel
            {
                Id = h.Id,
                Name = h.Name,
            }).ToList();
        }

        public async Task<EditHistoryViewModel> GetHistoryShowForEditAsync(int id)
        {
            var history = await unitOfWork.HistoryRepository.GetHistoryByIdAsync(id);

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

        public async Task<bool> UpdateHistoryAsync(EditHistoryViewModel model, string id)
        {
            var history = await unitOfWork.HistoryRepository.GetHistoryByIdAndUserIdAsync(model.Id, id);
            if (history == null)
            {
                return false;
            }

            history.Name = model.Name;

            await unitOfWork.HistoryRepository.UpdateHistoryAsync(history);

            return true;
        }
    }
}
