using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.History
{
    public class EditHistoryViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان تجربه الزامی است")]
        public string Name { get; set; }
    }
}
