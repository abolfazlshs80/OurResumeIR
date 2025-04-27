using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Application.ViewModels.Document;
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


            #region Skill Level


            // مثال: Mapping از Domain Model به DTO
            CreateMap<SkillLevelVM, SkillLevel>().ReverseMap();
            CreateMap<CreateSkillLevelVM, SkillLevel>().ReverseMap();
            CreateMap<UpdateSkillLevelVM, SkillLevel>().ReverseMap();
            CreateMap<UpdateSkillLevelVM, SkillLevelVM>().ReverseMap();

            #endregion



            #region Skill 


            CreateMap<SkillListViewModel, Skill>().ReverseMap();

            #endregion

            #region AboutMe 


            CreateMap<AboutMe, AboutMeVM>().ReverseMap();
            CreateMap<CreateAboutMeVM, AboutMe>().ReverseMap();
            CreateMap<UpdateAboutMeVM, AboutMe>().ReverseMap();

            #endregion

            #region AboutMe 


            CreateMap<Documents, DocumentVM>().ReverseMap();
            CreateMap<CreateDocumentVM, Documents>().ReverseMap();
            CreateMap<UpdateDocumentVM, Documents>().ReverseMap();

            #endregion
        }
    }
}
