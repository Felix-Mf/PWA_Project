using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PWA_Project.Server.Data.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoPath",
                table: "Question");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Course",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "VideoPath",
                table: "Question",
                type: "TEXT",
                nullable: true);
        }
    }
}
