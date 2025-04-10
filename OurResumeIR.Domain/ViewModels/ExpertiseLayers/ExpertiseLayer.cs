namespace OurResumeIR.Domain.Models;

public class ExpertiseLayerVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Navigation Property  
    public ICollection<Experience> Expertise { get; set; }
}