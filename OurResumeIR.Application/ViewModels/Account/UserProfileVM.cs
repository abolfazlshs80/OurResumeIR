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
       
    }
}
