using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class migracion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validacions_Expedientes_ExpedienteId",
                table: "Validacions");

            migrationBuilder.DropIndex(
                name: "IX_Validacions_ExpedienteId",
                table: "Validacions");

            migrationBuilder.AlterColumn<int>(
                name: "ExpedienteId",
                table: "Validacions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cobertura",
                columns: table => new
                {
                    CoberturaId = table.Column<int>(type: "int", nullable: false),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false),
                    NombreDto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfidenceDto = table.Column<int>(type: "int", nullable: true),
                    RecognitionProcessOK = table.Column<bool>(type: "bit", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificacion = table.Column<int>(type: "int", nullable: true),
                    IdentificacionConfidence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobertura", x => x.CoberturaId);
                    table.ForeignKey(
                        name: "FK_Cobertura_Expedientes_CoberturaId",
                        column: x => x.CoberturaId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Validacions_ExpedienteId",
                table: "Validacions",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Validacions_Expedientes_ExpedienteId",
                table: "Validacions",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "ExpedienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validacions_Expedientes_ExpedienteId",
                table: "Validacions");

            migrationBuilder.DropTable(
                name: "Cobertura");

            migrationBuilder.DropIndex(
                name: "IX_Validacions_ExpedienteId",
                table: "Validacions");

            migrationBuilder.AlterColumn<int>(
                name: "ExpedienteId",
                table: "Validacions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Validacions_ExpedienteId",
                table: "Validacions",
                column: "ExpedienteId",
                unique: true,
                filter: "[ExpedienteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Validacions_Expedientes_ExpedienteId",
                table: "Validacions",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "ExpedienteId");
        }
    }
}
