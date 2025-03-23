using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Store.Application.Generator
{
    public static class NameGenerator
    {
        public static string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
