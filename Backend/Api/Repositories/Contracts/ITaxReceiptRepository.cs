using Api.Entities;

namespace Api.Repositories.Contracts;

public interface ITaxReceiptRepository
{
    public Task<IEnumerable<TaxReceipt>> GetTaxReceiptsAsync();
    public Task<IEnumerable<TaxReceipt>> GetTaxReceiptsAsync(string rnc);
}