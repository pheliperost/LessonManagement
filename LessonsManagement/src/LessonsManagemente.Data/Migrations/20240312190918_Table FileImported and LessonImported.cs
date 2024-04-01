using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LessonsManagement.Data.Migrations
{
    public partial class TableFileImportedandLessonImported : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileImported",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FilePath = table.Column<string>(type: "varchar(100)", nullable: true),
                    FileDescription = table.Column<string>(type: "varchar(40)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileImported", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonImported",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileImportedId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    EventTypeId = table.Column<Guid>(nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonImported", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonImported_EventType_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonImported_FileImported_FileImportedId",
                        column: x => x.FileImportedId,
                        principalTable: "FileImported",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonImported_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonImported_EventTypeId",
                table: "LessonImported",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonImported_FileImportedId",
                table: "LessonImported",
                column: "FileImportedId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonImported_StudentId",
                table: "LessonImported",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonImported");

            migrationBuilder.DropTable(
                name: "FileImported");
        }
    }
}
