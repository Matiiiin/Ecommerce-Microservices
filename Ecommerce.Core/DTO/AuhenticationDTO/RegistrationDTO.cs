using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Core.Entities.Enum;

namespace Ecommerce.Core.DTO.AuhenticationDTO;

public record RegistrationDTO(
    string? Email,
    string? PersonName,
    string? Password,
    Gender Gender
);

