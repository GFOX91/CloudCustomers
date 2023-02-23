using CloudCustomers.Api.Models;
using CloudCustomers.Api.Services;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using Moq;
using Moq.Protected;

namespace CloudCustomers.UnitTests.Systems.Services;

public class UsersServiceTests
{
    /// <summary>
    /// Verify that HttpClient.SendAsync is called once and it is a Get request
    /// </summary>
    [Fact]
    public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
    {
        // Arrange
        var expectedResponse = UsersFixture.GetTestUsers();

        var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UsersService(httpClient);

        // Act
        await sut.GetAllUsers();

        // Assert
        handlerMock
            .Protected()
            .Verify(
            "SendAsync", 
            Times.Exactly(1), 
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
            ItExpr.IsAny<CancellationToken>()
            );
    }
}

