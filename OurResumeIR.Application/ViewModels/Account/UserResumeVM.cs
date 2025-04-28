using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Application.ViewModels.Document;
using OurResumeIR.Application.ViewModels.Blog;
using OurResumeIR.Application.ViewModels.MySkills;

namespace OurResumeIR.Application.ViewModels.Account
{
    public class UserResumeVM
    {
        public string? Slug { get; set; }
        public string? FullName { get; set; }
        public string? ImageName { get; set; }
        public string? ResumeFile { get; set; }
        public string? bio { get; set; }
        public string? LinkInstagram { get; set; }
        public string? LinkLinkdin { get; set; }
        public string? LinkX { get; set; }
        public string? LinkTelegram { get; set; }
        // Navigation Property  
        public ICollection<MySkillsForListViewModel> MySkill { get; set; }
        public ICollection<BlogVM> Blog { get; set; }
        public ICollection<DocumentVM> Documents { get; set; }
        public ICollection<History> History { get; set; }
        public AboutMeVM AboutMe { get; set; }
    }
}
