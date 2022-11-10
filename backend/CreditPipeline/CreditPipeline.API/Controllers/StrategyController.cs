using CreditPipeline.API.Contracts.Strategy;
using CreditPipeline.API.Repositories;
using CreditPipeline.Model;
using Microsoft.AspNetCore.Mvc;

namespace CreditPipeline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StrategyController : ControllerBase
{
    private IStrategyRepository _strategyRepository;
    private IStrategyMetricRelationRepository _strategyMetricRelationRepository;
    private IMetricRepository _metricRepository;
    
    public StrategyController(IStrategyRepository strategyRepository, IStrategyMetricRelationRepository strategyMetricRelationRepository, IMetricRepository metricRepository)
    {
        _strategyRepository = strategyRepository ?? throw new ArgumentNullException(nameof(strategyRepository));
        _strategyMetricRelationRepository = strategyMetricRelationRepository ?? throw new ArgumentNullException(nameof(strategyMetricRelationRepository));
        _metricRepository = metricRepository ?? throw new ArgumentNullException(nameof(metricRepository));
    }
    
    [HttpGet]
    public IActionResult GetStrategies()
    {
        var strategies = _strategyRepository.GetStrategiesAsync();
        return Ok(strategies);
    }
    
    [HttpGet("{strategyId:guid}")]
    public async Task<IActionResult> GetStrategy(Guid strategyId)
    {
        var strategy = await _strategyRepository.GetStrategyAsync(strategyId);
        return Ok(strategy);
    }
    
    [HttpPatch("{strategyId:guid}")]
    public async Task<IActionResult> UpdateStrategy(Guid strategyId, [FromBody] StrategyDto updatedStrategyDto)
    {
        var strategy = await _strategyRepository.GetStrategyAsync(strategyId);
        if (strategy is null) return NotFound();
        
        strategy.Name = updatedStrategyDto.Name;
        strategy.MinDept = updatedStrategyDto.MinDept;
        strategy.MinDivorce = updatedStrategyDto.MinDivorce;
        strategy.MaxPeriod = updatedStrategyDto.MaxPeriod;
        strategy.MaxSumma = updatedStrategyDto.MaxSumma;

        
        
        //await _strategyRepository.UpdateStrategyAsync(strategyId, strategy);
        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddStrategy([FromBody] StrategyDto addStrategyDto)
    {
        var strategy = new Strategy
        {
            Id = Guid.NewGuid(),
            Name = addStrategyDto.Name,
            MinDept = addStrategyDto.MinDept,
            MinDivorce = addStrategyDto.MinDivorce,
            MaxPeriod = addStrategyDto.MaxPeriod,
            MaxSumma = addStrategyDto.MaxSumma
        };
        
        var metrics = addStrategyDto.Metrics.Select(metric => new Metric
        {
            Id = Guid.NewGuid(), 
            Name = metric.Key,
            Raw = metric.Value.ToString() ?? string.Empty,
        }).ToList();

        await _strategyRepository.AddStrategyAsync(strategy);
        await _strategyMetricRelationRepository.AddMetricsToStrategyAsync(strategy.Id, metrics);
        await _metricRepository.AddMetricsAsync(metrics);
        
        return Ok(strategy.Id);
    }
}
