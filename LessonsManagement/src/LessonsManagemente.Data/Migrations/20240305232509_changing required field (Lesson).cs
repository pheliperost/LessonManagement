using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LessonsManagement.Data.Migrations
{
    public partial class changingrequiredfieldLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Lesson",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Lesson",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
