using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZPP_aplikacja_internetowa.Migrations
{
    public partial class maps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "MapId", "Name" },
                values: new object[] { 1, "Dust2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapId",
                keyValue: 1);
        }
    }
}
