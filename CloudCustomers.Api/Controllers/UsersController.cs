using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    public UsersController()
    {
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        return Ok("I'm the object yay!");
    }
}
