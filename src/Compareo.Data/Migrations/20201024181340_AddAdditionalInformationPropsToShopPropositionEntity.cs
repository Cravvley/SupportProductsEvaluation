using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportProductsEvaluation.Data.Migrations
{
    public partial class AddAdditionalInformationPropsToShopPropositionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "ShopProposition",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "ShopProposition");
        }
    }
}
