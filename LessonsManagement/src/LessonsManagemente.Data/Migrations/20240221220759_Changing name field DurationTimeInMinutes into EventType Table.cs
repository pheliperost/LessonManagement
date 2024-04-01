using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonsManagement.Data.Migrations
{
    public partial class ChangingnamefieldDurationTimeInMinutesintoEventTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationInMinutes",
                table: "EventType",
                newName: "DurationTimeInMinutes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationTimeInMinutes",
                table: "EventType",
                newName: "DurationInMinutes");
        }
    }
}
