using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class yy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Expedientes",
                newName: "Fechaexp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fechaexp",
                table: "Expedientes",
                newName: "Fecha");
        }
    }
}
