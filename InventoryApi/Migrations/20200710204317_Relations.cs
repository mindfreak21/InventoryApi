using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApi.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerCatalog_POHeader_POHeaderidPO",
                table: "customerCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_itemCatalog_PODetail_PODetailsidPODetails",
                table: "itemCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_POHeader_PODetail_PODetailsidPODetails",
                table: "POHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_statusOrder_POHeader_POHeaderidPO",
                table: "statusOrder");

            migrationBuilder.DropIndex(
                name: "IX_statusOrder_POHeaderidPO",
                table: "statusOrder");

            migrationBuilder.DropIndex(
                name: "IX_POHeader_PODetailsidPODetails",
                table: "POHeader");

            migrationBuilder.DropIndex(
                name: "IX_itemCatalog_PODetailsidPODetails",
                table: "itemCatalog");

            migrationBuilder.DropIndex(
                name: "IX_customerCatalog_POHeaderidPO",
                table: "customerCatalog");

            migrationBuilder.DropColumn(
                name: "POHeaderidPO",
                table: "statusOrder");

            migrationBuilder.DropColumn(
                name: "PODetailsidPODetails",
                table: "POHeader");

            migrationBuilder.DropColumn(
                name: "PODetailsidPODetails",
                table: "itemCatalog");

            migrationBuilder.DropColumn(
                name: "POHeaderidPO",
                table: "customerCatalog");

            migrationBuilder.AddColumn<int>(
                name: "CustomeridCustomer",
                table: "POHeader",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusPurchaseOrderidStatus",
                table: "POHeader",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemidItem",
                table: "PODetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "POHeaderidPO",
                table: "PODetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_POHeader_CustomeridCustomer",
                table: "POHeader",
                column: "CustomeridCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_POHeader_StatusPurchaseOrderidStatus",
                table: "POHeader",
                column: "StatusPurchaseOrderidStatus");

            migrationBuilder.CreateIndex(
                name: "IX_PODetail_ItemidItem",
                table: "PODetail",
                column: "ItemidItem");

            migrationBuilder.CreateIndex(
                name: "IX_PODetail_POHeaderidPO",
                table: "PODetail",
                column: "POHeaderidPO");

            migrationBuilder.AddForeignKey(
                name: "FK_PODetail_itemCatalog_ItemidItem",
                table: "PODetail",
                column: "ItemidItem",
                principalTable: "itemCatalog",
                principalColumn: "idItem",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PODetail_POHeader_POHeaderidPO",
                table: "PODetail",
                column: "POHeaderidPO",
                principalTable: "POHeader",
                principalColumn: "idPO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_POHeader_customerCatalog_CustomeridCustomer",
                table: "POHeader",
                column: "CustomeridCustomer",
                principalTable: "customerCatalog",
                principalColumn: "idCustomer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_POHeader_statusOrder_StatusPurchaseOrderidStatus",
                table: "POHeader",
                column: "StatusPurchaseOrderidStatus",
                principalTable: "statusOrder",
                principalColumn: "idStatus",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PODetail_itemCatalog_ItemidItem",
                table: "PODetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PODetail_POHeader_POHeaderidPO",
                table: "PODetail");

            migrationBuilder.DropForeignKey(
                name: "FK_POHeader_customerCatalog_CustomeridCustomer",
                table: "POHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_POHeader_statusOrder_StatusPurchaseOrderidStatus",
                table: "POHeader");

            migrationBuilder.DropIndex(
                name: "IX_POHeader_CustomeridCustomer",
                table: "POHeader");

            migrationBuilder.DropIndex(
                name: "IX_POHeader_StatusPurchaseOrderidStatus",
                table: "POHeader");

            migrationBuilder.DropIndex(
                name: "IX_PODetail_ItemidItem",
                table: "PODetail");

            migrationBuilder.DropIndex(
                name: "IX_PODetail_POHeaderidPO",
                table: "PODetail");

            migrationBuilder.DropColumn(
                name: "CustomeridCustomer",
                table: "POHeader");

            migrationBuilder.DropColumn(
                name: "StatusPurchaseOrderidStatus",
                table: "POHeader");

            migrationBuilder.DropColumn(
                name: "ItemidItem",
                table: "PODetail");

            migrationBuilder.DropColumn(
                name: "POHeaderidPO",
                table: "PODetail");

            migrationBuilder.AddColumn<int>(
                name: "POHeaderidPO",
                table: "statusOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PODetailsidPODetails",
                table: "POHeader",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PODetailsidPODetails",
                table: "itemCatalog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "POHeaderidPO",
                table: "customerCatalog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_statusOrder_POHeaderidPO",
                table: "statusOrder",
                column: "POHeaderidPO");

            migrationBuilder.CreateIndex(
                name: "IX_POHeader_PODetailsidPODetails",
                table: "POHeader",
                column: "PODetailsidPODetails");

            migrationBuilder.CreateIndex(
                name: "IX_itemCatalog_PODetailsidPODetails",
                table: "itemCatalog",
                column: "PODetailsidPODetails");

            migrationBuilder.CreateIndex(
                name: "IX_customerCatalog_POHeaderidPO",
                table: "customerCatalog",
                column: "POHeaderidPO");

            migrationBuilder.AddForeignKey(
                name: "FK_customerCatalog_POHeader_POHeaderidPO",
                table: "customerCatalog",
                column: "POHeaderidPO",
                principalTable: "POHeader",
                principalColumn: "idPO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_itemCatalog_PODetail_PODetailsidPODetails",
                table: "itemCatalog",
                column: "PODetailsidPODetails",
                principalTable: "PODetail",
                principalColumn: "idPODetails",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_POHeader_PODetail_PODetailsidPODetails",
                table: "POHeader",
                column: "PODetailsidPODetails",
                principalTable: "PODetail",
                principalColumn: "idPODetails",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_statusOrder_POHeader_POHeaderidPO",
                table: "statusOrder",
                column: "POHeaderidPO",
                principalTable: "POHeader",
                principalColumn: "idPO",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
