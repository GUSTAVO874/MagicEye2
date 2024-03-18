using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VersionSecafs",
                columns: table => new
                {
                    VersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionSecafs", x => x.VersionId);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    ProcesoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionId = table.Column<int>(type: "int", nullable: false),
                    MesAnioProceso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpedientesOrdYNumeradosOK = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.ProcesoId);
                    table.ForeignKey(
                        name: "FK_Procesos_VersionSecafs_VersionId",
                        column: x => x.VersionId,
                        principalTable: "VersionSecafs",
                        principalColumn: "VersionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procesos_VersionId",
                table: "Procesos",
                column: "VersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "VersionSecafs");
        }
    }
}
