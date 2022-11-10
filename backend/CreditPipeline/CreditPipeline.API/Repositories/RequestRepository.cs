using CreditPipeline.Model;
using Microsoft.EntityFrameworkCore;

namespace CreditPipeline.API.Repositories;

public class RequestRepository : IRequestRepository
{
    private DatabaseContext _context;

    public RequestRepository(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Request?> GetRequestAsync(Guid id)
    {
        return await _context.Requests.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Request>> GetRequestsByStrategyAsync(Guid strategyId)
    {
        return await _context.Requests.Where(r => r.StrategyId == strategyId).ToListAsync();
    }

    public async Task<Request> AddRequestAsync(Request request)
    {
        var entityEntry = await _context.Requests.AddAsync(request);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }
}