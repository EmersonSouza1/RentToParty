using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentToParty.Migrations
{
    public partial class initialMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cep = table.Column<int>(type: "INTEGER", nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CPF_CNPJ = table.Column<string>(type: "TEXT", nullable: true),
                    DtaNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<long>(type: "INTEGER", nullable: false),
                    IdEndereco = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_Pessoa_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imovel",
                columns: table => new
                {
                    IdIMovel = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    IdProprietario = table.Column<int>(type: "INTEGER", nullable: false),
                    ProprietarioIdPessoa = table.Column<int>(type: "INTEGER", nullable: true),
                    IdEndereco = table.Column<int>(type: "INTEGER", nullable: false),
                    enderecoIdEndereco = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imovel", x => x.IdIMovel);
                    table.ForeignKey(
                        name: "FK_Imovel_Endereco_enderecoIdEndereco",
                        column: x => x.enderecoIdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imovel_Pessoa_ProprietarioIdPessoa",
                        column: x => x.ProprietarioIdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_enderecoIdEndereco",
                table: "Imovel",
                column: "enderecoIdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_ProprietarioIdPessoa",
                table: "Imovel",
                column: "ProprietarioIdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_IdEndereco",
                table: "Pessoa",
                column: "IdEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imovel");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
