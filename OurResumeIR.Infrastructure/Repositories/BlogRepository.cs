using Microsoft.EntityFrameworkCore;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private AppDbContext _context;

        public BlogRepository( AppDbContext context) 
        {
            _context = context;
        }

        public async Task AddBlogAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Blog>> GetAllBlogAsync()
        {
           return await  _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAndUserIdAsync(int blogId, string userId)
        {
            return await _context.Blogs.FirstOrDefaultAsync(b => b.Id == blogId && b.UserId == userId);
        }

        public async Task<Blog> GetBlogById(int Id)
        {
            return await _context.Blogs.FirstOrDefaultAsync(b => b.Id == Id);   
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
           
        }
    }
}
