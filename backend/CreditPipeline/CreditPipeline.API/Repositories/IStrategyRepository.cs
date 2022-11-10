using CreditPipeline.Model;

namespace CreditPipeline.API.Repositories;

public interface IStrategyRepository
{
    Task<Strategy?> GetStrategyAsync(Guid id);
    IQueryable<Strategy> GetStrategiesAsync();
    Task<Strategy> AddStrategyAsync(Strategy strategy);
}
