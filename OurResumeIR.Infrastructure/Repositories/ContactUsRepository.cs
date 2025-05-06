using Microsoft.EntityFrameworkCore;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.Domain.Models;
using OurResumeIR.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurResumeIR.Infra.Data.Repositories
{
    public class ContactUsRepository(AppDbContext context) : IContactUsRepository
    {
        public async Task<List<ContactUs>> GetAllAsync(string userId)
        {
           return await context.ContactUs.Where(a=>a.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<bool> CreateAsync(ContactUs model)
        {
            await context.ContactUs.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
