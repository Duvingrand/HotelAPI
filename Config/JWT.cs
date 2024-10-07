using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;


namespace RepasoJWT.Config;

public class JWT
{
    public static string GenerateJwtToken(Employee employee)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier,employee.Id.ToString()),
            new Claim(ClaimTypes.Email,employee.Email),
        };

        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
        var jwtExpiresIn = Environment.GetEnvironmentVariable("JWT_EXPIRES_IN");

        // Validar que las variables existen
        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new InvalidOperationException("JWT configuration values are missing.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtExpiresIn)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
