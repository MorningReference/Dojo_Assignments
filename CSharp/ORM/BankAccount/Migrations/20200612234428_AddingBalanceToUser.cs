using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAccount.Migrations
{
    public partial class AddingBalanceToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
