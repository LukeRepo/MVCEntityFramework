using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionaleConferenze.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    AutoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Skills = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.AutoreId);
                });

            migrationBuilder.CreateTable(
                name: "Presentazioni",
                columns: table => new
                {
                    PresentazioneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(maxLength: 25, nullable: false),
                    DataInizio = table.Column<DateTime>(nullable: false),
                    DataFine = table.Column<DateTime>(nullable: false),
                    Livello = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentazioni", x => x.PresentazioneId);
                });

            migrationBuilder.CreateTable(
                name: "Registrazioni",
                columns: table => new
                {
                    AutoreId = table.Column<int>(nullable: false),
                    PresentazioneId = table.Column<int>(nullable: false),
                    RegistrazioneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrazioni", x => x.RegistrazioneId);
                    table.ForeignKey(
                        name: "FK_Registrazioni_Autori_AutoreId",
                        column: x => x.AutoreId,
                        principalTable: "Autori",
                        principalColumn: "AutoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrazioni_Presentazioni_PresentazioneId",
                        column: x => x.PresentazioneId,
                        principalTable: "Presentazioni",
                        principalColumn: "PresentazioneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrazioni_AutoreId",
                table: "Registrazioni",
                column: "AutoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrazioni_PresentazioneId",
                table: "Registrazioni",
                column: "PresentazioneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrazioni");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "Presentazioni");
        }
    }
}
