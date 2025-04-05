using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Models
{
    // ایجاد فیلد سفارشی در مدل ApplicationUser به واسطه IdentityUser
    public class ApplicationUser : IdentityUser
    {
        // می‌توانید فیلدهای اضافی برای کاربر اضافه کنید
        public string FullName { get; set; }
    }
}
