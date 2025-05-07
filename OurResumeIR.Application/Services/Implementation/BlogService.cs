using Microsoft.EntityFrameworkCore;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Blog;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OurResumeIR.Application.Services.Implementation
{
    public class BlogService : IBlogService
    {
        private IFileUploaderService _fileUploader;
        private IBlogRepository _blogRepository;
        public BlogService(IFileUploaderService fileUploader , IBlogRepository blogRepository)
        {
            _fileUploader = fileUploader;
            _blogRepository = blogRepository;   
        }
        public async Task<bool> CreateBlogAsync(CreateBlogPostViewModel model, string userId)
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
            return true;
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

        public async Task<EditBlogPostListViewModel> GetBlogForEditView(int id)
        {
            var blogPost = await _blogRepository.GetBlogById(id);

            var model = new EditBlogPostListViewModel
            {
                
                Id = blogPost.Id,
                Title = blogPost.Title,
                ImageName = blogPost.ImageName,
                Description = blogPost.Description,
                Text = blogPost.Text,
              
            };

            return model;

        }

        public async Task<bool> UpdateBlogAsync(EditBlogPostListViewModel model, string userId)
        {
            var blogPost = await _blogRepository.GetBlogByIdAndUserIdAsync(model.Id, userId);
            if (blogPost == null) 
            {
                return false;
            }

            // آپدیت فیلدهای متنی
            blogPost.Title = model.Title;
            blogPost.Description = model.Description;
            blogPost.Text = model.Text;

            // حذف عکس قبلی از سرور
            if (model.NewImage != null && model.NewImage.Length > 0) 
            {
                if (!string.IsNullOrEmpty(blogPost.ImageName)) 
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog", blogPost.ImageName);
                    if (System.IO.File.Exists(oldImagePath)) 
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // ذخیره عکس جدید
                var newImageName = $"{Guid.NewGuid()}{Path.GetExtension(model.NewImage.FileName)}";
                var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog", newImageName);

                using (var stream = new FileStream(newImagePath, FileMode.Create))
                {
                    await model.NewImage.CopyToAsync(stream);
                }

                // بروزرسانی نام عکس جدید در دیتابیس
                blogPost.ImageName = newImageName;
            }

            // اگر کاربر عکسی انتخاب نکرده ➔ هیچ کاری روی ImageName انجام نمیدیم و همون قبلی باقی میمونه

            await _blogRepository.UpdateBlogAsync(blogPost);
            await _blogRepository.SaveChangesAsync();
            return true;
        }
    }
}
