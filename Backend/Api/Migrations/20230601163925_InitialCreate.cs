using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    RncIdentificationCard = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.RncIdentificationCard);
                });

            migrationBuilder.CreateTable(
                name: "TaxReceipts",
                columns: table => new
                {
                    NCF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RncIdentificationCard = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Itbis18 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReceipts", x => x.NCF);
                });

            migrationBuilder.InsertData(
                table: "Contributors",
                columns: new[] { "RncIdentificationCard", "Active", "Name", "Type" },
                values: new object[,]
                {
                    { "12345678957", false, "FARMACIA TU SALUD", "PERSONA JURIDICA" },
                    { "36971698521", false, "ERIKA DIAZ", "PERSONA FISICA" },
                    { "56982214565", true, "HORMIGONES PEDRO", "PERSONA JURIDICA" },
                    { "93581769874", true, "JORGE ALONZO", "PERSONA FISICA" },
                    { "98754321012", true, "JUAN PEREZ", "PERSONA FISICA" }
                });

            migrationBuilder.InsertData(
                table: "TaxReceipts",
                columns: new[] { "NCF", "Amount", "Itbis18", "RncIdentificationCard" },
                values: new object[,]
                {
                    { "E310000000001", 200.00m, 36.00m, "98754321012" },
                    { "E310000000002", 1000.00m, 180.00m, "98754321012" },
                    { "E310000000003", 6657.24m, 1198.30m, "56982214565" },
                    { "E310000000004", 4265.00m, 767.70m, "56982214565" },
                    { "E310000000005", 2354.21m, 423.75m, "36971698521" },
                    { "E310000000006", 364.00m, 65.52m, "36971698521" },
                    { "E310000000007", 500.00m, 90.00m, "36971698521" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "TaxReceipts");
        }
    }
}
