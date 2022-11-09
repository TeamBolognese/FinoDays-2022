namespace CreditPipeline.Model;

/// <summary>
/// Модель метрики
/// </summary>
public class Metric : Entity
{
    /// <summary>
    /// Наименование метрики
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Необработанные данные метрики
    /// </summary>
    public string Raw { get; set; } = string.Empty;
}
