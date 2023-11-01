using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaVan.Motorista.Data.Migrations
{
    /// <inheritdoc />
    public partial class motoristamodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automovel",
                schema: "Motorista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    QtdVaga = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoPor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automovel_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "Motorista",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Passageiro",
                schema: "Motorista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoPor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viagem",
                schema: "Motorista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false),
                    DataHoraPartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoPor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viagem_Automovel_AutomovelId",
                        column: x => x.AutomovelId,
                        principalSchema: "Motorista",
                        principalTable: "Automovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viagem_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "Motorista",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                schema: "Motorista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Posicao = table.Column<int>(type: "int", nullable: false),
                    FormaPagamento = table.Column<int>(type: "int", nullable: false),
                    EstaPago = table.Column<bool>(type: "bit", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ViagemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassageiroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoPor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Passageiro_PassageiroId",
                        column: x => x.PassageiroId,
                        principalSchema: "Motorista",
                        principalTable: "Passageiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Viagem_ViagemId",
                        column: x => x.ViagemId,
                        principalSchema: "Motorista",
                        principalTable: "Viagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automovel_UsuarioId",
                schema: "Motorista",
                table: "Automovel",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PassageiroId",
                schema: "Motorista",
                table: "Reserva",
                column: "PassageiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ViagemId",
                schema: "Motorista",
                table: "Reserva",
                column: "ViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_AutomovelId",
                schema: "Motorista",
                table: "Viagem",
                column: "AutomovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_UsuarioId",
                schema: "Motorista",
                table: "Viagem",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva",
                schema: "Motorista");

            migrationBuilder.DropTable(
                name: "Passageiro",
                schema: "Motorista");

            migrationBuilder.DropTable(
                name: "Viagem",
                schema: "Motorista");

            migrationBuilder.DropTable(
                name: "Automovel",
                schema: "Motorista");
        }
    }
}
