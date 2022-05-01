using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentToParty.Migrations
{
    public partial class _4migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caracteristica",
                columns: table => new
                {
                    IdCaracteristica = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristica", x => x.IdCaracteristica);
                });

            migrationBuilder.CreateTable(
                name: "Excessao_Dispo",
                columns: table => new
                {
                    IdExcessao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdImovel = table.Column<int>(type: "INTEGER", nullable: false),
                    DataExcessao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Situacao = table.Column<string>(type: "TEXT", nullable: true),
                    Obsservacao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excessao_Dispo", x => x.IdExcessao);
                });

            migrationBuilder.CreateTable(
                name: "Preco",
                columns: table => new
                {
                    IdPreco = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdImovel = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Dtainicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DtaFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    DiaDaSemana = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preco", x => x.IdPreco);
                    table.ForeignKey(
                        name: "FK_Preco_Imovel_IdImovel",
                        column: x => x.IdImovel,
                        principalTable: "Imovel",
                        principalColumn: "IdIMovel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carac_Imovel",
                columns: table => new
                {
                    IdCaracImovel = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCaracteristica = table.Column<int>(type: "INTEGER", nullable: false),
                    IdImovel = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carac_Imovel", x => x.IdCaracImovel);
                    table.ForeignKey(
                        name: "FK_Carac_Imovel_Caracteristica_IdCaracteristica",
                        column: x => x.IdCaracteristica,
                        principalTable: "Caracteristica",
                        principalColumn: "IdCaracteristica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carac_Imovel_Imovel_IdImovel",
                        column: x => x.IdImovel,
                        principalTable: "Imovel",
                        principalColumn: "IdIMovel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carac_Imovel_IdCaracteristica",
                table: "Carac_Imovel",
                column: "IdCaracteristica");

            migrationBuilder.CreateIndex(
                name: "IX_Carac_Imovel_IdImovel",
                table: "Carac_Imovel",
                column: "IdImovel");

            migrationBuilder.CreateIndex(
                name: "IX_Preco_IdImovel",
                table: "Preco",
                column: "IdImovel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carac_Imovel");

            migrationBuilder.DropTable(
                name: "Excessao_Dispo");

            migrationBuilder.DropTable(
                name: "Preco");

            migrationBuilder.DropTable(
                name: "Caracteristica");
        }
    }
}
