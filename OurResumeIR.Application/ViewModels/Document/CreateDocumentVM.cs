using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OurResumeIR.Application.ViewModels.Document
{
    public class CreateDocumentVM
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        [Display(Name = "نام مدرک")]
        public string Name { get; set; }
        [Required(ErrorMessage = "عکس را وارد کنید")]
        [Display(Name = "عکس مدرک")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "فایل مدرک را وارد  کنید")]
        [Display(Name = "فایل مدرک")]
        public IFormFile File { get; set; }
        public string UserId { get; set; }


    }
}
