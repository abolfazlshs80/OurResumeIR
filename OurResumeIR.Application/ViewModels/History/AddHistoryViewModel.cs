using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Application.ViewModels.History
{
    public class AddHistoryViewModel
    {
        [Required(ErrorMessage ="لطفا نام تخصص را وارد کنید.")]
        public string Name { get; set; }
    }
}
