using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBCorp.ControleAcesso.Core.Migrations
{
    public partial class cacorrecoes0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ControleAcesso");

            migrationBuilder.EnsureSchema(
                name: "Infraestrutura");

            migrationBuilder.CreateTable(
                name: "MenuControle",
                schema: "ControleAcesso",
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
                    MenuId = table.Column<int>(nullable: false),
                    ElementName = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuControle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermisaoPerfil",
                schema: "ControleAcesso",
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
                    PerfilId = table.Column<int>(nullable: false),
                    MenuControleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisaoPerfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermisaoPerfil_MenuControle_MenuControleId",
                        column: x => x.MenuControleId,
                        principalSchema: "ControleAcesso",
                        principalTable: "MenuControle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "ControleAcesso",
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
                    MenuPaiId = table.Column<int>(nullable: true),
                    ModuloId = table.Column<int>(nullable: false),
                    DescMenu = table.Column<string>(type: "varchar(100)", nullable: true),
                    Nivel = table.Column<int>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Badge = table.Column<string>(nullable: true),
                    BadgeValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_MenuPaiId",
                        column: x => x.MenuPaiId,
                        principalSchema: "ControleAcesso",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuario",
                schema: "ControleAcesso",
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
                    UsuarioId = table.Column<int>(nullable: false),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                schema: "ControleAcesso",
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
                    NomeModulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                schema: "ControleAcesso",
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
                    PaiId = table.Column<int>(nullable: true),
                    DescPerfil = table.Column<string>(maxLength: 50, nullable: false),
                    PerfilId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfil_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "ControleAcesso",
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "Infraestrutura",
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
                    TipoPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "ControleAcesso",
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
                    PrimeiroNome = table.Column<string>(nullable: true),
                    UltimoNome = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalSchema: "ControleAcesso",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalSchema: "ControleAcesso",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuPaiId",
                schema: "ControleAcesso",
                table: "Menu",
                column: "MenuPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ModuloId",
                schema: "ControleAcesso",
                table: "Menu",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "Menu",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "Menu",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuControle_MenuId",
                schema: "ControleAcesso",
                table: "MenuControle",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuControle_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "MenuControle",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuControle_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "MenuControle",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Modulo_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "Modulo",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Modulo_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "Modulo",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_PerfilId",
                schema: "ControleAcesso",
                table: "Perfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "Perfil",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "Perfil",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuario_PerfilId",
                schema: "ControleAcesso",
                table: "PerfilUsuario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuario_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "PerfilUsuario",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuario_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "PerfilUsuario",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuario_UsuarioId",
                schema: "ControleAcesso",
                table: "PerfilUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisaoPerfil_MenuControleId",
                schema: "ControleAcesso",
                table: "PermisaoPerfil",
                column: "MenuControleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisaoPerfil_PerfilId",
                schema: "ControleAcesso",
                table: "PermisaoPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisaoPerfil_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "PermisaoPerfil",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisaoPerfil_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "PermisaoPerfil",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaId",
                schema: "ControleAcesso",
                table: "Usuario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "Usuario",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "Usuario",
                column: "UsuarioCriacaoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MenuControle_Usuario_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "MenuControle",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuControle_Usuario_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "MenuControle",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuControle_Menu_MenuId",
                schema: "ControleAcesso",
                table: "MenuControle",
                column: "MenuId",
                principalSchema: "ControleAcesso",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisaoPerfil_Usuario_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "PermisaoPerfil",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisaoPerfil_Usuario_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "PermisaoPerfil",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisaoPerfil_Perfil_PerfilId",
                schema: "ControleAcesso",
                table: "PermisaoPerfil",
                column: "PerfilId",
                principalSchema: "ControleAcesso",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Modulo_ModuloId",
                schema: "ControleAcesso",
                table: "Menu",
                column: "ModuloId",
                principalSchema: "ControleAcesso",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Usuario_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "Menu",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Usuario_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "Menu",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuario_Usuario_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "PerfilUsuario",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuario_Usuario_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "PerfilUsuario",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuario_Usuario_UsuarioId",
                schema: "ControleAcesso",
                table: "PerfilUsuario",
                column: "UsuarioId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuario_Perfil_PerfilId",
                schema: "ControleAcesso",
                table: "PerfilUsuario",
                column: "PerfilId",
                principalSchema: "ControleAcesso",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modulo_Usuario_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "Modulo",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modulo_Usuario_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "Modulo",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_Usuario_UsuarioAlteracaoId",
                schema: "ControleAcesso",
                table: "Perfil",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_Usuario_UsuarioCriacaoId",
                schema: "ControleAcesso",
                table: "Perfil",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "Pessoa",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "Pessoa",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Usuario_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Usuario_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "PerfilUsuario",
                schema: "ControleAcesso");

            migrationBuilder.DropTable(
                name: "PermisaoPerfil",
                schema: "ControleAcesso");

            migrationBuilder.DropTable(
                name: "MenuControle",
                schema: "ControleAcesso");

            migrationBuilder.DropTable(
                name: "Perfil",
                schema: "ControleAcesso");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "ControleAcesso");

            migrationBuilder.DropTable(
                name: "Modulo",
                schema: "ControleAcesso");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "ControleAcesso");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "Infraestrutura");
        }
    }
}
