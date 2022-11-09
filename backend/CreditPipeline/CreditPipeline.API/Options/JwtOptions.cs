using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CreditPipeline.API.Options;

/// <summary>
/// Опции для чтения JWT (токенов авторизации)
/// </summary>
public class JwtOptions
{
    /// <summary>
    /// Token issuer
    /// </summary>
    public string Issuer { get; set; } = "CreditPipeline";

    /// <summary>
    /// Security key для токенов
    /// </summary>
    public string SecurityKey { get; set; } = "Pa$$w0rd_Pa$$w0rd_Pa$$w0rd";

    /// <summary>
    /// Получить symmetric security key
    /// </summary>
    public SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.ASCII.GetBytes(SecurityKey));
}