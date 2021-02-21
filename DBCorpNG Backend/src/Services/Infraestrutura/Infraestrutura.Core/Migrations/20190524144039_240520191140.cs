using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBCorp.Infraestrutura.Core.Migrations
{
    public partial class _240520191140 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Infraestrutura");

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "Infraestrutura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioCriacaoId = table.Column<int>(nullable: true),
                    DataHoraCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UsuarioAlteracaoId = table.Column<int>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false),
                    TipoPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioCriacaoId = table.Column<int>(nullable: true),
                    DataHoraCriacao = table.Column<DateTime>(nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false),
                    PrimeiroNome = table.Column<string>(nullable: true),
                    UltimoNome = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "Infraestrutura",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                schema: "Infraestrutura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioCriacaoId = table.Column<int>(nullable: true),
                    DataHoraCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UsuarioAlteracaoId = table.Column<int>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false),
                    PessoaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "Infraestrutura",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                schema: "Infraestrutura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioCriacaoId = table.Column<int>(nullable: true),
                    DataHoraCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UsuarioAlteracaoId = table.Column<int>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false),
                    PessoaId = table.Column<int>(nullable: false),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    InscEstadual = table.Column<string>(nullable: true),
                    DtFundacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "Infraestrutura",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaId",
                table: "Usuario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioAlteracaoId",
                table: "Usuario",
                column: "UsuarioAlteracaoId",
                unique: true,
                filter: "[UsuarioAlteracaoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "Pessoa",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "Pessoa",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_PessoaId",
                schema: "Infraestrutura",
                table: "PessoaFisica",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "PessoaFisica",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "PessoaFisica",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_PessoaId",
                schema: "Infraestrutura",
                table: "PessoaJuridica",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "PessoaJuridica",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "PessoaJuridica",
                column: "UsuarioCriacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "Pessoa",
                column: "UsuarioAlteracaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "Pessoa",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pessoa_PessoaId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "PessoaFisica",
                schema: "Infraestrutura");

            migrationBuilder.DropTable(
                name: "PessoaJuridica",
                schema: "Infraestrutura");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "Infraestrutura");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
