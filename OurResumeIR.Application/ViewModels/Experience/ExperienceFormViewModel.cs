using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace OurResumeIR.Application.ViewModels.Experience
{
    public class ExperienceFormViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "نام تخصص را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "سطح تخصص را انتخاب کنید")]
        public int ExpertiseLayerId { get; set; }

        // برای DropDown
        public List<SelectListItem> ExpertiseLayerOptions { get; set; } = new();
    }
}
