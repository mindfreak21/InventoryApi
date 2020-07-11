using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApi.Migrations
{
    public partial class Catalogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PODetail",
                columns: table => new
                {
                    idPODetails = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantiy = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PODetail", x => x.idPODetails);
                });

            migrationBuilder.CreateTable(
                name: "POHeader",
                columns: table => new
                {
                    idPO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PODetailsidPODetails = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POHeader", x => x.idPO);
                    table.ForeignKey(
                        name: "FK_POHeader_PODetail_PODetailsidPODetails",
                        column: x => x.PODetailsidPODetails,
                        principalTable: "PODetail",
                        principalColumn: "idPODetails",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customerCatalog",
                columns: table => new
                {
                    idCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(maxLength: 50, nullable: false),
                    POHeaderidPO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerCatalog", x => x.idCustomer);
                    table.ForeignKey(
                        name: "FK_customerCatalog_POHeader_POHeaderidPO",
                        column: x => x.POHeaderidPO,
                        principalTable: "POHeader",
                        principalColumn: "idPO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "statusOrder",
                columns: table => new
                {
                    idStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(maxLength: 50, nullable: false),
                    POHeaderidPO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusOrder", x => x.idStatus);
                    table.ForeignKey(
                        name: "FK_statusOrder_POHeader_POHeaderidPO",
                        column: x => x.POHeaderidPO,
                        principalTable: "POHeader",
                        principalColumn: "idPO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerCatalog_POHeaderidPO",
                table: "customerCatalog",
                column: "POHeaderidPO");

            migrationBuilder.CreateIndex(
                name: "IX_POHeader_PODetailsidPODetails",
                table: "POHeader",
                column: "PODetailsidPODetails");

            migrationBuilder.CreateIndex(
                name: "IX_statusOrder_POHeaderidPO",
                table: "statusOrder",
                column: "POHeaderidPO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerCatalog");

            migrationBuilder.DropTable(
                name: "statusOrder");

            migrationBuilder.DropTable(
                name: "POHeader");

            migrationBuilder.DropTable(
                name: "PODetail");
        }
    }
}
