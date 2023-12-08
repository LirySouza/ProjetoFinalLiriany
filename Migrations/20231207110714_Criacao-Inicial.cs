using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalLiriany.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoColaborador",
                columns: table => new
                {
                    TipoColaboradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoColaboradorNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoColaborador", x => x.TipoColaboradorId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProcedimento",
                columns: table => new
                {
                    TipoProcedimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProcedimentoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProcedimento", x => x.TipoProcedimentoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.CidadeId);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    ProcedimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedimentoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcedimentoObservacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoProcedimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => x.ProcedimentoId);
                    table.ForeignKey(
                        name: "FK_Procedimento_TipoProcedimento_TipoProcedimentoId",
                        column: x => x.TipoProcedimentoId,
                        principalTable: "TipoProcedimento",
                        principalColumn: "TipoProcedimentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteCpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteSexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteNumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColaboradorCpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColaboradorSexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColaboradorTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    TipoColaboradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.ColaboradorId);
                    table.ForeignKey(
                        name: "FK_Colaborador_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_TipoColaborador_TipoColaboradorId",
                        column: x => x.TipoColaboradorId,
                        principalTable: "TipoColaborador",
                        principalColumn: "TipoColaboradorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalRealizacao",
                columns: table => new
                {
                    LocalRealizacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalRealizacaoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalRealizacao", x => x.LocalRealizacaoId);
                    table.ForeignKey(
                        name: "FK_LocalRealizacao_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcedimentoRealizacao",
                columns: table => new
                {
                    ProcedimentoRealizaçãoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    ProcedimentoId = table.Column<int>(type: "int", nullable: true),
                    ColaboradorId = table.Column<int>(type: "int", nullable: true),
                    LocalRealizacaoId = table.Column<int>(type: "int", nullable: true),
                    DataRealizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObservacaoRealizacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedimentoRealizacao", x => x.ProcedimentoRealizaçãoId);
                    table.ForeignKey(
                        name: "FK_ProcedimentoRealizacao_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_ProcedimentoRealizacao_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId");
                    table.ForeignKey(
                        name: "FK_ProcedimentoRealizacao_LocalRealizacao_LocalRealizacaoId",
                        column: x => x.LocalRealizacaoId,
                        principalTable: "LocalRealizacao",
                        principalColumn: "LocalRealizacaoId");
                    table.ForeignKey(
                        name: "FK_ProcedimentoRealizacao_Procedimento_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimento",
                        principalColumn: "ProcedimentoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CidadeId",
                table: "Cliente",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_CidadeId",
                table: "Colaborador",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_TipoColaboradorId",
                table: "Colaborador",
                column: "TipoColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalRealizacao_CidadeId",
                table: "LocalRealizacao",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_TipoProcedimentoId",
                table: "Procedimento",
                column: "TipoProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentoRealizacao_ClienteId",
                table: "ProcedimentoRealizacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentoRealizacao_ColaboradorId",
                table: "ProcedimentoRealizacao",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentoRealizacao_LocalRealizacaoId",
                table: "ProcedimentoRealizacao",
                column: "LocalRealizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentoRealizacao_ProcedimentoId",
                table: "ProcedimentoRealizacao",
                column: "ProcedimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcedimentoRealizacao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "LocalRealizacao");

            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "TipoColaborador");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "TipoProcedimento");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
