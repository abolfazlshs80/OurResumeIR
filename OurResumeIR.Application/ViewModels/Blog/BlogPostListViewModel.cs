using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.Blog
{
    public class BlogPostListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImageName { get; set; } // فقط اسم فایل
    }
}
