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
        
        //Contributors
        modelBuilder.Entity<Contributor>().HasData(new Contributor 
        {
            RncIdentificationCard = "98754321012",
            Name = "JUAN PEREZ",
            Type = "PERSONA FISICA",
            Active = true
        });
        modelBuilder.Entity<Contributor>().HasData(new Contributor
        {
            RncIdentificationCard = "12345678957",
            Name = "FARMACIA TU SALUD",
            Type = "PERSONA JURIDICA",
            Active = false
        });
        modelBuilder.Entity<Contributor>().HasData(new Contributor
        {
            RncIdentificationCard = "56982214565",
            Name = "HORMIGONES PEDRO",
            Type = "PERSONA JURIDICA",
            Active = true
        });
        modelBuilder.Entity<Contributor>().HasData(new Contributor 
        {
            RncIdentificationCard = "93581769874",
            Name = "JORGE ALONZO",
            Type = "PERSONA FISICA",
            Active = true
        });
        modelBuilder.Entity<Contributor>().HasData(new Contributor 
        {
            RncIdentificationCard = "36971698521",
            Name = "ERIKA DIAZ",
            Type = "PERSONA FISICA",
            Active = false
        });

        //Receipts
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

        modelBuilder.Entity<TaxReceipt>().HasData(new TaxReceipt {
            RncIdentificationCard = "56982214565",
            NCF = "E310000000003",
            Amount = 6657.24M,
            Itbis18 = 1198.30M,
        });
        modelBuilder.Entity<TaxReceipt>().HasData(new TaxReceipt {
            RncIdentificationCard = "56982214565",
            NCF = "E310000000004",
            Amount = 4265.00M,
            Itbis18 = 767.70M,
        });

        modelBuilder.Entity<TaxReceipt>().HasData(new TaxReceipt {
            RncIdentificationCard = "36971698521",
            NCF = "E310000000005",
            Amount = 2354.21M,
            Itbis18 = 423.75M,
        });
        modelBuilder.Entity<TaxReceipt>().HasData(new TaxReceipt {
            RncIdentificationCard = "36971698521",
            NCF = "E310000000006",
            Amount = 364.00M,
            Itbis18 = 65.52M,
        });
        modelBuilder.Entity<TaxReceipt>().HasData(new TaxReceipt {
            RncIdentificationCard = "36971698521",
            NCF = "E310000000007",
            Amount = 500.00M,
            Itbis18 = 90.00M,
        });
    }
}