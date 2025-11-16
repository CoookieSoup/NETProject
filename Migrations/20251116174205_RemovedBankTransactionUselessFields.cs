using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET_first_project.Migrations
{
    /// <inheritdoc />
    public partial class RemovedBankTransactionUselessFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "BankTransactions");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "BankTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "BankTransactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "BankTransactions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
