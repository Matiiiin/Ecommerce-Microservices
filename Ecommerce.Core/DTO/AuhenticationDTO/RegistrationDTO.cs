using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Core.Entities.Enum;

namespace Ecommerce.Core.DTO.AuhenticationDTO;

public record RegistrationDTO(
    [Required]
    [EmailAddress]
    string? Email,

    [Required]
    [StringLength(100, MinimumLength = 2)]
    string? PersonName,

    [Required]
    [MinLength(8)]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).+$",
        ErrorMessage = "Password must include an uppercase letter, lowercase letter, number, and special character."
    )]
    string? Password,

    [EnumDataType(typeof(Gender))]
    Gender Gender
);

