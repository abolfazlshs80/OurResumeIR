using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IAboutMeRepository AboutMeRepository { get; }
        public IBlogRepository BlogRepository { get; }
        public IDocumentsRepository DocumentsRepository { get; }
        public IMyExperiencesRepository MyExperiencesRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            AppDbContext context,
            IAboutMeRepository aboutMeRepository,
            IBlogRepository blogRepository,
            IDocumentsRepository documentsRepository,
            IMyExperiencesRepository myExperiencesRepository,
            IUserRepository userRepository)
        {
            _context = context;
            AboutMeRepository = aboutMeRepository;
            BlogRepository = blogRepository;
            DocumentsRepository = documentsRepository;
            MyExperiencesRepository = myExperiencesRepository;
            UserRepository = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
