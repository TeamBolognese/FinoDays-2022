using CreditPipeline.Model;
using Microsoft.EntityFrameworkCore;

namespace CreditPipeline.API.Repositories;

public class StrategyMetricRelationRepository : IStrategyMetricRelationRepository
{
    private DatabaseContext _context;

    public StrategyMetricRelationRepository(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Metric>> GetMetricsByStrategyIdAsync(Guid strategyId)
    {
        return await _context.StrategyMetricRelations
            .Where(x => x.StrategyId == strategyId)
            .Select(x => x.Metric)
            .ToListAsync();
    }

    public async Task<StrategyMetricRelation> AddMetricToStrategyAsync(Guid strategyId, Metric metric)
    {
        var strategyMetricRelation = new StrategyMetricRelation
        {
            StrategyId = strategyId,
            MetricId = metric.Id
        };
        
        var entityEntry = await _context.StrategyMetricRelations.AddAsync(strategyMetricRelation);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<IEnumerable<StrategyMetricRelation>> AddMetricsToStrategyAsync(Guid strategyId, IEnumerable<Metric> metrics)
    {
        var strategyMetricRelations = metrics.Select(metric => new StrategyMetricRelation
        {
            StrategyId = strategyId,
            MetricId = metric.Id
        }).ToList();
        
        await _context.StrategyMetricRelations.AddRangeAsync(strategyMetricRelations);
        await _context.SaveChangesAsync();
        return strategyMetricRelations;
    }
}