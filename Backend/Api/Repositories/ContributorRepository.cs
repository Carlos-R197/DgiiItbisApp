using Api.Entities;
using Api.Repositories.Contracts;
using Api.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class ContributorRepository : IContributorRepository
{
    private readonly ApiDbContext dbContext;

    public ContributorRepository(ApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Contributor>> GetContributorsAsync()
    {
        var contributors = await dbContext.Contributors.ToListAsync();
        return contributors;
    }
}