using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Domain.Models;
using ExpertiseLayerVM = OurResumeIR.Application.ViewModels.ExpertiseLayers.ExpertiseLayerVM;

namespace OurResumeIR.Application
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // مثال: Mapping از Domain Model به DTO
            CreateMap<ExpertiseLayerVM, SkillLevel>().ReverseMap();
            CreateMap<CreateExpertiseLayerVM, SkillLevel>().ReverseMap();
            CreateMap<UpdateExpertiseLayerVM, SkillLevel>().ReverseMap();
            CreateMap<UpdateExpertiseLayerVM, ExpertiseLayerVM>().ReverseMap();
            CreateMap<ExperienceListViewModel, Skill>().ReverseMap();
           
        }
    }
}
