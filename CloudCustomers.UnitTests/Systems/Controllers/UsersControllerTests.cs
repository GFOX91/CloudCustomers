using CloudCustomers.Api.Controllers;
using CloudCustomers.Api.Models;
using CloudCustomers.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomers.UnitTests.Systems.Controllers;

/// <summary>
/// Unit tests to test functionality of the Users Controller 
/// </summary>
public class UsersControllerTests
{
    /// <summary>
    /// When the get request is successful we should expect it to return a 200 Ok Http Status response code
    /// </summary>
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(s => s.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUsersService.Object); // the sut(System Under Test) 

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }

    /// <summary>
    /// When the get request is successful it should call have called the GetAllUsers method from the User Service precisely once 
    /// </summary>
    [Fact]
    public async Task Get_OnSuccess_InvokeUserServiceExactlyOnce()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(s => s.GetAllUsers())
            .ReturnsAsync(new List<User>());


        var sut = new UsersController(mockUsersService.Object);

        // Act
        var result = await sut.Get();

        // Assert
        mockUsersService.Verify(
            service => service.GetAllUsers(), 
            Times.Once);
    }
}