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
        IMyExperiencesRepository MyExperiencesRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
