using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.MySkills
{
    public class EditMySkillsViewModel
    {
        public int Id { get; set; } // Id مربوط به جدول UserToSkill

        [Required(ErrorMessage = "لطفاً یک تخصص انتخاب کنید")]
        [Range(1, int.MaxValue, ErrorMessage = "لطفاً یک تخصص انتخاب کنید")]
        public int SkillId { get; set; }

        [Required(ErrorMessage = "لطفاً سطح تخصص را انتخاب کنید")]
        [Range(1, int.MaxValue, ErrorMessage = "لطفاً سطح تخصص را انتخاب کنید")]
        public int SkillLevelId { get; set; }


        // برای DropDown
        public List<SelectListItem> Skills { get; set; }
        public List<SelectListItem> SkillLevels { get; set; }
    }
}
