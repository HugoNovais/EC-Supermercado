using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ec_Supermercado.Api.Migrations
{
    /// <inheritdoc />
    public partial class RelacaoVendasCorrigida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_VendaProdutos_ProdutoId",
                table: "VendaProdutos");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutos_ProdutoId",
                table: "VendaProdutos",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_VendaProdutos_ProdutoId",
                table: "VendaProdutos");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutos_ProdutoId",
                table: "VendaProdutos",
                column: "ProdutoId",
                unique: true);
        }
    }
}
