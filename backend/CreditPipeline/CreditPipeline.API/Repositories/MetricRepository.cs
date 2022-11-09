using CreditPipeline.Model;
using Microsoft.EntityFrameworkCore;

namespace CreditPipeline.API.Repositories;

public class MetricRepository : IMetricRepository
{
    private DatabaseContext _context;

    public MetricRepository(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public IQueryable<Metric> GetMetricsAsync()
    {
        return _context.Metrics.AsQueryable();
    }

    public async Task<Metric> AddAsync(Metric metric)
    {
        var entityEntry = await _context.Metrics.AddAsync(metric);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<Metric?> GetMetricAsync(Guid metricId)
    {
        return await _context.Metrics.FirstOrDefaultAsync(m => m.Id == metricId);
    }

    public async Task<IEnumerable<Metric>> GetMetricCollectionAsync(IEnumerable<Guid> metricIds)
    {
        return await _context.Metrics.Where(m => metricIds.Contains(m.Id)).ToListAsync();
    }
}