using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePet.Migrations
{
    public partial class colum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "exDueno",
                table: "Mascotas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "exDueno",
                table: "Mascotas");
        }
    }
}
