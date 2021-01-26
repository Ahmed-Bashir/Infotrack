using Microsoft.EntityFrameworkCore.Migrations;

namespace Infotrack.Migrations
{
    public partial class ChangeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scrapes_SearchEngines_SearchEngineId",
                table: "Scrapes");

            migrationBuilder.DropTable(
                name: "Hits");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "SearchEngines");

            migrationBuilder.RenameColumn(
                name: "SearchEngineId",
                table: "Scrapes",
                newName: "SearchTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Scrapes_SearchEngineId",
                table: "Scrapes",
                newName: "IX_Scrapes_SearchTermId");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Scrapes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SearchTerm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchEngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchTerm_SearchEngines_SearchEngineId",
                        column: x => x.SearchEngineId,
                        principalTable: "SearchEngines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchTerm_SearchEngineId",
                table: "SearchTerm",
                column: "SearchEngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scrapes_SearchTerm_SearchTermId",
                table: "Scrapes",
                column: "SearchTermId",
                principalTable: "SearchTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scrapes_SearchTerm_SearchTermId",
                table: "Scrapes");

            migrationBuilder.DropTable(
                name: "SearchTerm");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Scrapes");

            migrationBuilder.RenameColumn(
                name: "SearchTermId",
                table: "Scrapes",
                newName: "SearchEngineId");

            migrationBuilder.RenameIndex(
                name: "IX_Scrapes_SearchTermId",
                table: "Scrapes",
                newName: "IX_Scrapes_SearchEngineId");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "SearchEngines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScrapeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hits_Scrapes_ScrapeId",
                        column: x => x.ScrapeId,
                        principalTable: "Scrapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hits_ScrapeId",
                table: "Hits",
                column: "ScrapeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scrapes_SearchEngines_SearchEngineId",
                table: "Scrapes",
                column: "SearchEngineId",
                principalTable: "SearchEngines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
