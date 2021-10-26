using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Entity_Framework.Migrations
{
    public partial class Version_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    User = table.Column<string>(maxLength: 20, nullable: true),
                    Contraseña = table.Column<byte[]>(nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    Apellido = table.Column<string>(maxLength: 80, nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Cuil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Celular = table.Column<int>(nullable: false),
                    Instagram = table.Column<string>(maxLength: 50, nullable: true),
                    Twitter = table.Column<string>(maxLength: 40, nullable: true),
                    Facebook = table.Column<string>(maxLength: 30, nullable: true),
                    EstudianteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contactos_Usuarios_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    DocenteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Usuarios_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    MateriaId = table.Column<Guid>(nullable: false),
                    EstudianteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Usuarios_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriasEstudiantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MateriaId = table.Column<Guid>(nullable: false),
                    EstudianteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasEstudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriasEstudiantes_Usuarios_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriasEstudiantes_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_EstudianteId",
                table: "Calificaciones",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_MateriaId",
                table: "Calificaciones",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_EstudianteId",
                table: "Contactos",
                column: "EstudianteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_DocenteId",
                table: "Materias",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasEstudiantes_EstudianteId",
                table: "MateriasEstudiantes",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasEstudiantes_MateriaId",
                table: "MateriasEstudiantes",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "MateriasEstudiantes");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
