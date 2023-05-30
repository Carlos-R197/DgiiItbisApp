using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Api.Repositories.Contracts;

namespace Api.Controllers;


[ApiController]
[Route("/contributors")]
public class ContributorController : ControllerBase
{
    private readonly IContributorRepository contributorRepository;
    private readonly ILogger<ContributorController> logger;
    public ContributorController(IContributorRepository contributorRepository, ILogger<ContributorController> logger)
    {
        this.contributorRepository = contributorRepository;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contributor>>> GetContributors()
    {
        string? route = Request.Path.Value;
        try 
        {
            var contributors = await contributorRepository.GetContributors();
            logger.LogInformation($"{DateTime.Now.ToString("hh:mm:ss")}: Retrieved {contributors.Count()} items from {route}"); 
            return Ok(contributors);
        }
        catch (Exception ex)
        {
            logger.LogError($"{DateTime.Now.ToString("hh:mm:ss")}: Error at {route}; Message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
        }
    }
}