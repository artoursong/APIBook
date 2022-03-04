using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookAPI.Migrations
{
    public partial class AddCommetCreate_Date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Create_Date",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Create_Date",
                table: "Comments");
        }
    }
}
