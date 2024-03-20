using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class migracion18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ElaboradoPor",
                table: "VersionSecafs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEmision",
                table: "VersionSecafs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRevision",
                table: "VersionSecafs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RevisadoPor",
                table: "VersionSecafs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProcesoId",
                table: "Expedientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    EntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false),
                    NombreDto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfidenceDto = table.Column<int>(type: "int", nullable: false),
                    RecognitionProcessOK = table.Column<bool>(type: "bit", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificacion = table.Column<int>(type: "int", nullable: false),
                    IdentificacionConfidence = table.Column<int>(type: "int", nullable: false),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C3FechaAtencion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.EntregaId);
                    table.ForeignKey(
                        name: "FK_Entregas_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hcu053s",
                columns: table => new
                {
                    Hcu53Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false),
                    NombreDto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfidenceDto = table.Column<int>(type: "int", nullable: false),
                    RecognitionProcessOK = table.Column<bool>(type: "bit", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificacion = table.Column<int>(type: "int", nullable: false),
                    IdentificacionConfidence = table.Column<int>(type: "int", nullable: false),
                    C8FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hcu053s", x => x.Hcu53Id);
                    table.ForeignKey(
                        name: "FK_Hcu053s_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    ResultadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false),
                    NombreDto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfidenceDto = table.Column<int>(type: "int", nullable: false),
                    RecognitionProcessOK = table.Column<bool>(type: "bit", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insumos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsumosConfidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConclusionesConfidence = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.ResultadoId);
                    table.ForeignKey(
                        name: "FK_Resultados_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_ProcesoId",
                table: "Expedientes",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_ExpedienteId",
                table: "Entregas",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hcu053s_ExpedienteId",
                table: "Hcu053s",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_ExpedienteId",
                table: "Resultados",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expedientes_Procesos_ProcesoId",
                table: "Expedientes",
                column: "ProcesoId",
                principalTable: "Procesos",
                principalColumn: "ProcesoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expedientes_Procesos_ProcesoId",
                table: "Expedientes");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Hcu053s");

            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropIndex(
                name: "IX_Expedientes_ProcesoId",
                table: "Expedientes");

            migrationBuilder.DropColumn(
                name: "ElaboradoPor",
                table: "VersionSecafs");

            migrationBuilder.DropColumn(
                name: "FechaEmision",
                table: "VersionSecafs");

            migrationBuilder.DropColumn(
                name: "FechaRevision",
                table: "VersionSecafs");

            migrationBuilder.DropColumn(
                name: "RevisadoPor",
                table: "VersionSecafs");

            migrationBuilder.AlterColumn<int>(
                name: "ProcesoId",
                table: "Expedientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
