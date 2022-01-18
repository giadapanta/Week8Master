﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week8Master.RepositoryEF.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    CorsoCodice = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.CorsoCodice);
                });

            migrationBuilder.CreateTable(
                name: "Docenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitoloStudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorsoCodice = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Studenti_Corsi_CorsoCodice",
                        column: x => x.CorsoCodice,
                        principalTable: "Corsi",
                        principalColumn: "CorsoCodice",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lezioni",
                columns: table => new
                {
                    LezioneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Aula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocenteID = table.Column<int>(type: "int", nullable: false),
                    CorsoCodice = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezioni", x => x.LezioneID);
                    table.ForeignKey(
                        name: "FK_Lezioni_Corsi_CorsoCodice",
                        column: x => x.CorsoCodice,
                        principalTable: "Corsi",
                        principalColumn: "CorsoCodice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lezioni_Docenti_DocenteID",
                        column: x => x.DocenteID,
                        principalTable: "Docenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_CorsoCodice",
                table: "Lezioni",
                column: "CorsoCodice");

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_DocenteID",
                table: "Lezioni",
                column: "DocenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_CorsoCodice",
                table: "Studenti",
                column: "CorsoCodice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lezioni");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Docenti");

            migrationBuilder.DropTable(
                name: "Corsi");
        }
    }
}
