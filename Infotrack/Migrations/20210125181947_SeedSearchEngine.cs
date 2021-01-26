using Microsoft.EntityFrameworkCore.Migrations;

namespace Infotrack.Migrations
{
    public partial class SeedSearchEngine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scrapes_SearchTerm_SearchTermId",
                table: "Scrapes");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchTerm_SearchEngines_SearchEngineId",
                table: "SearchTerm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchTerm",
                table: "SearchTerm");

            migrationBuilder.RenameTable(
                name: "SearchTerm",
                newName: "SearchTerms");

            migrationBuilder.RenameIndex(
                name: "IX_SearchTerm_SearchEngineId",
                table: "SearchTerms",
                newName: "IX_SearchTerms_SearchEngineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchTerms",
                table: "SearchTerms",
                column: "Id");

            migrationBuilder.InsertData(
                table: "SearchEngines",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Google" });

            migrationBuilder.AddForeignKey(
                name: "FK_Scrapes_SearchTerms_SearchTermId",
                table: "Scrapes",
                column: "SearchTermId",
                principalTable: "SearchTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchTerms_SearchEngines_SearchEngineId",
                table: "SearchTerms",
                column: "SearchEngineId",
                principalTable: "SearchEngines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scrapes_SearchTerms_SearchTermId",
                table: "Scrapes");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchTerms_SearchEngines_SearchEngineId",
                table: "SearchTerms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchTerms",
                table: "SearchTerms");

            migrationBuilder.DeleteData(
                table: "SearchEngines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "SearchTerms",
                newName: "SearchTerm");

            migrationBuilder.RenameIndex(
                name: "IX_SearchTerms_SearchEngineId",
                table: "SearchTerm",
                newName: "IX_SearchTerm_SearchEngineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchTerm",
                table: "SearchTerm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scrapes_SearchTerm_SearchTermId",
                table: "Scrapes",
                column: "SearchTermId",
                principalTable: "SearchTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchTerm_SearchEngines_SearchEngineId",
                table: "SearchTerm",
                column: "SearchEngineId",
                principalTable: "SearchEngines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
