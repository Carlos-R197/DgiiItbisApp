using Api.Entities;

namespace Api.Repositories.Contracts; 

public interface IContributorRepository
{
    public Task<IEnumerable<Contributor>> GetContributors();
}