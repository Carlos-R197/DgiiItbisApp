using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Api.Repositories.Contracts;

namespace Api.Controllers;

[ApiController]
[Route("/tax-receipts")]
public class TaxReceiptController : ControllerBase
{
    private readonly ITaxReceiptRepository taxReceiptRepository;
    private readonly IContributorRepository contributorRepository;
    private readonly ILogger logger;

    public TaxReceiptController(ITaxReceiptRepository taxReceiptRepository,
        IContributorRepository contributorRepository, ILogger<TaxReceiptController> logger)
    {
        this.taxReceiptRepository = taxReceiptRepository;
        this.contributorRepository = contributorRepository;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaxReceipt>>> GetTaxReceiptsAsync()
    {
        try 
        {
            var taxReceipts = await taxReceiptRepository.GetTaxReceiptsAsync(); 
            logger.LogInformation($"Retrieved {taxReceipts.Count()} items from /tax-receipts"); 
            return Ok(taxReceipts);
        }
        catch (Exception ex)
        {
            logger.LogError($"Error retrieving at /tax-receipts; Message: {ex.Message}; StackTrace: {ex.StackTrace}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
        }
    }

    [HttpGet("{rnc}")]
    public async Task<ActionResult<IEnumerable<TaxReceipt>>> GetTaxReceiptsAsync(string rnc)
    {
        try 
        {
            bool isRncValid = await contributorRepository.ContributorExistsAsync(rnc); 
            if (!isRncValid)
            {
                return NotFound();
            }

            var taxReceipts = await taxReceiptRepository.GetTaxReceiptsAsync(rnc); 
            logger.LogInformation($"Retrieved {taxReceipts.Count()} items from /tax-receipts using the id {rnc}"); 
            return Ok(taxReceipts);
        }
        catch (Exception ex)
        {
            logger.LogError($"Error retrieving at /tax-receipts; Message: {ex.Message}; StackTrace: {ex.StackTrace}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
        }
    }
}