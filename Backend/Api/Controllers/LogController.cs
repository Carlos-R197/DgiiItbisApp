using Microsoft.AspNetCore.Mvc;
using Api.Dtos;

namespace Api.Controllers;

[ApiController]
[Route("/error-logs")]
public class LogController : ControllerBase
{
    private readonly ILogger logger;

    public LogController(ILogger<LogController> logger)
    {
        this.logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<string>> PostLogAsync(PostLogRequestDto postLogRequestDto)
    {
        try 
        {
            logger.LogError($"{postLogRequestDto.DateTime}: Error at /error-logs; Message: {postLogRequestDto.Msg}; StackTrace: {postLogRequestDto.StackTrace}");
            return Ok("Error posted successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
        }
    }
}