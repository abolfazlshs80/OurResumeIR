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
        public IContactUsRepository ContactUsRepository { get; }
        public IBlogRepository BlogRepository { get; }
        public IDocumentsRepository DocumentsRepository { get; }
        public IHistoryRepository HistoryRepository { get; }
        public IUserRepository UserRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public ISkillLevelRepository SkillLevelRepository { get; }
        public IUserToSkillRepository UserToSkillRepository { get; }
        public IMySkillsRepository MySkillsRepository { get; }
      

        public UnitOfWork(
            ISkillRepository skillRepository,
            ISkillLevelRepository skillLevelRepository,
            IContactUsRepository contactUsRepository,
            AppDbContext context,
            IAboutMeRepository aboutMeRepository,
            IBlogRepository blogRepository,
            IDocumentsRepository documentsRepository,
            IHistoryRepository historyRepository,
            IUserRepository userRepository,
            IUserToSkillRepository userToSkillRepository,
            IMySkillsRepository mySkillsRepository)
        {
            _context = context;
            AboutMeRepository = aboutMeRepository;
            BlogRepository = blogRepository;
            DocumentsRepository = documentsRepository;
            HistoryRepository = historyRepository;
            UserRepository = userRepository;
            SkillRepository = skillRepository;
            SkillLevelRepository = skillLevelRepository;
            UserToSkillRepository = userToSkillRepository;
            ContactUsRepository = contactUsRepository;
            MySkillsRepository = mySkillsRepository;
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
