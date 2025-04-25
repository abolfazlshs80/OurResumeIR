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
        public BlogService(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
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
    }
}
