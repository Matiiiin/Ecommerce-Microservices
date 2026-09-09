using System.Security.Claims;
using Ecommerce.Core.DTO.AuhenticationDTO;
using Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;
using Ecommerce.Core.ServiceContracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers.v1.Authentication;

[Route("[controller]/[action]")]
public class UserAuthenticationController : CustomApiController
{
    private readonly IAuthenticationServiceContract _authenticationService;

    public UserAuthenticationController(IAuthenticationServiceContract authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost]
    public async Task<IActionResult> Register([FromBody]RegistrationDTO registrationDTO)
    {
        var response =await _authenticationService.Register(registrationDTO);
        return response is null ? BadRequest("Email has already registered") : StatusCode(201 , response);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var response = await _authenticationService.Login(loginDTO)!;
        return response is null ? BadRequest("Invalid email or password") : StatusCode(200, response);
    }
    
}