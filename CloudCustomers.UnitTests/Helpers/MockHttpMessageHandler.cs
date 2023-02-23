using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace CloudCustomers.UnitTests.Helpers;

/// <summary>
/// Set up for the purposes of being able to Mock the HttpClient
/// </summary>
internal static class MockHttpMessageHandler<T>
{
    /// <summary>
    /// Creates the setup we need in order to mock the httpclient when the SendAsync method is ran
    /// and it returns a HttpResonseMessage where Status Code is Ok it's content is the seriliazed expectedResponse that is passed in  
    /// </summary>
    /// <param name="expectedResponse">The content to be returned in the HttpResponseMessage</param>
    /// <returns>A static Mock where T is System.Net.Http.HttpMessageHandler</returns>
    internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)
    {
        // Creation of a response to be returned in our mocked HttpMessageHandler
        var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            
            Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
        };

        // set the content type of the header to be application/json
        mockResponse.Content.Headers.ContentType = 
            new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        var handlerMock = new Mock<HttpMessageHandler>();

        handlerMock
            .Protected() //Ensure this setup is protected
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),ItExpr.IsAny<CancellationToken>()) 
            .ReturnsAsync(mockResponse);

        return handlerMock;
    }

    /// <summary>
    /// Creates the setup we need in order to mock the httpclient when the SendAsync method is ran 
    /// and it returns a HttpResponseMessage where the status code is NotFound
    /// </summary>
    /// <returns>A static Mock where T is System.Net.Http.HttpMessageHandler</returns>
    internal static Mock<HttpMessageHandler> SetUpReturn404()
    {
        // Creation of a response to be returned in our mocked HttpMessageHandler
        var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
        {

            Content = new StringContent(string.Empty)
        };

        // set the content type of the header to be application/json
        mockResponse.Content.Headers.ContentType =
            new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        var handlerMock = new Mock<HttpMessageHandler>();

        handlerMock
            .Protected() //Ensure this setup is protected
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(mockResponse);

        return handlerMock;
    }
}

