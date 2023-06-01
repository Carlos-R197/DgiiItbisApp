using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Api.Repositories.Contracts;

namespace Api.Controllers;


[ApiController]
[Route("/contributors")]
public class ContributorController : ControllerBase
{
    private readonly IContributorRepository contributorRepository;
    private readonly ILogger logger;
    public ContributorController(IContributorRepository contributorRepository, ILogger<ContributorController> logger)
    {
        this.contributorRepository = contributorRepository;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contributor>>> GetContributorsAsync()
    {
        try 
        {
            var contributors = await contributorRepository.GetContributorsAsync();
            logger.LogInformation($"Retrieved {contributors.Count()} items from /contributors"); 
            return Ok(contributors);
        }
        catch (Exception ex)
        {
            logger.LogError($"Error retrieving at /contributors; Message: {ex.Message}; StackTrace: {ex.StackTrace}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
        }
    }
}