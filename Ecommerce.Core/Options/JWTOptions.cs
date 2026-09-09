namespace Ecommerce.Core.Options;

public class JWTOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpirationMinutes { get; set; }
    public Guid SecretKey { get; set; }
}