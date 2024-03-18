using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    ExpedienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidacionId = table.Column<int>(type: "int", nullable: false),
                    ProcesoId = table.Column<int>(type: "int", nullable: false),
                    CoberturaId = table.Column<int>(type: "int", nullable: false),
                    CoberturaMadre = table.Column<int>(type: "int", nullable: true),
                    CoberturaPadre = table.Column<int>(type: "int", nullable: true),
                    Hcu053Id = table.Column<int>(type: "int", nullable: false),
                    ResultadoId = table.Column<int>(type: "int", nullable: false),
                    EntregaId = table.Column<int>(type: "int", nullable: false),
                    NombreExpediente = table.Column<int>(type: "int", nullable: false),
                    DtosImprescindiblesOK = table.Column<bool>(type: "bit", nullable: false),
                    NumerodeDocumentos = table.Column<int>(type: "int", nullable: false),
                    Ignorar = table.Column<bool>(type: "bit", nullable: false),
                    ExpedienteRecognitionOK = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.ExpedienteId);
                });

            migrationBuilder.CreateTable(
                name: "Validacions",
                columns: table => new
                {
                    ValidacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false),
                    NombreDto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfidenceDto = table.Column<int>(type: "int", nullable: false),
                    RecognitionProcessOK = table.Column<bool>(type: "bit", nullable: false),
                    NumSecDerivac = table.Column<int>(type: "int", nullable: false),
                    NumSecDerivacConfidence = table.Column<int>(type: "int", nullable: false),
                    UnidadqueDeriva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadqueDerivaConfidence = table.Column<int>(type: "int", nullable: false),
                    Unidad_A_queDerivan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidad_A_queDerivanConfidence = table.Column<int>(type: "int", nullable: false),
                    C6Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C6NombresConfidence = table.Column<int>(type: "int", nullable: false),
                    C5Identificacion = table.Column<int>(type: "int", nullable: false),
                    C5IdentificacionConfidence = table.Column<int>(type: "int", nullable: false),
                    C4TipoSeguro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C4TipoSeguroConfidence = table.Column<int>(type: "int", nullable: false),
                    C9Edad = table.Column<int>(type: "int", nullable: false),
                    C9EdadConfidence = table.Column<int>(type: "int", nullable: false),
                    C7Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C7GeneroConfidence = table.Column<int>(type: "int", nullable: false),
                    TipoAfiliacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAfiliacionConfidence = table.Column<int>(type: "int", nullable: false),
                    C13Cie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C13CieConfidence = table.Column<int>(type: "int", nullable: false),
                    C11CodTarifario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C11CodTarifarioConfidence = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validacions", x => x.ValidacionId);
                    table.ForeignKey(
                        name: "FK_Validacions_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Validacions_ExpedienteId",
                table: "Validacions",
                column: "ExpedienteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Validacions");

            migrationBuilder.DropTable(
                name: "Expedientes");
        }
    }
}
