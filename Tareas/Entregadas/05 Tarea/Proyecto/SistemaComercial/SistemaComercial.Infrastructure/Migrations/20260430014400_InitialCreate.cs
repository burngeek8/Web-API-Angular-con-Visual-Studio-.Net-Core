using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaComercial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cargos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre_completo_nombres = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nombre_completo_apellido_paterno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nombre_completo_apellido_materno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    numero_documento_valor = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    numero_documento_tipo = table.Column<string>(type: "text", nullable: false),
                    correo_empresarial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    salario_monto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    salario_moneda = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    codigo_empleado = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    estado = table.Column<string>(type: "text", nullable: false),
                    cargo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_empleados", x => x.id);
                    table.ForeignKey(
                        name: "fk_empleados_cargos_cargo_id",
                        column: x => x.cargo_id,
                        principalTable: "cargos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_empleados_cargo_id",
                table: "empleados",
                column: "cargo_id");

            migrationBuilder.CreateIndex(
                name: "ix_empleados_codigo_empleado",
                table: "empleados",
                column: "codigo_empleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_empleados_correo_empresarial",
                table: "empleados",
                column: "correo_empresarial",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "cargos");
        }
    }
}
