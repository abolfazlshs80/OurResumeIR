using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class FilePathExtention
    {
        public static string ConvartImagePathForAboutMe(this string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;
            return $"/Images/AboutMe/{name}";
        }
    }

