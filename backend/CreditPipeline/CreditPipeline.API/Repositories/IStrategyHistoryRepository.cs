using CreditPipeline.Model;

namespace CreditPipeline.API.Repositories;

public interface IStrategyHistoryRepository
{
    Task<IEnumerable<StrategyHistory>> GetStrategyHistoriesAsync(Guid strategyId);
    Task<StrategyHistory> AddStrategyHistoryAsync(StrategyHistory strategyHistory);
}