using Microsoft.EntityFrameworkCore.Migrations;

namespace bookAPI.Migrations
{
    public partial class AddBookID_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_ID_User",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ID_User",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_ID_User",
                table: "Books",
                column: "ID_User",
                principalTable: "Users",
                principalColumn: "ID_User",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_ID_User",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ID_User",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_ID_User",
                table: "Books",
                column: "ID_User",
                principalTable: "Users",
                principalColumn: "ID_User",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
