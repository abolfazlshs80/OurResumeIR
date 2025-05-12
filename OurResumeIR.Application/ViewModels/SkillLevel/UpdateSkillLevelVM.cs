using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.SkillLevel
{
    public class UpdateSkillLevelVM
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        [Display(Name = "نام را وارد کنید")]
        public string Name { get; set; }
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? Percentage { get; set; } = 0;
    }
}
