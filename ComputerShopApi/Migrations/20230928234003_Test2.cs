using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerShopApi.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Info",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "Author1",
                table: "Info");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Info",
                table: "Info",
                columns: new[] { "Author", "AuthorId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Info",
                table: "Info");

            migrationBuilder.AddColumn<string>(
                name: "Author1",
                table: "Info",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Info",
                table: "Info",
                columns: new[] { "Author1", "AuthorId" });
        }
    }
}
