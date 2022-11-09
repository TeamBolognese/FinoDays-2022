namespace CreditPipeline.API.Contracts.User;

public class AddUserDto
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// ЛОгин
    /// </summary>
    public string Login { get; set; } = string.Empty;
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = string.Empty;
}