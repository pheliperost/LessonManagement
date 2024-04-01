using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonsManagement.Data.Migrations
{
    public partial class AddNotesFieldIntoLessonsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Lesson",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Lesson");
        }
    }
}
