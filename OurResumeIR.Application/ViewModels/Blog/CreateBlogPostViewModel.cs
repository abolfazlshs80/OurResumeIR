using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.Blog
{
    public class CreateBlogPostViewModel
    {
        [Required(ErrorMessage ="لطفا عنوان را وارد کنید")]
        public string Title { get; set; }
        [Required(ErrorMessage ="لطفا شرح مقاله را وارد کنید")]
        public string Description { get; set; }
        [Required(ErrorMessage ="لطفا متن مقاله راوارد کنید")]
        public string Text { get; set; }

        public IFormFile ImageFile { get; set; } // برای آپلود عکس

        // فیلد تصویر که بعداً در دیتابیس ذخیره می‌شه
        public string? ImageName { get; set; }

    }
}
