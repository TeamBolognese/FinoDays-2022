namespace CreditPipeline.Model;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
}
