using OurResumeIR.Application.ViewModels.ExpertiseLayers;

namespace OurResumeIR.Domain.Models;

public class SkillVM
{
    public int Id { get; set; }
    //public int ExpertiseLayerId { get; set; }
    public string Name { get; set; }
    // Navigation Property  
    //public SkillLevelVM SkillLevel { get; set; }
  //  public ICollection<UserToSkill> UserToSkill { get; set; }
}