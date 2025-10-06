using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDataHub.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "varchar(20)", maxLength: 100, nullable: false),
                    Income = table.Column<decimal>(type: "numeric", nullable: false),
                    Debt = table.Column<decimal>(type: "numeric", nullable: false),
                    CreditHistoryYears = table.Column<int>(type: "integer", nullable: false),
                    PaymentHistoryJson = table.Column<string>(type: "varchar(1000)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.SSN);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
