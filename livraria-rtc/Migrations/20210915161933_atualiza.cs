using Microsoft.EntityFrameworkCore.Migrations;

namespace livraria_rtc.Migrations
{
    public partial class atualiza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Livros",
                newName: "Titulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Livros",
                newName: "Nome");
        }
    }
}
