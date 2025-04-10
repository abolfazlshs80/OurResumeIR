using System.ComponentModel.DataAnnotations;

namespace OurResumeIR.Application.ViewModels.Account
{
    public class LoginViewModel
    {

        [EmailAddress]
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [StringLength(70, ErrorMessage = "ایمیل بین 5 تا 30 کارکتر باید باشد", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "فرمت ایمیل را درست وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [StringLength(20, ErrorMessage = "حداقل کارکتر برای رمز عبور 5 کارکتر است", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{5,}$",
        ErrorMessage = "رمز عبور باید حداقل ۵ کاراکتر و شامل حرف بزرگ، حرف کوچک، عدد و یک کاراکتر خاص باشد.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
