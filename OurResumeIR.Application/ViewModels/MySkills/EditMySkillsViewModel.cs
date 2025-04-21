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

        [Required]
        public int SkillId { get; set; }

        [Required]
        public int SkillLevelId { get; set; }

        public string UserId { get; set; }

        // برای DropDown
        public List<SelectListItem> Skills { get; set; }
        public List<SelectListItem> SkillLevels { get; set; }
    }
}
