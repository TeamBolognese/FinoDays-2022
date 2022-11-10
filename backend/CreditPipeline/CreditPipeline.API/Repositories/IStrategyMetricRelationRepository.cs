using CreditPipeline.Model;

namespace CreditPipeline.API.Repositories;

public interface IStrategyMetricRelationRepository
{
    Task<IEnumerable<Metric>> GetMetricsByStrategyIdAsync(Guid strategyId);
    
    Task<StrategyMetricRelation> AddMetricToStrategyAsync(Guid strategyId, Metric metric);
    
    Task<IEnumerable<StrategyMetricRelation>> AddMetricsToStrategyAsync(Guid strategyId, IEnumerable<Metric> metrics);
}