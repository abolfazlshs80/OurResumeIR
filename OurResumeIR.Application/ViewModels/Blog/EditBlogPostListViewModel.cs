using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.Blog
{
    public class EditBlogPostListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }

        public string? ImageName { get; set; } // عکس قبلی

        public IFormFile? NewImage { get; set; } // عکس جدید آپلود شده
    }
}
