namespace CreditPipeline.Model;

/// <summary>
/// История стратегии
/// </summary>
public class StrategyHistory : Entity
{
    /// <summary>
    /// Идентификатор стратегии
    /// </summary>
    public Guid StrategyId { get; set; }

    /// <summary>
    /// Стратегия
    /// </summary>
    public virtual Strategy Strategy { get; set; } = new();
    
    /// <summary>
    /// Версия стратегии
    /// </summary>
    public int Version { get; set; }
    
    /// <summary>
    /// Дата создания версии
    /// </summary>
    public DateTime Created { get; set; }
}
