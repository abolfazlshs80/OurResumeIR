using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Enums
{
    public enum RegisterResult
    {
        Success = 1,
        DupplicateEmail = 2,
        UnequalPassAndRePass = 3,

    }
}
