using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookAPI.Migrations
{
    public partial class WebBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID_Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID_Category);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<bool>(type: "bit", nullable: false),
                    Ban = table.Column<bool>(type: "bit", nullable: false),
                    Coin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID_User);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID_Book = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate_average = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten_khac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hoa_si = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    View_sum = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tinh_trang = table.Column<bool>(type: "bit", nullable: false),
                    Follow_sum = table.Column<int>(type: "int", nullable: false),
                    Update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID_Book);
                    table.ForeignKey(
                        name: "FK_Books_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChitietCategories",
                columns: table => new
                {
                    ID_Chitiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Book = table.Column<int>(type: "int", nullable: false),
                    ID_Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitietCategories", x => x.ID_Chitiet);
                    table.ForeignKey(
                        name: "FK_ChitietCategories_Books_ID_Book",
                        column: x => x.ID_Book,
                        principalTable: "Books",
                        principalColumn: "ID_Book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitietCategories_Categories_ID_Category",
                        column: x => x.ID_Category,
                        principalTable: "Categories",
                        principalColumn: "ID_Category",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID_Comment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Book = table.Column<int>(type: "int", nullable: false),
                    ID_User = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID_Comment);
                    table.ForeignKey(
                        name: "FK_Comments_Books_ID_Book",
                        column: x => x.ID_Book,
                        principalTable: "Books",
                        principalColumn: "ID_Book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    ID_Follow = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_User = table.Column<int>(type: "int", nullable: true),
                    ID_Book = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.ID_Follow);
                    table.ForeignKey(
                        name: "FK_Follows_Books_ID_Book",
                        column: x => x.ID_Book,
                        principalTable: "Books",
                        principalColumn: "ID_Book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follows_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ID_Rating = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ID_User = table.Column<int>(type: "int", nullable: true),
                    ID_Book = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ID_Rating);
                    table.ForeignKey(
                        name: "FK_Ratings_Books_ID_Book",
                        column: x => x.ID_Book,
                        principalTable: "Books",
                        principalColumn: "ID_Book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    ID_Volume = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Book = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.ID_Volume);
                    table.ForeignKey(
                        name: "FK_Volumes_Books_ID_Book",
                        column: x => x.ID_Book,
                        principalTable: "Books",
                        principalColumn: "ID_Book",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IsBans",
                columns: table => new
                {
                    ID_IsBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_User = table.Column<int>(type: "int", nullable: true),
                    ID_Comment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsBans", x => x.ID_IsBan);
                    table.ForeignKey(
                        name: "FK_IsBans_Comments_ID_Comment",
                        column: x => x.ID_Comment,
                        principalTable: "Comments",
                        principalColumn: "ID_Comment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsBans_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    ID_Chapter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    View = table.Column<int>(type: "int", nullable: false),
                    ID_Volume = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.ID_Chapter);
                    table.ForeignKey(
                        name: "FK_Chapters_Volumes_ID_Volume",
                        column: x => x.ID_Volume,
                        principalTable: "Volumes",
                        principalColumn: "ID_Volume",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookmakrs",
                columns: table => new
                {
                    ID_Bookmark = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ID_Chapter = table.Column<int>(type: "int", nullable: false),
                    ID_User = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmakrs", x => x.ID_Bookmark);
                    table.ForeignKey(
                        name: "FK_Bookmakrs_Chapters_ID_Chapter",
                        column: x => x.ID_Chapter,
                        principalTable: "Chapters",
                        principalColumn: "ID_Chapter",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookmakrs_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookmakrs_ID_Chapter",
                table: "Bookmakrs",
                column: "ID_Chapter");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmakrs_ID_User",
                table: "Bookmakrs",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ID_User",
                table: "Books",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_ID_Volume",
                table: "Chapters",
                column: "ID_Volume");

            migrationBuilder.CreateIndex(
                name: "IX_ChitietCategories_ID_Book",
                table: "ChitietCategories",
                column: "ID_Book");

            migrationBuilder.CreateIndex(
                name: "IX_ChitietCategories_ID_Category",
                table: "ChitietCategories",
                column: "ID_Category");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ID_Book",
                table: "Comments",
                column: "ID_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ID_User",
                table: "Comments",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_ID_Book",
                table: "Follows",
                column: "ID_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_ID_User",
                table: "Follows",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_IsBans_ID_Comment",
                table: "IsBans",
                column: "ID_Comment");

            migrationBuilder.CreateIndex(
                name: "IX_IsBans_ID_User",
                table: "IsBans",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ID_Book",
                table: "Ratings",
                column: "ID_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ID_User",
                table: "Ratings",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_ID_Book",
                table: "Volumes",
                column: "ID_Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmakrs");

            migrationBuilder.DropTable(
                name: "ChitietCategories");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "IsBans");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Volumes");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
