using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemCatalog",
                columns: table => new
                {
                    idItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(maxLength: 50, nullable: false),
                    unitOfMeasure = table.Column<string>(maxLength: 15, nullable: false),
                    quantityInStock = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemCatalog", x => x.idItem);
                });

            migrationBuilder.CreateTable(
                name: "userRoles",
                columns: table => new
                {
                    idRol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoles", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "userItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(maxLength: 15, nullable: false),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    idRol = table.Column<int>(nullable: false),
                    rolName = table.Column<string>(maxLength: 50, nullable: false),
                    RolesidRol = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_userItems_userRoles_RolesidRol",
                        column: x => x.RolesidRol,
                        principalTable: "userRoles",
                        principalColumn: "idRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userItems_RolesidRol",
                table: "userItems",
                column: "RolesidRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemCatalog");

            migrationBuilder.DropTable(
                name: "userItems");

            migrationBuilder.DropTable(
                name: "userRoles");
        }
    }
}
