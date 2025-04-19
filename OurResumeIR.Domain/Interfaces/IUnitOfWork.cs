using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAboutMeRepository AboutMeRepository { get; }
        IBlogRepository BlogRepository { get; }
        IDocumentsRepository DocumentsRepository { get; }
        IHistoryRepository HistoryRepository { get; }
        IUserRepository UserRepository { get; }
        ISkillRepository SkillRepository { get; }
        ISkillLevelRepository SkillLevelRepository { get; }
        IUserToSkillRepository UserToSkillRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
