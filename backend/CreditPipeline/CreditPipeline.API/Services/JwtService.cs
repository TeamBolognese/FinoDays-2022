using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CreditPipeline.API.Options;
using CreditPipeline.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CreditPipeline.API.Services;

public class JwtService
{
    private readonly ILogger<JwtService> _logger;
    private JwtOptions _jwtOptions;
    
    public JwtService(ILogger<JwtService> logger, IOptions<JwtOptions> jwtOptions)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _jwtOptions = jwtOptions.Value ?? throw  new ArgumentNullException(nameof(jwtOptions));
    }
    
    public string CreateJwt(User user, int minutesValid)
    {
        var subject = new ClaimsIdentity(new[]
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
            new Claim(ClaimTypes.GivenName, user.Name)
        });

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtOptions.Issuer,
            Audience = $"*.{_jwtOptions.Issuer}",
            IssuedAt = DateTime.UtcNow,
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(minutesValid),
            Subject = subject,
            SigningCredentials = new SigningCredentials(_jwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool ReadJwt(string token, out ClaimsPrincipal? claims, out DateTime validTo)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validations = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = _jwtOptions.GetSymmetricSecurityKey(),
            ValidateIssuer = true,
            ValidIssuer = _jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = $"*.{_jwtOptions.Issuer}",
            ValidateLifetime = true
        };
        try
        {
            claims = tokenHandler.ValidateToken(token, validations, out var validatedToken);
            validTo = validatedToken.ValidTo;
            return true;
        }
        catch (SecurityTokenException ex)
        {
            _logger.LogWarning(ex.ToString());
        }
        claims = null;
        validTo = DateTime.MinValue;
        return false;
    }
}