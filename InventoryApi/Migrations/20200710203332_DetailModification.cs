using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApi.Migrations
{
    public partial class DetailModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PODetailsidPODetails",
                table: "itemCatalog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemCatalog_PODetailsidPODetails",
                table: "itemCatalog",
                column: "PODetailsidPODetails");

            migrationBuilder.AddForeignKey(
                name: "FK_itemCatalog_PODetail_PODetailsidPODetails",
                table: "itemCatalog",
                column: "PODetailsidPODetails",
                principalTable: "PODetail",
                principalColumn: "idPODetails",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemCatalog_PODetail_PODetailsidPODetails",
                table: "itemCatalog");

            migrationBuilder.DropIndex(
                name: "IX_itemCatalog_PODetailsidPODetails",
                table: "itemCatalog");

            migrationBuilder.DropColumn(
                name: "PODetailsidPODetails",
                table: "itemCatalog");
        }
    }
}
