using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Models
{
    public class AboutMe
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int UserId { get; set; }

        // Navigation Property
        public User User { get; set; }

    }
}
