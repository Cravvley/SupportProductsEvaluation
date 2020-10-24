using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportProductsEvaluation.Data.Migrations
{
    public partial class RemoveSubcategoryEntityAndAddShopPropositionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_SubCategory_SubCategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProposition_Product_ProductId",
                table: "ProductProposition");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProposition_AspNetUsers_UserId",
                table: "ProductProposition");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_ProductProposition_ProductId",
                table: "ProductProposition");

            migrationBuilder.DropIndex(
                name: "IX_Product_SubCategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductProposition");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Report",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProductProposition",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "ProductProposition",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductProposition",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductProposition",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductProposition",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "ProductProposition",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductProposition",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "ProductProposition",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShopProposition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopProposition_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Report_CategoryId",
                table: "Report",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProposition_CategoryId",
                table: "ProductProposition",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProposition_ShopId",
                table: "ProductProposition",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProposition_UserId",
                table: "ShopProposition",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProposition_Category_CategoryId",
                table: "ProductProposition",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProposition_Shop_ShopId",
                table: "ProductProposition",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProposition_AspNetUsers_UserId",
                table: "ProductProposition",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Category_CategoryId",
                table: "Report",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProposition_Category_CategoryId",
                table: "ProductProposition");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProposition_Shop_ShopId",
                table: "ProductProposition");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProposition_AspNetUsers_UserId",
                table: "ProductProposition");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Category_CategoryId",
                table: "Report");

            migrationBuilder.DropTable(
                name: "ShopProposition");

            migrationBuilder.DropIndex(
                name: "IX_Report_CategoryId",
                table: "Report");

            migrationBuilder.DropIndex(
                name: "IX_ProductProposition_CategoryId",
                table: "ProductProposition");

            migrationBuilder.DropIndex(
                name: "IX_ProductProposition_ShopId",
                table: "ProductProposition");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "ProductProposition");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductProposition");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductProposition");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductProposition");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ProductProposition");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductProposition");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "ProductProposition");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Report",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "Report",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProductProposition",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductProposition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProposition_ProductId",
                table: "ProductProposition",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryId",
                table: "Product",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SubCategory_SubCategoryId",
                table: "Product",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProposition_Product_ProductId",
                table: "ProductProposition",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProposition_AspNetUsers_UserId",
                table: "ProductProposition",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
