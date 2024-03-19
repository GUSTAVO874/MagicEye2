using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class migracion4 : Migration
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
