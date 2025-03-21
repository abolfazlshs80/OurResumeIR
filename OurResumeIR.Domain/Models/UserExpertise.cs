using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Models
{
    public class UserExpertise
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExpertiseId { get; set; }

        // Navigation Property  
        public Experience Expertise { get; set; }
        public User User { get; set; }
    }
}
