using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ComputerShopApi.Migrations
{
    public partial class Branch3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "ProductsSetProducts");

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SetProducts_Type_Id",
                table: "SetProducts",
                columns: new[] { "Type", "Id" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_Type_Id",
                table: "Products",
                columns: new[] { "Type", "Id" });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchProducts_Branches_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchProducts_Products_Type_ProductId",
                        columns: x => new { x.Type, x.ProductId },
                        principalTable: "Products",
                        principalColumns: new[] { "Type", "Id" });
                    table.ForeignKey(
                        name: "FK_BranchProducts_SetProducts_Type_ProductId",
                        columns: x => new { x.Type, x.ProductId },
                        principalTable: "SetProducts",
                        principalColumns: new[] { "Type", "Id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_ProductId",
                table: "BranchProducts",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_Type_ProductId",
                table: "BranchProducts",
                columns: new[] { "Type", "ProductId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchProducts");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_SetProducts_Type_Id",
                table: "SetProducts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_Type_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SetProducts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Author = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => new { x.Author, x.AuthorId });
                });

            migrationBuilder.CreateTable(
                name: "ProductsSetProducts",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "integer", nullable: false),
                    SetProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSetProducts", x => new { x.ProductsId, x.SetProductsId });
                    table.ForeignKey(
                        name: "FK_ProductsSetProducts_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsSetProducts_SetProducts_SetProductsId",
                        column: x => x.SetProductsId,
                        principalTable: "SetProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSetProducts_SetProductsId",
                table: "ProductsSetProducts",
                column: "SetProductsId");
        }
    }
}
