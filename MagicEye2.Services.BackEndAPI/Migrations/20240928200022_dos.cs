using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class dos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacientePrestacion");

            migrationBuilder.DropTable(
                name: "Prestaciones");

            migrationBuilder.AddColumn<int>(
                name: "MaestroTBeneficiarioId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaestroTBeneficiarios",
                columns: table => new
                {
                    MaestroTBeneficiarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestroTBeneficiarios", x => x.MaestroTBeneficiarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_MaestroTBeneficiarioId",
                table: "Pacientes",
                column: "MaestroTBeneficiarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_MaestroTBeneficiarios_MaestroTBeneficiarioId",
                table: "Pacientes",
                column: "MaestroTBeneficiarioId",
                principalTable: "MaestroTBeneficiarios",
                principalColumn: "MaestroTBeneficiarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_MaestroTBeneficiarios_MaestroTBeneficiarioId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "MaestroTBeneficiarios");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_MaestroTBeneficiarioId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "MaestroTBeneficiarioId",
                table: "Pacientes");

            migrationBuilder.CreateTable(
                name: "Prestaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacientePrestacion",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    PrestacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientePrestacion", x => new { x.PacienteId, x.PrestacionId });
                    table.ForeignKey(
                        name: "FK_PacientePrestacion_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacientePrestacion_Prestaciones_PrestacionId",
                        column: x => x.PrestacionId,
                        principalTable: "Prestaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacientePrestacion_PrestacionId",
                table: "PacientePrestacion",
                column: "PrestacionId");
        }
    }
}
