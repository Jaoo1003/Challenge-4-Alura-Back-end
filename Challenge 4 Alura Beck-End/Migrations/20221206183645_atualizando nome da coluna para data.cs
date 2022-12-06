using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_4_Alura_Beck_End.Migrations
{
    public partial class atualizandonomedacolunaparadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Despesas",
                newName: "Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Despesas",
                newName: "Date");
        }
    }
}
