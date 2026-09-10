using Ecommerce.Core.DTO.AuhenticationDTO;
using FluentValidation;

namespace Ecommerce.Core.Validators.DTO.AuthenticationDTO;

public class RegistrationDTOValidator : AbstractValidator<RegistrationDTO>
{
    public RegistrationDTOValidator()
    {
        //Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        //Personname
        RuleFor(x => x.PersonName)
            .NotEmpty().WithMessage("Person name is required.")
            .Length(2, 100).WithMessage("Person name must be between 2 and 100 characters.");

        //Password
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).+$")
            .WithMessage("Password must include an uppercase letter, lowercase letter, number, and special character.");

        //Gender
        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("A valid gender value is required.");
    }
}