using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogAsync(string? userId);
        Task<Blog> GetBlogById(int Id);
        Task AddBlogAsync(Blog blog);
        Task UpdateBlogAsync(Blog blog);
        Task DeleteBlogAsync(Blog blog);
        Task SaveChangesAsync();
        Task<Blog> GetBlogByIdAndUserIdAsync(int blogId, string userId);
    }
}
