using Api.Entities;

namespace Api.Repositories.Contracts; 

public interface IContributorRepository
{
    public Task<IEnumerable<Contributor>> GetContributorsAsync();
    public Task<bool> ContributorExistsAsync(string rnc);
}