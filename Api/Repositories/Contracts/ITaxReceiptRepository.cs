using Api.Entities;

namespace Api.Repositories.Contracts;

public interface ITaxReceiptRepository
{
    public Task<IEnumerable<TaxReceipt>> GetTaxReceipts();
}