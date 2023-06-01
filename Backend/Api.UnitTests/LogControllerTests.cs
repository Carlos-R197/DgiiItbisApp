using Microsoft.Extensions.Logging;
using Moq;
using Api.Controllers;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;

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
        var result = await controller.PostLogAsync(postLogRequestDto);
        var okObjectResult = (OkObjectResult)result.Result;
        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal("Error posted successfully", okObjectResult.Value);
    }
}