using Api.Repositories.Contracts;
using Api.Entities;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class TaxReceiptRepository : ITaxReceiptRepository
{
    private readonly ApiDbContext dbContext;
    
    public TaxReceiptRepository(ApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<TaxReceipt>> GetTaxReceiptsAsync()
    {
        var taxReceipts = await dbContext.TaxReceipts.ToListAsync();
        return taxReceipts;
    }

    public async Task<IEnumerable<TaxReceipt>> GetTaxReceiptsAsync(string rnc)
    {
        var taxReceipts = await dbContext.TaxReceipts.Where(t => t.RncIdentificationCard == rnc).ToListAsync();
        return taxReceipts;
    }
}