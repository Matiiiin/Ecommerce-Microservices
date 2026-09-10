using Ecommerce.Core.DTO.AuhenticationDTO;
using FluentValidation;

namespace Ecommerce.Core.Validators.DTO.AuthenticationDTO;

public class LoginDTOValidator : AbstractValidator<LoginDTO>
{
    public LoginDTOValidator()
    {
        //Email
        RuleFor(loginDTO => loginDTO.Email)
            .NotEmpty().WithMessage("Email is required")
            .NotNull()
            .EmailAddress().WithMessage("Provide a valid email address");
        
        //password
        RuleFor(LoginDTO => LoginDTO.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .NotNull();
    }
}