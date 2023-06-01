using Moq;
using Api.Repositories.Contracts;
using Api.Entities;
using Api.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Api.UnitTests;

public class ContributorControllerTests
{

    private readonly Mock<IContributorRepository> repositoryStub = new();
    private readonly Mock<ILogger<ContributorController>> loggerStub = new();

    [Fact]
    public async void GetContributorsAsync_WithDefault_ReturnsOk()
    {
        // Arrange
        repositoryStub.Setup(repo => repo.GetContributorsAsync())
            .ReturnsAsync(Enumerable.Empty<Contributor>());

        var controller = new ContributorController(repositoryStub.Object, loggerStub.Object);

        var request = new Mock<HttpRequest>();
        request.SetupGet(t => t.Path).Returns(new PathString(""));
        var httpContext = new Mock<HttpContext>();
        httpContext.SetupGet(t => t.Request).Returns(request.Object);
        var actionContext = new ActionContext(httpContext.Object, new RouteData(), new Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor());
        controller.ControllerContext = new ControllerContext(actionContext);
        // Act
        var result = await controller.GetContributorsAsync();
        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    // [Fact]
    // public async Task GetContributorsAsync_WithExistingContributors_ReturnsContributorsList()
    // {
    //     // Given
    //     var expectedResult = GetListOfRandomContributors();
    //     repositoryStub.Setup(t => t.GetContributorsAsync()).ReturnsAsync(expectedResult);
    //     var controller = new ContributorController(repositoryStub.Object, loggerStub.Object);
    //     // When
    //     var result = await controller.GetContributorsAsync();
    //     // Then
       
    //     // TODO: use fluent assertions to finish
        
    // }

    private IEnumerable<Contributor> GetListOfRandomContributors()
    {
        var list = new List<Contributor>();
        for (int i = 0; i < Random.Shared.Next(1, 20); i++)
        {
            list.Add(new Contributor 
            {
                RncIdentificationCard = Guid.NewGuid().ToString().Substring(0, 11),
                Name = Guid.NewGuid().ToString(),
                Type = GetRandomContributorType(),
                Active = Convert.ToBoolean(Random.Shared.Next(0, 2))
            });
        }
        return list;
    }

    private string GetRandomContributorType()
    {
        int rnd = Random.Shared.Next(0, 2);
        if (rnd == 0)
            return "PERSONA JURIDICA";
        else
            return "PERSONA FISICA";
    }
}