using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LessonsManagement.Data.Migrations
{
    public partial class CreatingEventTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Lesson");

            migrationBuilder.AddColumn<Guid>(
                name: "EventTypeId",
                table: "Lesson",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventTypeName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Notes = table.Column<string>(type: "varchar(500)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_EventTypeId",
                table: "Lesson",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_EventType_EventTypeId",
                table: "Lesson",
                column: "EventTypeId",
                principalTable: "EventType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_EventType_EventTypeId",
                table: "Lesson");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_EventTypeId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "Lesson");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Lesson",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
