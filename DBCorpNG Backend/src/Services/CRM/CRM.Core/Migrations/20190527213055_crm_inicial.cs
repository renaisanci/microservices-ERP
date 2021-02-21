using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBCorp.CRM.Core.Migrations
{
    public partial class crm_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CRM");

            migrationBuilder.EnsureSchema(
                name: "Infraestrutura");

            migrationBuilder.EnsureSchema(
                name: "ControleAcesso");

            migrationBuilder.CreateTable(
                name: "Funil",
                schema: "CRM",
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
                    Titulo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FunilEmpresa",
                schema: "CRM",
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
                    FunilId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunilEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunilEmpresa_Funil_FunilId",
                        column: x => x.FunilId,
                        principalSchema: "CRM",
                        principalTable: "Funil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FunilEtapa",
                schema: "CRM",
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
                    FunilId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Ordem = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunilEtapa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunilEtapa_Funil_FunilId",
                        column: x => x.FunilId,
                        principalSchema: "CRM",
                        principalTable: "Funil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Negocio",
                schema: "CRM",
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
                    FunilEtapaId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    OrganizacaoId = table.Column<int>(nullable: true),
                    PessoaIdOrganizacao = table.Column<int>(nullable: false),
                    ContatoId = table.Column<int>(nullable: true),
                    PessoaIdContato = table.Column<int>(nullable: false),
                    RepresentanteId = table.Column<int>(nullable: false),
                    DataFechamentoEsperada = table.Column<DateTime>(nullable: true),
                    ValorPrevisto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negocio_FunilEtapa_FunilEtapaId",
                        column: x => x.FunilEtapaId,
                        principalSchema: "CRM",
                        principalTable: "FunilEtapa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
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
                    Excluido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

      

         

            migrationBuilder.CreateTable(
                name: "Representante",
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
                    Excluido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representante_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalSchema: "ControleAcesso",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Representante_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalSchema: "ControleAcesso",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

        

        

            migrationBuilder.CreateIndex(
                name: "IX_Funil_UsuarioAlteracaoId",
                schema: "CRM",
                table: "Funil",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funil_UsuarioCriacaoId",
                schema: "CRM",
                table: "Funil",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FunilEmpresa_EmpresaId",
                schema: "CRM",
                table: "FunilEmpresa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_FunilEmpresa_FunilId",
                schema: "CRM",
                table: "FunilEmpresa",
                column: "FunilId");

            migrationBuilder.CreateIndex(
                name: "IX_FunilEmpresa_UsuarioAlteracaoId",
                schema: "CRM",
                table: "FunilEmpresa",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FunilEmpresa_UsuarioCriacaoId",
                schema: "CRM",
                table: "FunilEmpresa",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FunilEtapa_FunilId",
                schema: "CRM",
                table: "FunilEtapa",
                column: "FunilId");

            migrationBuilder.CreateIndex(
                name: "IX_FunilEtapa_UsuarioAlteracaoId",
                schema: "CRM",
                table: "FunilEtapa",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FunilEtapa_UsuarioCriacaoId",
                schema: "CRM",
                table: "FunilEtapa",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_ContatoId",
                schema: "CRM",
                table: "Negocio",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_FunilEtapaId",
                schema: "CRM",
                table: "Negocio",
                column: "FunilEtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_OrganizacaoId",
                schema: "CRM",
                table: "Negocio",
                column: "OrganizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_RepresentanteId",
                schema: "CRM",
                table: "Negocio",
                column: "RepresentanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_UsuarioAlteracaoId",
                schema: "CRM",
                table: "Negocio",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_UsuarioCriacaoId",
                schema: "CRM",
                table: "Negocio",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "Empresa",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "Empresa",
                column: "UsuarioCriacaoId");

         

    

            migrationBuilder.CreateIndex(
                name: "IX_Representante_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "Representante",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Representante_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "Representante",
                column: "UsuarioCriacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funil_Usuario_UsuarioAlteracaoId",
                schema: "CRM",
                table: "Funil",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funil_Usuario_UsuarioCriacaoId",
                schema: "CRM",
                table: "Funil",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FunilEmpresa_Usuario_UsuarioAlteracaoId",
                schema: "CRM",
                table: "FunilEmpresa",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FunilEmpresa_Usuario_UsuarioCriacaoId",
                schema: "CRM",
                table: "FunilEmpresa",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FunilEmpresa_Empresa_EmpresaId",
                schema: "CRM",
                table: "FunilEmpresa",
                column: "EmpresaId",
                principalSchema: "Infraestrutura",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FunilEtapa_Usuario_UsuarioAlteracaoId",
                schema: "CRM",
                table: "FunilEtapa",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FunilEtapa_Usuario_UsuarioCriacaoId",
                schema: "CRM",
                table: "FunilEtapa",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_Pessoa_ContatoId",
                schema: "CRM",
                table: "Negocio",
                column: "ContatoId",
                principalSchema: "Infraestrutura",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_Pessoa_OrganizacaoId",
                schema: "CRM",
                table: "Negocio",
                column: "OrganizacaoId",
                principalSchema: "Infraestrutura",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_Usuario_UsuarioAlteracaoId",
                schema: "CRM",
                table: "Negocio",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_Usuario_UsuarioCriacaoId",
                schema: "CRM",
                table: "Negocio",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_Representante_RepresentanteId",
                schema: "CRM",
                table: "Negocio",
                column: "RepresentanteId",
                principalSchema: "Infraestrutura",
                principalTable: "Representante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Usuario_UsuarioAlteracaoId",
                schema: "Infraestrutura",
                table: "Empresa",
                column: "UsuarioAlteracaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Usuario_UsuarioCriacaoId",
                schema: "Infraestrutura",
                table: "Empresa",
                column: "UsuarioCriacaoId",
                principalSchema: "ControleAcesso",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
 

       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pessoa_PessoaId",
                schema: "ControleAcesso",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "FunilEmpresa",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "Negocio",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "Infraestrutura");

            migrationBuilder.DropTable(
                name: "FunilEtapa",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "Representante",
                schema: "Infraestrutura");

            migrationBuilder.DropTable(
                name: "Funil",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "Infraestrutura");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "ControleAcesso");
        }
    }
}
