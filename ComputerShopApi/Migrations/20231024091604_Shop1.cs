using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ComputerShopApi.Migrations
{
    public partial class Shop1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_Branches_ProductId",
                table: "BranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_Products_Type_ProductId",
                table: "BranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_SetProducts_Type_ProductId",
                table: "BranchProducts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_SetProducts_Type_Id",
                table: "SetProducts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_Type_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_BranchProducts_Type_ProductId",
                table: "BranchProducts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SetProducts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SetProducts");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "SetProducts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SetProducts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BranchProducts");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SetProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "BranchProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceSetProduct",
                columns: table => new
                {
                    DevicesId = table.Column<int>(type: "integer", nullable: false),
                    SetProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceSetProduct", x => new { x.DevicesId, x.SetProductsId });
                    table.ForeignKey(
                        name: "FK_DeviceSetProduct_Devices_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceSetProduct_SetProducts_SetProductsId",
                        column: x => x.SetProductsId,
                        principalTable: "SetProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetProducts_ProductId",
                table: "SetProducts",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts",
                column: "BranchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ProductId",
                table: "Devices",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceSetProduct_SetProductsId",
                table: "DeviceSetProduct",
                column: "SetProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_Branches_BranchId",
                table: "BranchProducts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_Products_ProductId",
                table: "BranchProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetProducts_Products_ProductId",
                table: "SetProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_Branches_BranchId",
                table: "BranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_Products_ProductId",
                table: "BranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SetProducts_Products_ProductId",
                table: "SetProducts");

            migrationBuilder.DropTable(
                name: "DeviceSetProduct");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_SetProducts_ProductId",
                table: "SetProducts");

            migrationBuilder.DropIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SetProducts");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "BranchProducts");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SetProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SetProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "SetProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SetProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BranchProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SetProducts_Type_Id",
                table: "SetProducts",
                columns: new[] { "Type", "Id" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_Type_Id",
                table: "Products",
                columns: new[] { "Type", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_Type_ProductId",
                table: "BranchProducts",
                columns: new[] { "Type", "ProductId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_Branches_ProductId",
                table: "BranchProducts",
                column: "ProductId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_Products_Type_ProductId",
                table: "BranchProducts",
                columns: new[] { "Type", "ProductId" },
                principalTable: "Products",
                principalColumns: new[] { "Type", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_SetProducts_Type_ProductId",
                table: "BranchProducts",
                columns: new[] { "Type", "ProductId" },
                principalTable: "SetProducts",
                principalColumns: new[] { "Type", "Id" });
        }
    }
}
