using CloudCustomers.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class UsersControllerTests
{
    /// <summary>
    /// When the get request is successful we should expect it to return a 200 Ok Http Status response code
    /// </summary>
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange
        var sut = new UsersController(); // the sut(System Under Test) 

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }
}