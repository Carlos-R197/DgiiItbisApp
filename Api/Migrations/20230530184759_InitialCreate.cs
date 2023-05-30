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
                    RncIdentificationCard = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    RncIdentificationCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Itbis18 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    { "123456789", false, "FARMACIA TU SALUD", "PERSONA JURIDICA" },
                    { "98754321012", true, "JUAN PEREZ", "PERSONA FISICA" }
                });

            migrationBuilder.InsertData(
                table: "TaxReceipts",
                columns: new[] { "NCF", "Amount", "Itbis18", "RncIdentificationCard" },
                values: new object[,]
                {
                    { "E310000000001", 200.00m, 36.00m, "98754321012" },
                    { "E310000000002", 1000.00m, 180.00m, "98754321012" }
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
