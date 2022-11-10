using CreditPipeline.Model;

namespace CreditPipeline.API.Repositories;

public interface IRequestRepository
{
    Task<Request?> GetRequestAsync(Guid id);
    
    Task<IEnumerable<Request>> GetRequestsByStrategyAsync(Guid strategyId);
    
    Task<Request> AddRequestAsync(Request request);
}