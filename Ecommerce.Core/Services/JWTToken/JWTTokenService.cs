using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.Options;
using Ecommerce.Core.ServiceContracts.JWTToken;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Ecommerce.Core.Services.JWTToken;

public class JWTTokenService :IJWTTokenServiceContract
{
    private readonly IOptions<JWTOptions> _options;

    public JWTTokenService(IOptions<JWTOptions> options)
    {
        _options = options;
    }
public Task<string> GenerateJWTToken(ApplicationUser user)
{
    // Read JWT settings once from the configured JwtOptions instance.
    var jwtOptions = _options.Value;

    // Fail early if required configuration or user data is missing.
    // A JWT must have a secret key, and the email is used as the user's identity claim.
    var secretKey = jwtOptions?.SecretKey.ToString()
        ?? throw new InvalidOperationException("JWT secret key is not configured.");

    var email = user.Email
        ?? throw new InvalidOperationException("The user does not have an email address.");

    // Convert the configured secret into bytes and create the key used to sign tokens.
    // Use a long, random secret (at least 32 bytes for HMAC-SHA256).
    var signingKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(secretKey));

    // Define the signing algorithm used to prevent token tampering.
    var credentials = new SigningCredentials(
        signingKey,
        SecurityAlgorithms.HmacSha256);

    // Add identity data to the token.
    // Never add sensitive fields such as a password or password hash.
    var claims = new List<Claim>
    {
        new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
        new(JwtRegisteredClaimNames.Email, email),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    // Create the token with its issuer, intended audience, expiration time,
    // identity claims, and cryptographic signing credentials.
    var token = new JwtSecurityToken(
        issuer: jwtOptions.Issuer,
        audience: jwtOptions.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(jwtOptions.ExpirationMinutes),
        signingCredentials: credentials);

    // Serialize the JWT object into the compact string returned to the client.
    var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

    // No database/network operation occurs here, so wrap the result
    // to preserve your existing Task<string> method signature.
    return Task.FromResult(tokenValue);
}
}