using Ecommerce.Core.Entities.Enum;

namespace Ecommerce.Core.Entities.ApplicationUser;
/// <summary>
/// Define the application user class
/// </summary>
public class ApplicationUser
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public Gender Gender { get; set; }
}