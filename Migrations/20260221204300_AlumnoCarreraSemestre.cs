using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace actividad01.Migrations
{
    /// <inheritdoc />
    public partial class AlumnoCarreraSemestre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Carrera",
                table: "Alumnos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Semestre",
                table: "Alumnos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrera",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Semestre",
                table: "Alumnos");
        }
    }
}
