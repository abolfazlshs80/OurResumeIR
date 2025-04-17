using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.AboutMe
{
    public class UpdateAboutMeVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //public IFormFile File { get; set; }
        public string UserId { get; set; }
    }
}
