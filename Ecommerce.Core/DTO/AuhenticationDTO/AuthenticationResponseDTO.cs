using Ecommerce.Core.Entities.Enum;

namespace Ecommerce.Core.DTO.AuhenticationDTO;

public record AuthenticationResponseDTO(
    Guid UserId,
    string? Email,
    string? PersonName,
    Gender Gender ,
    string? Token,
    bool Success
    );

