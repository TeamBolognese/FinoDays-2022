namespace CreditPipeline.API.Contracts.Strategy;

public class StrategyDto
{
    /// <summary>
    /// Наименование стратегии
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
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
    /// Метрики
    /// </summary>
    public Dictionary<string, object> Metrics { get; set; } = new();
}