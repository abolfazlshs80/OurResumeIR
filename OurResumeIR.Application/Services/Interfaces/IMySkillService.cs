using Microsoft.AspNetCore.Mvc.Rendering;
using OurResumeIR.Application.ViewModels.MySkills;

namespace OurResumeIR.Application.Services.Interfaces;

public interface IMySkillService
{
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
    EditMySkillsViewModel GetSkillForEditAsync(int userToSkillId, out List<SelectListItem> skill, out List<SelectListItem> skillLevel);
    Task FillDropDownsForEditViewModel(EditMySkillsViewModel model);
    // نوشتن متدی که ورودی ویو مدل دارد و تبدیل ویو مدل به مدل و صدا زدن متد ریپوزیتوری برای ثبت اطلاعات در بانک اطلاعاتی
    Task UpdateUserSkillAsync(EditMySkillsViewModel model);
    Task<bool> DeleteUserSkillAsync(int id, string userId);
    #endregion
}