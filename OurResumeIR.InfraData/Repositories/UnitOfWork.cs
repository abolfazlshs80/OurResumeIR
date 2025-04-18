﻿using OurResumeIR.Domain.Interfaces;
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
        public IHistoryRepository HistoryRepository { get; }
        public IUserRepository UserRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public ISkillLevelRepository SkillLevelRepository { get; }

        public UnitOfWork(
            ISkillRepository skillRepository,
            ISkillLevelRepository skillLevelRepository,
            AppDbContext context,
            IAboutMeRepository aboutMeRepository,
            IBlogRepository blogRepository,
            IDocumentsRepository documentsRepository,
            IHistoryRepository historyRepository,
            IUserRepository userRepository)
        {
            _context = context;
            AboutMeRepository = aboutMeRepository;
            BlogRepository = blogRepository;
            DocumentsRepository = documentsRepository;
            HistoryRepository = historyRepository;
            UserRepository = userRepository;
            SkillRepository = skillRepository;
            SkillLevelRepository = skillLevelRepository;
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
