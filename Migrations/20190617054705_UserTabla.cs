using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePet.Migrations
{
    public partial class UserTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Adoptas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Adoptas");
        }
    }
}
