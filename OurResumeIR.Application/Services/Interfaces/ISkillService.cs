using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface ISkillService
    {
        #region Specialties Layer

        Task<List<SkillLevelVM>> GetAll();
        Task<SkillLevelVM> GetById(int Id);
        Task<bool> Update(UpdateSkillLevelVM model);
        Task<bool> Create(CreateSkillLevelVM model);
        Task<bool> Delete(int Id);

        #endregion


        #region Specialties 

        // TO DO Interface

        Task<List<SkillFormViewModel>> GetAllAsync();
        Task CreateAsync(SkillFormViewModel model);
        Task<SkillFormViewModel> GetAllSkillLevelAsync(); // برای نمایش لیست تمام سطح های تخصص
        Task AddSkillAsync(SkillFormViewModel model);
        Task<List<SkillListViewModel>> GetAllSkillAsync();
        Task<SkillFormViewModel> GetSkillFormByIdAsync(int id);
        Task<bool> UpdateSkillAsync(SkillFormViewModel model);
        Task<bool> DeleteSkillAsync(int id);

        #endregion


        #region My Skills
        // ساخت ویو مدل برای نمایش نام تخصص و سطح تخصص داخل کنترولر
        // نوشتن متد گرفتن نام تخصص و سطح تخصص از ریپوزیتوری و خروجی ویو مدل برای کنترولر
        Task<List<MySkillsForListViewModel>> GetAllSkillAndSkillLevelForViewAsync(string userId);
        // ساخت ویو مدل برای پر کردن دراپ دان های سطح تخصص و تخصص
        // نوشتن متد گرفتن نام و سطح تخصص از ریپوزیتوری و خروجی ویو مدل و پر کردن سلکت آپشن ها
        Task<AddMySkillsViewModel> GetAllSkillAndSkillLevelForDropDownAsync();
        // نوشتن متد  که ورودی ویو مدل دارد و تبدیل اطلاعات ورودی به مدل و صدا زدن متد ریپوزیتوری برای اد کردن مدل در دیتابیس
        Task AddMySkillAsync(AddMySkillsViewModel model);
        // درست کردن ویو مدل برای پر کردن دراپ دان های تخصص و سطح تخصص که در هنگام ویرایش مقدار لازم پر شده باشد
        // نوشتن یک متد که خروجی ویو مدل داشته باشد و مقدار سلکت آپشن ها پر شود و برای نمایش به کاربر آماده باشد
        Task<EditMySkillsViewModel> GetSkillForEditAsync(int userToSkillId);
        Task FillDropDownsForEditViewModel(EditMySkillsViewModel model);
       // نوشتن متدی که ورودی ویو مدل دارد و تبدیل ویو مدل به مدل و صدا زدن متد ریپوزیتوری برای ثبت اطلاعات در بانک اطلاعاتی
        #endregion

    }
}
