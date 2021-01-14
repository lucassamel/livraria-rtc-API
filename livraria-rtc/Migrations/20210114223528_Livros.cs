using Microsoft.EntityFrameworkCore.Migrations;

namespace livraria_rtc.Migrations
{
    public partial class Livros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_UsuarioId",
                table: "Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_UsuarioId",
                table: "Endereco",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_UsuarioId",
                table: "Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_UsuarioId",
                table: "Endereco",
                column: "UsuarioId",
                unique: true);
        }
    }
}
