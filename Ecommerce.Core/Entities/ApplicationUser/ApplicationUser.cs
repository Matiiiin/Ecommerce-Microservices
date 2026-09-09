using System.ComponentModel.DataAnnotations;
using Ecommerce.Core.Entities.Enum;

namespace Ecommerce.Core.Entities.ApplicationUser;
/// <summary>
/// Define the application user class
/// </summary>
public class ApplicationUser
{
    [Key]
    public Guid UserId { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
}