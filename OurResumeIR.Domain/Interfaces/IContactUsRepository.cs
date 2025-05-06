using OurResumeIR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Domain.Interfaces
{
    public interface IContactUsRepository
    {
        Task<List<ContactUs>> GetAllAsync(string userId);
        Task<bool> CreateAsync(ContactUs model);

    }
}
