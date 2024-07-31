using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ec_Supermercado.Api.Migrations
{
    /// <inheritdoc />
    public partial class RelacaoVendasCo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    VendaTotal = table.Column<double>(type: "float", nullable: false),
                    Pagamento = table.Column<int>(type: "int", nullable: false),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_Vendas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaProdutos",
                columns: table => new
                {
                    VendaProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeRetirada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaProdutos", x => x.VendaProdutoId);
                    table.ForeignKey(
                        name: "FK_VendaProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaProdutos_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutos_ProdutoId",
                table: "VendaProdutos",
                column: "ProdutoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutos_VendaId",
                table: "VendaProdutos",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaProdutos");

            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
