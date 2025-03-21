using System.Linq.Expressions;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.Domain.Interfaces;

public interface IUserExpertiseRepository
{
    Task<IEnumerable<UserExpertise>> FindAsync(Expression<Func<UserExpertise, bool>> predicate);
    Task<IQueryable<UserExpertise>> GetAll();
    Task<IQueryable<UserExpertise>> GetAllDetails();
    Task<UserExpertise> GetByUserExpertiseId(int UserExpertiseId);
    Task<UserExpertise> GetByUserId(int UserExpertiseId);
    Task<UserExpertise> GetByExpertiseId(int UserExpertiseId);

 
    Task<UserExpertise> CreateUserExpertise(UserExpertise UserExpertise);
    Task<UserExpertise> UpdateUserExpertise(UserExpertise UserExpertise);
    Task<UserExpertise> DeleteUserExpertise(int UserExpertiseId);
    Task<UserExpertise> SaveChanges();
}