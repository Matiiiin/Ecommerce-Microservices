using Ecommerce.Core.DTO.AuhenticationDTO;
using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;
using Ecommerce.Core.ServiceContracts.ApplicationUserSecurity;
using Ecommerce.Core.ServiceContracts.Authentication;
using Ecommerce.Core.ServiceContracts.JWTToken;
using Ecommerce.Core.Services.JWTToken;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.Services.Authentication;

/// <summary>
/// Handles user registration and login, including password validation and JWT generation.
/// </summary>
public class AuthenticationService : IAuthenticationServiceContract
{
    // Repository used to retrieve users by email.
    private readonly IApplicationUserGetterRepository _applicationUserGetterRepository;

    // Repository used to save newly registered users.
    private readonly IApplicationAdderRepository _applicationUserAdderRepository;

    // Service responsible for validating a user's password.
    private readonly IPasswordCheckerServiceContract _passwordCheckerService;

    // Service responsible for creating JWT access tokens.
    private readonly IJWTTokenServiceContract _jwtTokenService;

    /// <summary>
    /// Initializes the authentication service with its required dependencies.
    /// </summary>
    public AuthenticationService(
        IApplicationUserGetterRepository applicationUserGetterRepository,
        IApplicationAdderRepository applicationUserAdderRepository,
        IPasswordCheckerServiceContract passwordCheckerService,
        IJWTTokenServiceContract jwtTokenService)
    {
        _applicationUserGetterRepository = applicationUserGetterRepository;
        _applicationUserAdderRepository = applicationUserAdderRepository;
        _passwordCheckerService = passwordCheckerService;
        _jwtTokenService = jwtTokenService;
    }

    /// <summary>
    /// Authenticates a user using their email and password.
    /// </summary>
    /// <param name="loginDTO">The email and password submitted by the user.</param>
    /// <returns>User information and a JWT token when authentication succeeds.</returns>
    public async Task<AuthenticationResponseDTO?> Login(LoginDTO loginDTO)
    {
        // Find the user associated with the submitted email address.
        var user = await _applicationUserGetterRepository.GetUserByEmail(loginDTO.Email);

        // Stop login if no matching account exists.
        if (user is null)
        {
            throw new Exception("Invalid email");
        }

        // Verify that the supplied password matches the stored hashed password.
        var correctPassword = await _passwordCheckerService.CheckPassword(user, loginDTO.Password);

        // Stop login if the password is incorrect.
        if (correctPassword is false)
        {
            throw new Exception("Invalid password");
        }

        // Create a JWT token for the authenticated user.
        var token = await _jwtTokenService.GenerateJWTToken(user);

        // Return safe user details along with the generated token.
        return new AuthenticationResponseDTO(
            UserId : user.UserId,
            Email : user.Email,
            Gender : user.Gender,
            PersonName : user.PersonName,
            Token : token,
            Success : true);
    }

    /// <summary>
    /// Creates a new user account and returns a JWT token for the new user.
    /// </summary>
    /// <param name="registrationDTO">The registration details submitted by the user.</param>
    /// <returns>The newly created user's details and JWT token.</returns>
    public async Task<AuthenticationResponseDTO?> Register(RegistrationDTO registrationDTO)
    {
        // Check whether an account already uses the submitted email address.
        var foundUser = await _applicationUserGetterRepository.GetUserByEmail(registrationDTO.Email);

        // Prevent duplicate email registrations.
        if (foundUser is not null)
        {
            throw new Exception("Email already registered");
        }

        // Create the user entity from registration details.
        var createdUser = new ApplicationUser
        {
            UserId = Guid.NewGuid(),
            Email = registrationDTO.Email,
            Gender = registrationDTO.Gender,
            PersonName = registrationDTO.PersonName
        };

        // Hash the password before storing it in the database.
        var hashedPassword = new PasswordHasher<ApplicationUser>()
            .HashPassword(createdUser, registrationDTO.Password);

        createdUser.Password = hashedPassword;

        // Save the user and retrieve the inserted record.
        var insertedUser = await _applicationUserAdderRepository.AddUserAsync(createdUser);

        // Generate a JWT token so the new user can immediately authenticate.
        var token = await _jwtTokenService.GenerateJWTToken(insertedUser);

        // Return the registration result and token.
        return new AuthenticationResponseDTO(
            UserId : insertedUser.UserId,
            Email : insertedUser.Email,
            Gender : insertedUser.Gender,
            PersonName : insertedUser.PersonName,
            Success : true,
            Token : token
            )
        ;
    }
}