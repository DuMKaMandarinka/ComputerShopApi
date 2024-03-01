using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerShopApi.Migrations
{
    public partial class eererwere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts");

            migrationBuilder.DropIndex(
                name: "IX_BranchProducts_ProductId",
                table: "BranchProducts");

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_ProductId",
                table: "BranchProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts");

            migrationBuilder.DropIndex(
                name: "IX_BranchProducts_ProductId",
                table: "BranchProducts");

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts",
                column: "BranchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_ProductId",
                table: "BranchProducts",
                column: "ProductId",
                unique: true);
        }
    }
}
