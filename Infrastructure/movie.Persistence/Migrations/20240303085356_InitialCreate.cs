using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace movie.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    FavoritedUsersId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.FavoritedUsersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieUser_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_Users_FavoritedUsersId",
                        column: x => x.FavoritedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[] { 1, new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(3262), "Drama is a category of narrative fiction intended to be more serious than humorous in tone.", false, "Drama" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "IsDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(7081), false },
                    { 2, new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(7180), false },
                    { 3, new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(7181), false }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedDate", "Description", "GenreId", "IsDeleted", "Title", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(4761), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 1, false, "The Godfather", 1972 },
                    { 2, new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(4768), "Two imprisoned,", 1, false, "The Shawshank Redemption", 1994 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_MoviesId",
                table: "MovieUser",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
