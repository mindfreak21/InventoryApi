using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApi.Migrations
{
    public partial class Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesidRol",
                table: "userItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idRol",
                table: "userItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "rolName",
                table: "userItems",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_userItems_RolesidRol",
                table: "userItems",
                column: "RolesidRol");

            migrationBuilder.AddForeignKey(
                name: "FK_userItems_userRoles_RolesidRol",
                table: "userItems",
                column: "RolesidRol",
                principalTable: "userRoles",
                principalColumn: "idRol",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userItems_userRoles_RolesidRol",
                table: "userItems");

            migrationBuilder.DropTable(
                name: "userRoles");

            migrationBuilder.DropIndex(
                name: "IX_userItems_RolesidRol",
                table: "userItems");

            migrationBuilder.DropColumn(
                name: "RolesidRol",
                table: "userItems");

            migrationBuilder.DropColumn(
                name: "idRol",
                table: "userItems");

            migrationBuilder.DropColumn(
                name: "rolName",
                table: "userItems");
        }
    }
}
