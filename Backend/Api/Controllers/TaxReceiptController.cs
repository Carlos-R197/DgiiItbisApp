using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Api.Repositories.Contracts;

namespace Api.Controllers;

[ApiController]
[Route("/tax-receipts")]
public class TaxReceiptController : ControllerBase
{
    private readonly ITaxReceiptRepository taxReceiptRepository;
    private readonly ILogger<TaxReceiptController> logger;

    public TaxReceiptController(ITaxReceiptRepository taxReceiptRepository, ILogger<TaxReceiptController> logger)
    {
        this.taxReceiptRepository = taxReceiptRepository;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaxReceipt>>> GetTaxReceiptsAsync()
    {
        string? route = Request.Path.Value;
        try 
        {
            var taxReceipts = await taxReceiptRepository.GetTaxReceiptsAsync(); 
            logger.LogInformation($"{DateTime.Now.ToString("hh:mm:ss")}: Retrieved {taxReceipts.Count()} items from {route}"); 
            return Ok(taxReceipts);
        }
        catch (Exception ex)
        {
            logger.LogError($"{DateTime.Now.ToString("hh:mm:ss")}: Error at {route}; Message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
        }
    }

    [HttpGet("{rnc}")]
    public async Task<ActionResult<IEnumerable<TaxReceipt>>> GetTaxReceiptsAsync(string rnc)
    {
        string? route = Request.Path.Value;
        try 
        {
            var taxReceipts = await taxReceiptRepository.GetTaxReceiptsAsync(rnc); 
            logger.LogInformation($"{DateTime.Now.ToString("hh:mm:ss")}: Retrieved " +
                $"{taxReceipts.Count()} items from {route} using the id {rnc}"); 
            return Ok(taxReceipts);
        }
        catch (Exception ex)
        {
            logger.LogError($"{DateTime.Now.ToString("hh:mm:ss")}: Error at {route}; Message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
        }
    }
}