using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaComercial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmpleadoClavePlano : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "clave",
                table: "empleados",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clave",
                table: "empleados");
        }
    }
}
