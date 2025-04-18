﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Models
{
    public class User: IdentityUser
    {
     
  

        // Navigation Property  
        public ICollection<UserToSkill> UserToSkill { get; set; }
        public ICollection<Blog> Blog { get; set; }
        public ICollection<Documents> Documents { get; set; }
        public ICollection<History> History { get; set; }
        public AboutMe AboutMe { get; set; }
    }
}
