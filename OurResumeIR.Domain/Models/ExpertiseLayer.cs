namespace OurResumeIR.Domain.Models;

public class ExpertiseLayer
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Navigation Property  
    public ICollection<Experience> Experience { get; set; }
}