using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePet.Migrations
{
    public partial class DataCorrecta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_MascotaEdad_EdadId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_MascotaTamano_TamanoId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_MascotaTipoPelo_TipoPeloId",
                table: "Mascotas");

            migrationBuilder.DropTable(
                name: "MascotaEdad");

            migrationBuilder.DropTable(
                name: "MascotaTamano");

            migrationBuilder.DropTable(
                name: "MascotaTipoPelo");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_EdadId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_TamanoId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_TipoPeloId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "EdadId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "TamanoId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "TipoPeloId",
                table: "Mascotas");

            migrationBuilder.AddColumn<string>(
                name: "Edad",
                table: "Mascotas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tamano",
                table: "Mascotas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoPelo",
                table: "Mascotas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Tamano",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "TipoPelo",
                table: "Mascotas");

            migrationBuilder.AddColumn<int>(
                name: "EdadId",
                table: "Mascotas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TamanoId",
                table: "Mascotas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPeloId",
                table: "Mascotas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MascotaEdad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEdad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotaEdad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MascotaTamano",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTamano = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotaTamano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MascotaTipoPelo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipoPelo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotaTipoPelo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_EdadId",
                table: "Mascotas",
                column: "EdadId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_TamanoId",
                table: "Mascotas",
                column: "TamanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_TipoPeloId",
                table: "Mascotas",
                column: "TipoPeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_MascotaEdad_EdadId",
                table: "Mascotas",
                column: "EdadId",
                principalTable: "MascotaEdad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_MascotaTamano_TamanoId",
                table: "Mascotas",
                column: "TamanoId",
                principalTable: "MascotaTamano",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_MascotaTipoPelo_TipoPeloId",
                table: "Mascotas",
                column: "TipoPeloId",
                principalTable: "MascotaTipoPelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
