using Ecommerce.Core.DTO.AuhenticationDTO;
using Ecommerce.Core.Entities.ApplicationUser;

namespace Ecommerce.Core.ServiceContracts.Authentication;

public interface IAuthenticationServiceContract
{
    public Task<AuthenticationResponseDTO?>? Login(LoginDTO loginDTO);
    
    public Task<AuthenticationResponseDTO?> Register(RegistrationDTO registrationDTO);
    
    
}

