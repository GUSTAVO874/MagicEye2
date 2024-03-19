using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class migracion12 : Migration
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
                    ValidacionId = table.Column<int>(type: "int", nullable: true),
                    CoberturaId = table.Column<int>(type: "int", nullable: true),
                    ProcesoId = table.Column<int>(type: "int", nullable: true),
                    CoberturaMadre = table.Column<int>(type: "int", nullable: true),
                    CoberturaPadre = table.Column<int>(type: "int", nullable: true),
                    Hcu053Id = table.Column<int>(type: "int", nullable: true),
                    ResultadoId = table.Column<int>(type: "int", nullable: true),
                    EntregaId = table.Column<int>(type: "int", nullable: true),
                    NombreExpediente = table.Column<int>(type: "int", nullable: true),
                    DtosImprescindiblesOK = table.Column<bool>(type: "bit", nullable: true),
                    NumerodeDocumentos = table.Column<int>(type: "int", nullable: true),
                    Ignorar = table.Column<bool>(type: "bit", nullable: true),
                    ExpedienteRecognitionOK = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.ExpedienteId);
                });

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
                name: "Cobertura",
                columns: table => new
                {
                    CoberturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_Cobertura_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Validacions",
                columns: table => new
                {
                    ValidacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false),
                    NombreDto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfidenceDto = table.Column<int>(type: "int", nullable: true),
                    RecognitionProcessOK = table.Column<bool>(type: "bit", nullable: true),
                    NumSecDerivac = table.Column<int>(type: "int", nullable: true),
                    NumSecDerivacConfidence = table.Column<int>(type: "int", nullable: true),
                    UnidadqueDeriva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadqueDerivaConfidence = table.Column<int>(type: "int", nullable: true),
                    Unidad_A_queDerivan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unidad_A_queDerivanConfidence = table.Column<int>(type: "int", nullable: true),
                    C6Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C6NombresConfidence = table.Column<int>(type: "int", nullable: true),
                    C5Identificacion = table.Column<int>(type: "int", nullable: true),
                    C5IdentificacionConfidence = table.Column<int>(type: "int", nullable: true),
                    C4TipoSeguro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C4TipoSeguroConfidence = table.Column<int>(type: "int", nullable: true),
                    C9Edad = table.Column<int>(type: "int", nullable: true),
                    C9EdadConfidence = table.Column<int>(type: "int", nullable: true),
                    C7Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C7GeneroConfidence = table.Column<int>(type: "int", nullable: true),
                    TipoAfiliacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAfiliacionConfidence = table.Column<int>(type: "int", nullable: true),
                    C13Cie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C13CieConfidence = table.Column<int>(type: "int", nullable: true),
                    C11CodTarifario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C11CodTarifarioConfidence = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_Cobertura_ExpedienteId",
                table: "Cobertura",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procesos_VersionId",
                table: "Procesos",
                column: "VersionId");

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
                name: "Cobertura");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "Validacions");

            migrationBuilder.DropTable(
                name: "VersionSecafs");

            migrationBuilder.DropTable(
                name: "Expedientes");
        }
    }
}
