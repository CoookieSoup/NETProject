using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET_first_project.Migrations
{
    /// <inheritdoc />
    public partial class RemovedBankTransactionDescriptionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BankTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BankTransactions",
                type: "TEXT",
                nullable: true);
        }
    }
}
