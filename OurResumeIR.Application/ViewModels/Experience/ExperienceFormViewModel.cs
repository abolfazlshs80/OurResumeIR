using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace OurResumeIR.Application.ViewModels.Experience
{
    public class ExperienceFormViewModel
    {
        //public int? Id { get; set; } // Nullable برای استفاده در Edit
        public string Name { get; set; }

        public int ExpertiseLayerId { get; set; }

        // برای DropDown
        public IEnumerable<SelectListItem> ExpertiseLayerOptions { get; set; }
    }
}
