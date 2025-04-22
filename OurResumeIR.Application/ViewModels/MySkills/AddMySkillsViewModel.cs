using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.MySkills
{
    public class AddMySkillsViewModel
    {
        [Required]
        public int SelectedSkillId { get; set; }
        [Required(ErrorMessage ="لطفا سطح تخصص را وارد کنید")]
        public int SelectedSkillLevelId { get; set; }
        //public string UserId { get; set; }

        public List<SelectListItem> Skills { get; set; } = new();
        public List<SelectListItem> SkillLevels { get; set; } = new();
    }
}
