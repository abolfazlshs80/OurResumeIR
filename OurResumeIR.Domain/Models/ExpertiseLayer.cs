namespace OurResumeIR.Domain.Models;

public class ExpertiseLayer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Expertise> Expertise { get; set; }
}