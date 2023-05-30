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
    public async Task<ActionResult<IEnumerable<TaxReceipt>>> GetTaxReceipts()
    {
        string? route = Request.Path.Value;
        try 
        {
            var taxReceipts = await taxReceiptRepository.GetTaxReceipts(); 
            logger.LogInformation($"{DateTime.Now.ToString("hh:mm:ss")}: Retrieved {taxReceipts.Count()} items from {route}"); 
            return Ok(taxReceipts);
        }
        catch (Exception ex)
        {
            logger.LogError($"{DateTime.Now.ToString("hh:mm:ss")}: Error at {route}; Message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
        }
    }
}