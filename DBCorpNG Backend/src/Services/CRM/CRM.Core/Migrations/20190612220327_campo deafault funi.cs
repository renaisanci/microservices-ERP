using Microsoft.EntityFrameworkCore.Migrations;

namespace DBCorp.CRM.Core.Migrations
{
    public partial class campodeafaultfuni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RepresentanteId",
                schema: "CRM",
                table: "Negocio",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PessoaIdOrganizacao",
                schema: "CRM",
                table: "Negocio",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PessoaIdContato",
                schema: "CRM",
                table: "Negocio",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Default",
                schema: "CRM",
                table: "Funil",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Default",
                schema: "CRM",
                table: "Funil");

            migrationBuilder.AlterColumn<int>(
                name: "RepresentanteId",
                schema: "CRM",
                table: "Negocio",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PessoaIdOrganizacao",
                schema: "CRM",
                table: "Negocio",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PessoaIdContato",
                schema: "CRM",
                table: "Negocio",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
