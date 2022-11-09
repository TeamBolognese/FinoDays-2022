namespace CreditPipeline.Model;

/// <summary>
/// Стратегия
/// </summary>
public class Strategy : Entity
{
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
}