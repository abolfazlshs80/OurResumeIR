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
            _context.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(Blog blog)
        {
            _context.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<Blog> GetByUserId(string userId)
        {
            return await _context.Blogs.FirstOrDefaultAsync(b => b.UserId == userId);   
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            _context.Update(blog);
            await _context.SaveChangesAsync();
        }
    }
}
