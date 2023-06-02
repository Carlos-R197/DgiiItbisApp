﻿// <auto-generated />
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.Entities.Contributor", b =>
                {
                    b.Property<string>("RncIdentificationCard")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RncIdentificationCard");

                    b.ToTable("Contributors");

                    b.HasData(
                        new
                        {
                            RncIdentificationCard = "98754321012",
                            Active = true,
                            Name = "JUAN PEREZ",
                            Type = "PERSONA FISICA"
                        },
                        new
                        {
                            RncIdentificationCard = "103457957",
                            Active = false,
                            Name = "FARMACIA TU SALUD",
                            Type = "PERSONA JURIDICA"
                        },
                        new
                        {
                            RncIdentificationCard = "569814260",
                            Active = true,
                            Name = "HORMIGONES PEDRO",
                            Type = "PERSONA JURIDICA"
                        },
                        new
                        {
                            RncIdentificationCard = "93581769874",
                            Active = true,
                            Name = "JORGE ALONZO",
                            Type = "PERSONA FISICA"
                        },
                        new
                        {
                            RncIdentificationCard = "36971698521",
                            Active = false,
                            Name = "ERIKA DIAZ",
                            Type = "PERSONA FISICA"
                        });
                });

            modelBuilder.Entity("Api.Entities.TaxReceipt", b =>
                {
                    b.Property<string>("NCF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Itbis18")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RncIdentificationCard")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("NCF");

                    b.ToTable("TaxReceipts");

                    b.HasData(
                        new
                        {
                            NCF = "E310000000001",
                            Amount = 200.00m,
                            Itbis18 = 36.00m,
                            RncIdentificationCard = "98754321012"
                        },
                        new
                        {
                            NCF = "E310000000002",
                            Amount = 1000.00m,
                            Itbis18 = 180.00m,
                            RncIdentificationCard = "98754321012"
                        },
                        new
                        {
                            NCF = "E310000000003",
                            Amount = 6657.24m,
                            Itbis18 = 1198.30m,
                            RncIdentificationCard = "569814260"
                        },
                        new
                        {
                            NCF = "E310000000004",
                            Amount = 4265.00m,
                            Itbis18 = 767.70m,
                            RncIdentificationCard = "569814260"
                        },
                        new
                        {
                            NCF = "E310000000005",
                            Amount = 2354.21m,
                            Itbis18 = 423.75m,
                            RncIdentificationCard = "36971698521"
                        },
                        new
                        {
                            NCF = "E310000000006",
                            Amount = 364.00m,
                            Itbis18 = 65.52m,
                            RncIdentificationCard = "36971698521"
                        },
                        new
                        {
                            NCF = "E310000000007",
                            Amount = 500.00m,
                            Itbis18 = 90.00m,
                            RncIdentificationCard = "36971698521"
                        },
                        new
                        {
                            NCF = "E310000000008",
                            Amount = 1200.00m,
                            Itbis18 = 216.00m,
                            RncIdentificationCard = "103457957"
                        },
                        new
                        {
                            NCF = "E310000000009",
                            Amount = 1682.00m,
                            Itbis18 = 302.76m,
                            RncIdentificationCard = "103457957"
                        },
                        new
                        {
                            NCF = "E310000000010",
                            Amount = 635.58m,
                            Itbis18 = 114.40m,
                            RncIdentificationCard = "103457957"
                        },
                        new
                        {
                            NCF = "E310000000011",
                            Amount = 9821.20m,
                            Itbis18 = 1767.81m,
                            RncIdentificationCard = "103457957"
                        },
                        new
                        {
                            NCF = "E3100000000012",
                            Amount = 500.00m,
                            Itbis18 = 90.00m,
                            RncIdentificationCard = "103457957"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
