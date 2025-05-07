using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Models
{
    public class User: IdentityUser
    {
        //برای نمایش در مرورگر
        public string? Slug { get; set; }
        public string? FullName { get; set; }
        public string? ImageName { get; set; }
        public string? ResumeFile{ get; set; }
        public string? bio { get; set; }
        public string? LinkInstagram { get; set; }
        public string? LinkLinkdin{ get; set; }
        public string? LinkX{ get; set; }
        public string? LinkTelegram{ get; set; }

        // Navigation Property  
        public ICollection<UserToSkill> UserToSkill { get; set; }
        public ICollection<Blog> Blog { get; set; }
        public ICollection<Documents> Documents { get; set; }
        public ICollection<History> History { get; set; }
        public AboutMe AboutMe { get; set; }
    }
}
