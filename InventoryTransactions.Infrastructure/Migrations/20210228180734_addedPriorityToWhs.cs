using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryTransactions.Infrastructure.Migrations
{
    public partial class addedPriorityToWhs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Warehouses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Warehouses");
        }
    }
}
