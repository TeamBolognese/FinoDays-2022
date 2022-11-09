namespace CreditPipeline.Model;

/// <summary>
/// Заявка на кредит
/// </summary>
public class Request : Entity
{
    /// <summary>
    /// Идентификатор стратегии
    /// </summary>
    public Guid StrategyId { get; set; }

    /// <summary>
    /// Стратегия
    /// </summary>
    public Strategy Strategy { get; set; } = new();

    /// <summary>
    /// ИНН юр. лица
    /// </summary>
    public string Inn { get; set; } = string.Empty;
    
    /// <summary>
    /// Минимальная ставка по кредиту
    /// </summary>
    public  double MinDept { get; set; }
    
    /// <summary>
    /// Максимальный период
    /// </summary>
    public double Period { get; set; }
    
    /// <summary>
    /// Максимальная сумма
    /// </summary>
    public double Summa { get; set; }
    
    /// <summary>
    /// Дата создания версии
    /// </summary>
    public DateTime Created { get; set; }
}
