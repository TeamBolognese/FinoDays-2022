using CreditPipeline.Model;
using Microsoft.EntityFrameworkCore;

namespace CreditPipeline.API.Repositories;

public class StrategyHistoryRepository : IStrategyHistoryRepository
{
    private DatabaseContext _context;

    public StrategyHistoryRepository(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<StrategyHistory>> GetStrategyHistoriesAsync(Guid strategyId)
    {
        return await _context.StrategyHistories.Where(history => history.StrategyId == strategyId).ToListAsync();
    }

    public async Task<StrategyHistory> AddStrategyHistoryAsync(StrategyHistory strategyHistory)
    {
        var entityEntry = await _context.StrategyHistories.AddAsync(strategyHistory);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }
}