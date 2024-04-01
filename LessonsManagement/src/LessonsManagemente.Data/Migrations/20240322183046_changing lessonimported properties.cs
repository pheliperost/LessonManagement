using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonsManagement.Data.Migrations
{
    public partial class changinglessonimportedproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "LessonImported");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "LessonImported",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "LessonImported");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "LessonImported",
                type: "varchar(100)",
                nullable: true);
        }
    }
}
