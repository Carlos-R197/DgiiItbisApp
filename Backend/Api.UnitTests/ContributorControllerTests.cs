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
    private readonly Mock<IContributorRepository> contributorRepoStub = new();
    private readonly Mock<ILogger<ContributorController>> loggerStub = new();

    [Fact]
    public async void GetContributorsAsync_ReturnsContributors()
    {
        // Arrange
        contributorRepoStub.Setup(c => c.GetContributorsAsync())
            .ReturnsAsync(() => GetListOfRandomContributors());

        var controller = new ContributorController(contributorRepoStub.Object, loggerStub.Object);
        // Act
        var result = (await controller.GetContributorsAsync()).Result as OkObjectResult;
        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.IsAssignableFrom<IEnumerable<Contributor>>(result.Value);
        Assert.NotEmpty(result.Value as IEnumerable<Contributor>);
    }

    [Fact]
    public async void GetContributorsAsync_WithNullRepo_Returns500()
    {
        // Arrange
        contributorRepoStub.Setup(c => c.GetContributorsAsync())
            .ReturnsAsync(() => null);
        var controller = new ContributorController(contributorRepoStub.Object, loggerStub.Object);
        // Act
        var result = (await controller.GetContributorsAsync()).Result as ObjectResult;
        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
    }

    private IEnumerable<Contributor> GetListOfRandomContributors()
    {
        var list = new List<Contributor>();
        for (int i = 0; i < Random.Shared.Next(2, 20); i++)
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