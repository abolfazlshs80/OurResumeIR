using System.ComponentModel.DataAnnotations;

namespace OurResumeIR.Application.ViewModels.Account
{
    public class UserProfileVM
    {
        public string UserId { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }
        public int BlogCount { get; set; }
        public int SkillCount { get; set; }
        public int DocumentCount { get; set; }


        public string? Slug { get; set; }
        public string? ResumeFile { get; set; }
        public string? bio { get; set; }
        public string? LinkInstagram { get; set; }
        public string? LinkLinkdin { get; set; }
        public string? LinkX { get; set; }
        public string? LinkTelegram { get; set; }

    }
}
