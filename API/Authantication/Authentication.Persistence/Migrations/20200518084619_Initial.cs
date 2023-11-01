using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Removed = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    NomeCompleto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Sexo = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Funcionario", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TB_Habilidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Removed = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Nome = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Habilidade", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioXHabilidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Removed = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IdFuncionario = table.Column<int>(nullable: false),
                    IdHabilidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioXHabilidade", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_TB_FuncionarioXHabilidade_TB_Funcionario",
                        column: x => x.IdFuncionario,
                        principalTable: "TB_Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_FuncionarioXHabilidade_TB_Habilidade",
                        column: x => x.IdHabilidade,
                        principalTable: "TB_Habilidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioXHabilidade_IdFuncionario",
                table: "FuncionarioXHabilidade",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioXHabilidade_IdHabilidade",
                table: "FuncionarioXHabilidade",
                column: "IdHabilidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioXHabilidade");

            migrationBuilder.DropTable(
                name: "TB_Funcionario");

            migrationBuilder.DropTable(
                name: "TB_Habilidade");
        }
    }
}
