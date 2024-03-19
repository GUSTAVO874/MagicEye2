using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class migracion14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobertura_Expedientes_ExpedienteId",
                table: "Cobertura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cobertura",
                table: "Cobertura");

            migrationBuilder.RenameTable(
                name: "Cobertura",
                newName: "Coberturas");

            migrationBuilder.RenameIndex(
                name: "IX_Cobertura_ExpedienteId",
                table: "Coberturas",
                newName: "IX_Coberturas_ExpedienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coberturas",
                table: "Coberturas",
                column: "CoberturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coberturas_Expedientes_ExpedienteId",
                table: "Coberturas",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "ExpedienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coberturas_Expedientes_ExpedienteId",
                table: "Coberturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coberturas",
                table: "Coberturas");

            migrationBuilder.RenameTable(
                name: "Coberturas",
                newName: "Cobertura");

            migrationBuilder.RenameIndex(
                name: "IX_Coberturas_ExpedienteId",
                table: "Cobertura",
                newName: "IX_Cobertura_ExpedienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cobertura",
                table: "Cobertura",
                column: "CoberturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobertura_Expedientes_ExpedienteId",
                table: "Cobertura",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "ExpedienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
