using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonsManagement.Data.Migrations
{
    public partial class fixdatefileimported : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "FileImported",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "FileImported",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "FileImported",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "FileImported",
                newName: "DateEnd");
        }
    }
}
