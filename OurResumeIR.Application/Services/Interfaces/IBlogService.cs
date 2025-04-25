using OurResumeIR.Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IBlogService
    {
        // نوشتن یک متد برای استفاده از سرویس آپلود عکس و تبدیل ویو مدل به مدل و ثبت اطلاعات داخل بانک از طریق صدا زدن متد ریپوزیتوری
        Task CreateBlogAsync(CreateBlogPostViewModel model , string userId);
        Task<List<BlogPostListViewModel>> GetAllBlogForView();
    }
}
