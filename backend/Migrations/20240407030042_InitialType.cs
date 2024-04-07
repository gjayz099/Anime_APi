using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace anime_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "typeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anime_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_typeds_Animes_Anime_id",
                        column: x => x.Anime_id,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_typeds_Anime_id",
                table: "typeds",
                column: "Anime_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "typeds");
        }
    }
}
