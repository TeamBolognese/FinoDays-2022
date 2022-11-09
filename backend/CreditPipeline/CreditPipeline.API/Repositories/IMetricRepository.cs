using CreditPipeline.Model;

namespace CreditPipeline.API.Repositories;

public interface IMetricRepository
{
    IQueryable<Metric> GetMetricsAsync();
    Task<Metric> AddAsync(Metric metric);
    Task<Metric?> GetMetricAsync(Guid metricId);
    Task<IEnumerable<Metric>> GetMetricCollectionAsync(IEnumerable<Guid> metricIds);
}