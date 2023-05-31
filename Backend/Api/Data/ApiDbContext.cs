using Microsoft.EntityFrameworkCore;
using Api.Entities;

namespace Api.Data;

public class ApiDbContext : DbContext
{
    protected readonly IConfiguration configuration;

    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<TaxReceipt> TaxReceipts { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options, IConfiguration config) : base(options)
    {
        configuration = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(configuration.GetConnectionString("ApiDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Contributor>().HasData(new Contributor 
        {
            RncIdentificationCard = "98754321012",
            Name = "JUAN PEREZ",
            Type = "PERSONA FISICA",
            Active = true
        });
        modelBuilder.Entity<Contributor>().HasData(new Contributor
        {
            RncIdentificationCard = "123456789578",
            Name = "FARMACIA TU SALUD",
            Type = "PERSONA JURIDICA",
            Active = false
        });

        modelBuilder.Entity<TaxReceipt>().HasData(new TaxReceipt {
            RncIdentificationCard = "98754321012",
            NCF = "E310000000001",
            Amount = 200.00M,
            Itbis18 = 36.00M,
        });
        modelBuilder.Entity<TaxReceipt>().HasData(new TaxReceipt {
            RncIdentificationCard = "98754321012",
            NCF = "E310000000002",
            Amount = 1000.00M,
            Itbis18 = 180.00M,
        });
    }
}