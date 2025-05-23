﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OurResumeIR.Application.ViewModels.Document
{
    public class UpdateDocumentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "نام را وارد کنید")]
        [Display(Name = "نام مدرک")]
        public string Name { get; set; }
        
        [Display(Name = "عکس مدرک")]
        public IFormFile? Image { get; set; }

        [Display(Name = "فایل مدرک")]
        public IFormFile? File { get; set; }
        public string UserId { get; set; }
       

    }
}
