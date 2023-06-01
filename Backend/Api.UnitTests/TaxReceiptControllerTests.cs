using Moq;
using Api.Repositories.Contracts;
using Api.Entities;
using Api.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Api.UnitTests;

public class TaxReceiptControllerTests
{
    private readonly Mock<ITaxReceiptRepository> taxRepoStub = new();
    private readonly Mock<IContributorRepository> contributorRepoStub = new();
    private readonly Mock<ILogger<TaxReceiptController>> loggerStub = new();

    [Fact]
    public async void GetTaxReceiptsAsync_WithExistingContributor_ReturnsOk()
    {
        // Arrange
        taxRepoStub.Setup(t => t.GetTaxReceiptsAsync())
            .ReturnsAsync(new List<TaxReceipt>());
        contributorRepoStub.Setup(t => t.ContributorExistsAsync("52987455224"))
            .ReturnsAsync(true);
        
        var controller = new TaxReceiptController(taxRepoStub.Object, contributorRepoStub.Object, loggerStub.Object);
        // Act
        var result = await controller.GetTaxReceiptsAsync("52987455224");
        var okObjectResult = result.Result as OkObjectResult;
        // Assert 
        Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsAssignableFrom<IEnumerable<TaxReceipt>>(okObjectResult.Value);
    }

    [Fact]
    public async void GetTaxReceiptsAsync_WithInvalidContributor_ReturnsNotFound()
    {
        // Arrange
        taxRepoStub.Setup(t => t.GetTaxReceiptsAsync())
            .ReturnsAsync(new List<TaxReceipt>());
        contributorRepoStub.Setup(t => t.ContributorExistsAsync("69921108970"))
            .ReturnsAsync(false);
        
        var controller = new TaxReceiptController(taxRepoStub.Object, contributorRepoStub.Object, loggerStub.Object);
        // Act
        var result = await controller.GetTaxReceiptsAsync("69921108970");
        // Assert 
        Assert.IsType<NotFoundResult>(result.Result);
    }
}