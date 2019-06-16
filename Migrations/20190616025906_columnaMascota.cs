using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePet.Migrations
{
    public partial class columnaMascota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Mascotas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Mascotas");
        }
    }
}
