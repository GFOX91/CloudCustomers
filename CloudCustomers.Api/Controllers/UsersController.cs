using CloudCustomers.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        return Ok("I'm the object yay!");
    }
}
