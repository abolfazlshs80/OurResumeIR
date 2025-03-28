﻿using OurResumeIR.Domain.Models;
using System.Linq.Expressions;

namespace OurResumeIR.Domain.Interfaces;

public interface IExpertiseRepository
{

    Task<IQueryable<Experience>> FindAsync(Expression<Func<Experience, bool>> predicate);
    Task<Experience> CreateExpertise(Experience Expertise);
    Task<Experience> UpdateExpertise(Experience Expertise);
    Task<Experience> DeleteExpertise(int ExpertiseId);
    Task<Experience> SaveChanges();
}