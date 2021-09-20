using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook03.DataAccess.Data.Migrations
{
    public partial class AddOrderStatusToModelOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "OrderHeaders");
        }
    }
}
