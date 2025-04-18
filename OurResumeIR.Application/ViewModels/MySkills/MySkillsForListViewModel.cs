using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.MySkills
{
    public class MySkillsForListViewModel
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string SkillLevelName { get; set; }

    }
}
