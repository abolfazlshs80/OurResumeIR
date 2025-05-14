using Microsoft.EntityFrameworkCore;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.Static;
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
    public class BlogService(IUnitOfWork unitOfWork, IFileUploaderService _fileUploader) : IBlogService
    {
     
        public async Task<bool> CreateBlogAsync(CreateBlogPostViewModel model, string userId)
        {
            string imageNmae = null;
            if (model.ImageFile != null) 
            {
                imageNmae = await _fileUploader.UploadFileAsync(model.ImageFile, FolderNameExtentions.Blog,  model.Title + DateTime.Now.ToString("yyyy-M-d dddd"));
            }

            var blog = new Blog
            {
                UserId = userId,
                Description = model.Description,
                Text = model.Text,
                Title = model.Title,
               ImageName = imageNmae
            };

            await unitOfWork.BlogRepository.AddBlogAsync(blog);
            return true;
        }

        public async Task<bool> DeleteBlogAsync(int blogId, string userId)
        {
            var blog = await unitOfWork.BlogRepository.GetBlogByIdAndUserIdAsync(blogId, userId);

            if (blog == null)
            {
                return false;
            }
            await _fileUploader.DeleteFile(FolderNameExtentions.Blog, blog.ImageName);
            await unitOfWork.BlogRepository.DeleteBlogAsync(blog);

            return true;
        }

        public async Task<List<BlogPostListViewModel>> GetAllBlogForView(string userId)
        {
           var BlogPosts = await unitOfWork.BlogRepository.GetAllBlogAsync(userId);


            return BlogPosts.Select(p => new BlogPostListViewModel
            {                 
                
                Id = p.Id,
                Title = p.Title,
                ImageName = p.ImageName 
            }).ToList();

        }

        public async Task<EditBlogPostListViewModel> GetBlogForEditView(int id)
        {
            var blogPost = await unitOfWork.BlogRepository.GetBlogById(id);

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
            var blogPost = await unitOfWork.BlogRepository.GetBlogByIdAndUserIdAsync(model.Id, userId);
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



                await _fileUploader.DeleteFile("Document", model.Title);
                // بروزرسانی نام عکس جدید در دیتابیس
                blogPost.ImageName  = await _fileUploader.UploadFileAsync(model.NewImage, FolderNameExtentions.Blog,   model.Title + DateTime.Now.ToString("yyyy-M-d dddd"));
            }

            // اگر کاربر عکسی انتخاب نکرده ➔ هیچ کاری روی ImageName انجام نمیدیم و همون قبلی باقی میمونه

            await unitOfWork.BlogRepository.UpdateBlogAsync(blogPost);
            await unitOfWork.BlogRepository.SaveChangesAsync();
            return true;
        }
    }
}
