using CloudCustomers.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.Api.Controllers;

/// <summary>
/// The controller responsible for all CRUD operations regarding users
/// </summary>
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    /// <summary>
    /// The dependencies I require for my class are...
    /// </summary>
    /// <param name="usersService"></param>
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    /// <summary>
    /// Returns a list of all users
    /// </summary>
    /// <returns>An IActionResult where the value is a list of users</returns>
    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var users = await _usersService.GetAllUsers();

        if (users.Any())
        {
            return Ok(users);
        }

        return NotFound();    
    }
}
