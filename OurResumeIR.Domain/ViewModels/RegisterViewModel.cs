using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [StringLength(70, ErrorMessage = "ایمیل بین 5 تا 30 کارکتر باید باشد", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "فرمت ایمیل را درست وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [StringLength(20, ErrorMessage = "حداقل کارکتر برای رمز عبور 5 کارکتر است", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public int Password { get; set; }

        [Required(ErrorMessage = "لطفا تکرار رمز عبور را وارد کنید")]
        [StringLength(20, ErrorMessage = "تکرار رمز عبور حداقل 5 کارکتر باید باشد")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار رمز عبور برابر نیستند")]
        public int RePassword { get; set; }
    }
}
