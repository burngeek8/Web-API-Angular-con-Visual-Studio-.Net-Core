using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaComercial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVentasCursosAlumnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alumnos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombres = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    direccion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ciudad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alumnos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cantidad_horas = table.Column<int>(type: "integer", nullable: false),
                    precio = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    alumno_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ventas", x => x.id);
                    table.ForeignKey(
                        name: "fk_ventas_alumnos_alumno_id",
                        column: x => x.alumno_id,
                        principalTable: "alumnos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_ventas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venta_id = table.Column<Guid>(type: "uuid", nullable: false),
                    curso_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    precio = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_detalle_ventas", x => x.id);
                    table.ForeignKey(
                        name: "fk_detalle_ventas_cursos_curso_id",
                        column: x => x.curso_id,
                        principalTable: "cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_detalle_ventas_ventas_venta_id",
                        column: x => x.venta_id,
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_detalle_ventas_curso_id",
                table: "detalle_ventas",
                column: "curso_id");

            migrationBuilder.CreateIndex(
                name: "ix_detalle_ventas_venta_id",
                table: "detalle_ventas",
                column: "venta_id");

            migrationBuilder.CreateIndex(
                name: "ix_ventas_alumno_id",
                table: "ventas",
                column: "alumno_id");

            migrationBuilder.CreateIndex(
                name: "ix_ventas_serie_numero",
                table: "ventas",
                columns: new[] { "serie", "numero" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_ventas");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "alumnos");
        }
    }
}
