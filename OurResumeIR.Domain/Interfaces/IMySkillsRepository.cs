using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IMySkillsRepository
    {
        // گرفتن نام تخصص و سطح تخصص از دیتابیس برای استفاده در سرویس
        Task<List<UserToSkill>> GetAllSkillAndSkillLevelAsync(string userId);
        Task<List<UserToSkill>> GetAllSkillAndSkillLevelAsync();
        Task AddMySkillsAsync(UserToSkill skill);
        Task DeleteUserSkillAsync(UserToSkill userSkill);
        Task<UserToSkill?> GetUserSkillByIdAsync(int id, string userId);

    }
}
