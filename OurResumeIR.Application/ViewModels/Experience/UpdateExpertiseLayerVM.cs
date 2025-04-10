using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.Experience
{
    public record UpdateExpertiseLayerVM( int Id,string Name)
    {
        public UpdateExpertiseLayerVM():this(0, "")
        {

        }
    }
}
