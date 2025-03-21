namespace OurResumeIR.Domain.Models;

public class Expertise
{
    public int Id { get; set; }
    public int ExpertiseLayerId { get; set; }
    public string Name { get; set; }
    // Navigation Property  
    public ExpertiseLayer ExpertiseLayer { get; set; }
    public ICollection<UserExpertise> UserExpertise { get; set; }
}