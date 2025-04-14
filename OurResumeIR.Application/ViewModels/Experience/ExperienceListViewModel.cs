using Microsoft.AspNetCore.Mvc.Rendering;
using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.Experience
{
    public class ExperienceListViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام تخصص را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "سطح تخصص را انتخاب کنید")]
        public int ExpertiseLayerId { get; set; }

        // 👇 این ویژگی جدید برای نمایش سطح تخصص
        //public string ExpertiseLayerTitle { get; set; }
        public ExpertiseLayer ExpertiseLayer { get; set; }

        //// برای DropDown
        //public List<SelectListItem> ExpertiseLayerOptions { get; set; } = new();
    }
}
