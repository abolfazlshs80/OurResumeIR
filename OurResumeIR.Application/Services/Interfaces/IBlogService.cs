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
        Task<bool> CreateBlogAsync(CreateBlogPostViewModel model , string userId);
        Task<List<BlogPostListViewModel>> GetAllBlogForView(string userId);
        Task<bool> DeleteBlogAsync(int blogId , string userId);
        Task<EditBlogPostListViewModel> GetBlogForEditView(int id);
        Task<bool> UpdateBlogAsync(EditBlogPostListViewModel model , string userId);

    }
}
