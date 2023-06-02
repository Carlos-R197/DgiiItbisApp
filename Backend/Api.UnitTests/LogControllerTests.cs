using Microsoft.Extensions.Logging;
using Moq;
using Api.Controllers;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Api.UnitTests;

public class LogControllerTests
{
    private readonly Mock<ILogger<LogController>> loggerStub = new();

    [Fact]
    public async void PostLog_Valid_ReturnsOk()
    {
        // Arrange
        var controller = new LogController(loggerStub.Object);
        var postLogRequestDto = new PostLogRequestDto 
        {
            DateTime = DateTime.Now,
            Msg = "Test msg",
            StackTrace = "Test stack trace"
        };
        // Act
        var result = (await controller.PostLogAsync(postLogRequestDto)).Result as OkObjectResult;
        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal("Error posted successfully", result.Value);
    }
    
    [Fact]
    public async void PostLog_WithNull_Returns500()
    {
        // Arrange
        var controller = new LogController(loggerStub.Object);
        // Act
        var result = (await controller.PostLogAsync(null as PostLogRequestDto)).Result as ObjectResult;
        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
    }
}