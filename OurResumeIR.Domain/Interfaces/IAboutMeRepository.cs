﻿using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IAboutMeRepository
    {
        Task<AboutMe> GetByUserIdAsync(string userId);
        Task AddAsync(AboutMe aboutMe);
        Task UpdateAsync(AboutMe aboutMe);
        Task DeleteAsync(AboutMe aboutMe);
        Task SaveChangesAsync();
    }
}
