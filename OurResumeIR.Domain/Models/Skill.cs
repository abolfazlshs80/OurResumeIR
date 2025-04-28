namespace OurResumeIR.Domain.Models;

public class Skill
{
    public int Id { get; set; }
    //public int ExpertiseLayerId { get; set; }
    public string Name { get; set; }


    // Navigation Property  
    //public SkillLevel SkillLevel { get; set; }
    public ICollection<UserToSkill> UserToSkill { get; set; }
}