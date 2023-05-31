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
    [Fact]
    public async void GetTaxReceiptsAsync_WithDefault_ReturnsOk()
    {
        // Arrange
        var repositoryStub = new Mock<ITaxReceiptRepository>();
        repositoryStub
            .Setup(t => t.GetTaxReceiptsAsync())
            .ReturnsAsync(new List<TaxReceipt>());
        var loggerStub = new Mock<ILogger<TaxReceiptController>>();
        
        var controller = new TaxReceiptController(repositoryStub.Object, loggerStub.Object);
        var request = new Mock<HttpRequest>();
        request.SetupGet(t => t.Path).Returns(new PathString(""));
        var httpContext = new Mock<HttpContext>();
        httpContext.SetupGet(t => t.Request).Returns(request.Object);
        //var actionContext = new ActionContext(httpContext.Object, new RouteData(), new ControllerActionDescriptor());
        var actionContext = new Mock<ActionContext>();
        actionContext.Object.HttpContext = httpContext.Object;
        actionContext.Object.RouteData = new RouteData();
        actionContext.Object.ActionDescriptor = new ControllerActionDescriptor();
        var controllerContext = new Mock<ControllerContext>(actionContext.Object);
        controller.ControllerContext = controllerContext.Object;
        // Act
        var response = await controller.GetTaxReceiptsAsync();
        var result = response.Result as OkObjectResult;
        //Assert 
        Assert.IsType<OkObjectResult>(response.Result);
        Assert.IsAssignableFrom<IEnumerable<TaxReceipt>>(result.Value);
    }
}