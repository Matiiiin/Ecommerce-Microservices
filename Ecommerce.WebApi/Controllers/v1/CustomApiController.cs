using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers.v1;

[ApiController]
[ApiVersion(1.0)]
[Route("api/v{apiversion:apiVersion}/}")]
public class CustomApiController : ControllerBase
{
    
}