namespace CreditPipeline.Model;

/// <summary>
/// Стратегия
/// </summary>
public class Strategy : Entity
{
    /// <summary>
    /// Наименование стратегии
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Версия стратегии
    /// </summary>
    public int Version { get; set; }
    
    /// <summary>
    /// Минимальная ставка по кредиту
    /// </summary>
    public  double MinDept { get; set; }
    
    /// <summary>
    /// Минимальный рейтинг для неодобрения заявки
    /// </summary>
    public double MinDivorce { get; set; }
    
    /// <summary>
    /// Максимальный период
    /// </summary>
    public double MaxPeriod { get; set; }
    
    /// <summary>
    /// Максимальная сумма
    /// </summary>
    public double MaxSumma { get; set; }

    /// <summary>
    /// Метрики стратегии
    /// </summary>
    public virtual ICollection<StrategyMetricRelation> StrategyMetricRelations { get; set; } =
        new List<StrategyMetricRelation>();
    
    /// <summary>
    /// Заявки стратегии
    /// </summary>
    public virtual ICollection<Request> Requests { get; set; } =
        new List<Request>();
    
    /// <summary>
    /// История изменений стратегии
    /// </summary>
    public virtual ICollection<StrategyHistory> StrategyHistories { get; set; } =
        new List<StrategyHistory>();
}