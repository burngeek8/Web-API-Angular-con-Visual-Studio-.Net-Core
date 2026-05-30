using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empleado.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexCargoNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_cargos_nombre",
                table: "cargos",
                column: "nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_cargos_nombre",
                table: "cargos");
        }
    }
}
