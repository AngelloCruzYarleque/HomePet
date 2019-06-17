using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePet.Migrations
{
    public partial class precio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Precio",
                table: "TipoMascotas",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Adoptas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    DNI = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    NumeroCuenta = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<string>(nullable: true),
                    Ocupacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptas");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "TipoMascotas");
        }
    }
}
