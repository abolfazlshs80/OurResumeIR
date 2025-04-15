using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Models
{
    public class UserToSkill
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SkillId { get; set; }
        public int SkillLevelId { get; set; }

        // Navigation Property  
        public Skill Skill { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public User User { get; set; }
    }
}
