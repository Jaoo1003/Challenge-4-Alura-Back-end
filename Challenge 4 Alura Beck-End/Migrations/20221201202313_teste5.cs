using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_4_Alura_Beck_End.Migrations
{
    public partial class teste5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriaTipo",
                table: "Categorias",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categorias",
                newName: "CategoriaTipo");
        }
    }
}
