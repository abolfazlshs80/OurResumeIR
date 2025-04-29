using AutoMapper;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application.ViewModels.ExpertiseLayers;

public class SkillLevelVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Percentage { get; set; }
    // Navigation Property  
    public ICollection<SkillVM> Skill { get; set; }


}