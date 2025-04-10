using AutoMapper;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.ViewModels.ExpertiseLayers;

public class ExpertiseLayerVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Navigation Property  
   public ICollection<ExperienceVM> Experience { get; set; }


}