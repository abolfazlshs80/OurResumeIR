using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Blog;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.Services.Implementation
{
    public class BlogService : IBlogService
    {
        private IFileUploader _fileUploader;
        private IBlogRepository _blogRepository;
        public BlogService(IFileUploader fileUploader , IBlogRepository blogRepository)
        {
            _fileUploader = fileUploader;
            _blogRepository = blogRepository;   
        }
        public async Task CreateBlogAsync(CreateBlogPostViewModel model, string userId)
        {
            string imageNmae = null;
            if (model.ImageFile != null) 
            {
                imageNmae = await _fileUploader.UploadFileAsync(model.ImageFile, "Images/Blog");
            }

            var blog = new Blog
            {
                UserId = userId,
                Description = model.Description,
                Text = model.Text,
                Title = model.Title,
               ImageName = imageNmae
            };

            await _blogRepository.AddBlogAsync(blog);
        }

        public async Task<bool> DeleteBlogAsync(int blogId, string userId)
        {
            var blog = await _blogRepository.GetBlogByIdAndUserIdAsync(blogId, userId);

            if (blog == null)
            {
                return false;
            }
            await _blogRepository.DeleteBlogAsync(blog);

            return true;
        }

        public async Task<List<BlogPostListViewModel>> GetAllBlogForView()
        {
           var BlogPosts = await _blogRepository.GetAllBlogAsync();


            return BlogPosts.Select(p => new BlogPostListViewModel
            {                 
                Id = p.Id,
                Title = p.Title,
                ImageName = p.ImageName 
            }).ToList();

        }
    }
}
