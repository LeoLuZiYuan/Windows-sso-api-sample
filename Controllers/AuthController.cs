using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WindowsSsoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("ping")]
    [AllowAnonymous]
    public IActionResult Ping()
    {
        return Ok(new
        {
            Message = "API is running"
        });
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult Me()
    {
        var user = HttpContext.User;

        return Ok(new
        {
            Name = user.Identity?.Name,
            AuthenticationType = user.Identity?.AuthenticationType,
            IsAuthenticated = user.Identity?.IsAuthenticated,
            Claims = user.Claims.Select(c => new
            {
                c.Type,
                c.Value
            })
        });
    }

    [HttpGet("groups")]
    [Authorize]
    public IActionResult Groups()
    {
        var groups = HttpContext.User.Claims
            .Where(c =>
                c.Type == ClaimTypes.Role ||
                c.Type.Contains("group", StringComparison.OrdinalIgnoreCase) ||
                c.Type.Contains("role", StringComparison.OrdinalIgnoreCase))
            .Select(c => new
            {
                c.Type,
                c.Value
            });

        return Ok(groups);
    }
}
