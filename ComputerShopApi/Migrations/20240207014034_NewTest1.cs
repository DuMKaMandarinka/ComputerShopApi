using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerShopApi.Migrations
{
    public partial class NewTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
