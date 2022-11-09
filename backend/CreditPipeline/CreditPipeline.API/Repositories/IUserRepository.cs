using CreditPipeline.Model;

namespace CreditPipeline.API.Repositories;

public interface IUserRepository
{
    IQueryable<User> GetAllUsers();

    Task<User> Add(User user);
    
    Task<User?> GetUserByIdAsync(Guid id);  
    
    Task<User?> GetUserByLoginAsync(string login);  
}
