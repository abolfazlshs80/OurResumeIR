namespace OurResumeIR.Domain.Models;

public class SkillLevel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Percentage { get; set; }
    public string? UserId { get; set; }
    // Navigation Property  
    //public ICollection<Skill> Skill { get; set; }
    public ICollection<UserToSkill> UserToSkill { get; set; }
}