namespace CreditPipeline.Model;

/// <summary>
/// Связь между стратегией и метрикой
/// </summary>
public class StrategyMetricRelation : Entity
{
    /// <summary>
    /// Идентификатор стратегии
    /// </summary>
    public int StrategyId { get; set; }
    
    /// <summary>
    /// Стратегия
    /// </summary>
    public Strategy Strategy { get; set; } = new();
    
    /// <summary>
    /// Идентификатор метрики
    /// </summary>
    public int MetricId { get; set; }
    
    /// <summary>
    /// Метрика
    /// </summary>
    public Metric Metric { get; set; } = new();
}
