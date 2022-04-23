using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentToParty.Migrations
{
    public partial class TherttMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disponibilidade",
                columns: table => new
                {
                    IdDisponibilidade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdImovel = table.Column<int>(type: "INTEGER", nullable: false),
                    DiaDaSemana = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraFinal = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidade", x => x.IdDisponibilidade);
                    table.ForeignKey(
                        name: "FK_Disponibilidade_Imovel_IdImovel",
                        column: x => x.IdImovel,
                        principalTable: "Imovel",
                        principalColumn: "IdIMovel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    IdLocacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdImovel = table.Column<int>(type: "INTEGER", nullable: false),
                    IdLocatario = table.Column<int>(type: "INTEGER", nullable: false),
                    LocatarioIdPessoa = table.Column<int>(type: "INTEGER", nullable: true),
                    DtainicioLocacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DtaFimLocacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.IdLocacao);
                    table.ForeignKey(
                        name: "FK_Locacao_Imovel_IdImovel",
                        column: x => x.IdImovel,
                        principalTable: "Imovel",
                        principalColumn: "IdIMovel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locacao_Pessoa_LocatarioIdPessoa",
                        column: x => x.LocatarioIdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidade_IdImovel",
                table: "Disponibilidade",
                column: "IdImovel");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_IdImovel",
                table: "Locacao",
                column: "IdImovel");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_LocatarioIdPessoa",
                table: "Locacao",
                column: "LocatarioIdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponibilidade");

            migrationBuilder.DropTable(
                name: "Locacao");
        }
    }
}
