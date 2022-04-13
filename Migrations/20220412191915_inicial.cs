using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTeste.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(nullable: true),
                    SOBRENOME = table.Column<string>(nullable: true),
                    DDD = table.Column<string>(nullable: true),
                    TELEFONE = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    DT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_INCLUSAO = table.Column<long>(nullable: false),
                    DT_INCLUSAO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_ALTERACAO = table.Column<long>(nullable: false),
                    DT_ALTERACAO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(nullable: true),
                    SOBRENOME = table.Column<string>(nullable: true),
                    LOGIN = table.Column<string>(nullable: true),
                    DT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    DT_INCLUSAO = table.Column<DateTime>(nullable: false),
                    DT_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID_USUARIO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
