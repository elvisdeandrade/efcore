using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EAS.Financeiro.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Ativa = table.Column<bool>(nullable: false),
                    CNPJ = table.Column<string>(type: "char(14)", nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Sigla = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 60, nullable: true),
                    EmpresaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    CEP = table.Column<string>(type: "char(8)", nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    EmpresaId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(maxLength: 50, nullable: true),
                    Rua = table.Column<string>(maxLength: 150, nullable: false),
                    Tipo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContatoId = table.Column<int>(nullable: false),
                    DDD = table.Column<string>(type: "char(2)", nullable: true),
                    DDI = table.Column<string>(type: "char(2)", nullable: true),
                    Numero = table.Column<string>(type: "char(9)", nullable: true),
                    Observacao = table.Column<string>(maxLength: 150, nullable: true),
                    Operadora = table.Column<string>(maxLength: 30, nullable: true),
                    Ramal = table.Column<string>(maxLength: 10, nullable: true),
                    Tipo = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_EmpresaId",
                table: "Contatos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ApplicationUserId",
                table: "Empresas",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EmpresaId",
                table: "Enderecos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EstadoId",
                table: "Enderecos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_ContatoId",
                table: "Telefones",
                column: "ContatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
