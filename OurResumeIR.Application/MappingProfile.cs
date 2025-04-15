using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.Experience;
using OurResumeIR.Application.ViewModels.ExpertiseLayers;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Application
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // مثال: Mapping از Domain Model به DTO
            CreateMap<SkillLevelVM, SkillLevel>().ReverseMap();
            CreateMap<CreateSkillLevelVM, SkillLevel>().ReverseMap();
            CreateMap<UpdateSkillLevelVM, SkillLevel>().ReverseMap();
            CreateMap<UpdateSkillLevelVM, SkillLevelVM>().ReverseMap();
            CreateMap<SkillListViewModel, Skill>().ReverseMap();
           
        }
    }
}
