using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeslocamentoAPI.Data.Migrations
{
    public partial class CarregamentoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPF",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nome",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deslocamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroId = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    CondutorId = table.Column<long>(type: "bigint", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    QuilometragemInicial = table.Column<decimal>(type: "decimal", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, defaultValue: "Sem observação"),
                    DataHoraFim = table.Column<DateTime>(type: "datetime", nullable: true),
                    QuilometragemFinal = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deslocamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carro_Deslocamento_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_Deslocamento_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CPF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Condutor_Deslocamento_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Nome",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deslocamento_CarroId",
                table: "Deslocamento",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Deslocamento_ClienteId",
                table: "Deslocamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Deslocamento_CondutorId",
                table: "Deslocamento",
                column: "CondutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deslocamento");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "CPF");

            migrationBuilder.DropTable(
                name: "Nome");
        }
    }
}
