using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZPP_aplikacja_internetowa.Migrations
{
    public partial class GameStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameStatus_GameStatusId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameStatus",
                table: "GameStatus");

            migrationBuilder.RenameTable(
                name: "GameStatus",
                newName: "GameStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameStatuses",
                table: "GameStatuses",
                column: "GameStatusId");

            migrationBuilder.InsertData(
                table: "GameStatuses",
                columns: new[] { "GameStatusId", "StatusName" },
                values: new object[] { 1, "Started" });

            migrationBuilder.InsertData(
                table: "GameStatuses",
                columns: new[] { "GameStatusId", "StatusName" },
                values: new object[] { 2, "Ended" });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameStatuses_GameStatusId",
                table: "Games",
                column: "GameStatusId",
                principalTable: "GameStatuses",
                principalColumn: "GameStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameStatuses_GameStatusId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameStatuses",
                table: "GameStatuses");

            migrationBuilder.DeleteData(
                table: "GameStatuses",
                keyColumn: "GameStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameStatuses",
                keyColumn: "GameStatusId",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "GameStatuses",
                newName: "GameStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameStatus",
                table: "GameStatus",
                column: "GameStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameStatus_GameStatusId",
                table: "Games",
                column: "GameStatusId",
                principalTable: "GameStatus",
                principalColumn: "GameStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
