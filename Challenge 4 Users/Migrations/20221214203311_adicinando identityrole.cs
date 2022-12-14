using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_4_Users.Migrations
{
    public partial class adicinandoidentityrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "77f24401-30dc-427d-90b4-64edf848e98b", "authorized", "AUTHORIZED" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
