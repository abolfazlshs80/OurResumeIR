using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.Experience
{
    public record CreateExpertiseLayerVM( string Name)
    {
        public CreateExpertiseLayerVM():this( "")  {}
    }
}
