using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCitySecurity.Migrations
{
    /// <inheritdoc />
    public partial class AddHabitantesAndCrimesAndEmergenciasAndSistemasVigilanciaAndRecursosPoliciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CRIME",
                columns: table => new
                {
                    CrimeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeCrime = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TipoCrime = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StatusCrime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gravidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ArmaUtilizada = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRIME", x => x.CrimeId);
                });

            migrationBuilder.CreateTable(
                name: "HABITANTE",
                columns: table => new
                {
                    HabitanteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HabitanteNome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnderecoHabitante = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Cpf = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Telefone = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Observacoes = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    HistoricoCriminal = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HABITANTE", x => x.HabitanteId);
                });

            migrationBuilder.CreateTable(
                name: "SISTEMA_VIGILANCIA",
                columns: table => new
                {
                    SistemaVigilanciaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SistemaNome = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    SistemaLocalizacao = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResolucaVideo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataVideo = table.Column<DateTime>(type: "date", nullable: false),
                    UltimaManutencao = table.Column<DateTime>(type: "date", nullable: false),
                    Instalacao = table.Column<DateTime>(type: "date", nullable: false),
                    ResponsavelManutencao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RegistroIncidentes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISTEMA_VIGILANCIA", x => x.SistemaVigilanciaId);
                });

            migrationBuilder.CreateTable(
                name: "EMERGENCIA",
                columns: table => new
                {
                    EmergenciaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoEmergencia = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    DataEmergencia = table.Column<DateTime>(type: "date", nullable: false),
                    LocalEmergencia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    StatusEmergencia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HabitanteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SistemaVigilanciaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMERGENCIA", x => x.EmergenciaId);
                    table.ForeignKey(
                        name: "FK_EMERGENCIA_HABITANTE_HabitanteId",
                        column: x => x.HabitanteId,
                        principalTable: "HABITANTE",
                        principalColumn: "HabitanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMERGENCIA_SISTEMA_VIGILANCIA_SistemaVigilanciaId",
                        column: x => x.SistemaVigilanciaId,
                        principalTable: "SISTEMA_VIGILANCIA",
                        principalColumn: "SistemaVigilanciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RECURSOS_POLICIAIS",
                columns: table => new
                {
                    RecursoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Recurso = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TipoRecurso = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    LocalizacaoRecurso = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NomeAgentes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Delegacias = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Capacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Aquisicao = table.Column<DateTime>(type: "date", nullable: false),
                    UltimaManutencao = table.Column<DateTime>(type: "date", nullable: false),
                    ReponsavelManutencao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmergenciaID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECURSOS_POLICIAIS", x => x.RecursoId);
                    table.ForeignKey(
                        name: "FK_RECURSOS_POLICIAIS_EMERGENCIA_EmergenciaID",
                        column: x => x.EmergenciaID,
                        principalTable: "EMERGENCIA",
                        principalColumn: "EmergenciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_NOME_TIPO",
                table: "CRIME",
                columns: new[] { "NomeCrime", "TipoCrime" });

            migrationBuilder.CreateIndex(
                name: "IX_CRIME_CrimeId",
                table: "CRIME",
                column: "CrimeId");

            migrationBuilder.CreateIndex(
                name: "IDX_TIPO_DATA",
                table: "EMERGENCIA",
                columns: new[] { "TipoEmergencia", "DataEmergencia" });

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCIA_EmergenciaId",
                table: "EMERGENCIA",
                column: "EmergenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCIA_HabitanteId",
                table: "EMERGENCIA",
                column: "HabitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_EMERGENCIA_SistemaVigilanciaId",
                table: "EMERGENCIA",
                column: "SistemaVigilanciaId");

            migrationBuilder.CreateIndex(
                name: "IDX_ENDERECO_CPF",
                table: "HABITANTE",
                columns: new[] { "EnderecoHabitante", "Cpf" });

            migrationBuilder.CreateIndex(
                name: "IX_HABITANTE_HabitanteId",
                table: "HABITANTE",
                column: "HabitanteId");

            migrationBuilder.CreateIndex(
                name: "IDX_RECURSO_DISPONIBILIDADE",
                table: "RECURSOS_POLICIAIS",
                columns: new[] { "Recurso", "Disponibilidade" });

            migrationBuilder.CreateIndex(
                name: "IX_RECURSOS_POLICIAIS_EmergenciaID",
                table: "RECURSOS_POLICIAIS",
                column: "EmergenciaID");

            migrationBuilder.CreateIndex(
                name: "IX_RECURSOS_POLICIAIS_RecursoId",
                table: "RECURSOS_POLICIAIS",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IDX_NOME_LOCAL",
                table: "SISTEMA_VIGILANCIA",
                columns: new[] { "SistemaNome", "SistemaLocalizacao" });

            migrationBuilder.CreateIndex(
                name: "IX_SISTEMA_VIGILANCIA_SistemaVigilanciaId",
                table: "SISTEMA_VIGILANCIA",
                column: "SistemaVigilanciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CRIME");

            migrationBuilder.DropTable(
                name: "RECURSOS_POLICIAIS");

            migrationBuilder.DropTable(
                name: "EMERGENCIA");

            migrationBuilder.DropTable(
                name: "HABITANTE");

            migrationBuilder.DropTable(
                name: "SISTEMA_VIGILANCIA");
        }
    }
}
