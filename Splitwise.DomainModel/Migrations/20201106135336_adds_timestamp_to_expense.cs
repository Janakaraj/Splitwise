using Microsoft.EntityFrameworkCore.Migrations;

namespace Splitwise.DomainModel.Migrations
{
    public partial class adds_timestamp_to_expense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpenseAddTimeStamp",
                table: "Expenses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseAddTimeStamp",
                table: "Expenses");
        }
    }
}
