using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class uno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpedienteCliente");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fechaexp",
                table: "Expedientes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "ExpedienteClientes",
                columns: table => new
                {
                    ExpedienteId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpedienteClientes", x => new { x.ExpedienteId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_ExpedienteClientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpedienteClientes_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpedienteClientes_ClienteId",
                table: "ExpedienteClientes",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpedienteClientes");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fechaexp",
                table: "Expedientes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "ExpedienteCliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpedienteCliente", x => new { x.ClienteId, x.ExpedienteId });
                    table.ForeignKey(
                        name: "FK_ExpedienteCliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpedienteCliente_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpedienteCliente_ExpedienteId",
                table: "ExpedienteCliente",
                column: "ExpedienteId");
        }
    }
}
