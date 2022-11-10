using CreditPipeline.Model;
using Microsoft.EntityFrameworkCore;

namespace CreditPipeline.API.Repositories;

public class StrategyRepository : IStrategyRepository
{
    private DatabaseContext _context;

    public StrategyRepository(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Strategy?> GetStrategyAsync(Guid id)
    {
        return await _context.Strategies.FirstOrDefaultAsync(strategy => strategy.Id == id);
    }

    public IQueryable<Strategy> GetStrategiesAsync()
    {
        return _context.Strategies.AsQueryable();
    }

    public async Task<Strategy> AddStrategyAsync(Strategy strategy)
    {
        var entityEntry = await _context.Strategies.AddAsync(strategy);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }
}