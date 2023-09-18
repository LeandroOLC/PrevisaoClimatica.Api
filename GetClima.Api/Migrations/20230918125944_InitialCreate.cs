using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisaoClimatica.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AeroportoPrevisao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoIcao = table.Column<string>(type: "varchar(10)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PressaoAtmosferica = table.Column<int>(type: "int", nullable: false),
                    Visibilidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Vento = table.Column<int>(type: "int", nullable: false),
                    DirecaoVento = table.Column<int>(type: "int", nullable: false),
                    Umidade = table.Column<int>(type: "int", nullable: false),
                    Condicao = table.Column<string>(type: "varchar(100)", nullable: false),
                    DescricaoClima = table.Column<string>(type: "varchar(200)", nullable: false),
                    Tempo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AeroportoPrevisao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CidadePrevisao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(150)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(150)", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condicao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    IndiceUV = table.Column<int>(type: "int", nullable: false),
                    DescricaoClima = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadePrevisao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AeroportoPrevisao");

            migrationBuilder.DropTable(
                name: "CidadePrevisao");
        }
    }
}
