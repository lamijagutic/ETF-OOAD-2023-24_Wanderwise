using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ime = table.Column<string>(type: "TEXT", nullable: false),
                    prezime = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    telefon = table.Column<string>(type: "TEXT", nullable: false),
                    adresa = table.Column<string>(type: "TEXT", nullable: false),
                    spol = table.Column<char>(type: "TEXT", nullable: false),
                    datumRodjenja = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    pozicija = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnici_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lokacije",
                columns: table => new
                {
                    postanskiBroj = table.Column<string>(type: "TEXT", nullable: false),
                    nazivMjesta = table.Column<string>(type: "TEXT", nullable: false),
                    drzava = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacije", x => x.postanskiBroj);
                });

            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    kontaktZaHitneSlucajeve = table.Column<string>(type: "TEXT", nullable: false),
                    napomene = table.Column<string>(type: "TEXT", nullable: false),
                    nagradniBodovi = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klijenti_Korisnici_Id",
                        column: x => x.Id,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turisticki vodici",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    jezici = table.Column<string>(type: "TEXT", nullable: false),
                    dostupnost = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turisticki vodici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turisticki vodici_Korisnici_Id",
                        column: x => x.Id,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smjestaji",
                columns: table => new
                {
                    SmjestajID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naziv = table.Column<string>(type: "TEXT", nullable: false),
                    VrstaSmjestaja = table.Column<int>(type: "INTEGER", nullable: false),
                    lokacijapostanskiBroj = table.Column<string>(type: "TEXT", nullable: true),
                    KontaktTelefon = table.Column<string>(type: "TEXT", nullable: false),
                    KontaktEmail = table.Column<string>(type: "TEXT", nullable: false),
                    MaxKapacitet = table.Column<int>(type: "INTEGER", nullable: false),
                    CijenaSmjestaja = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smjestaji", x => x.SmjestajID);
                    table.ForeignKey(
                        name: "FK_Smjestaji_Lokacije_lokacijapostanskiBroj",
                        column: x => x.lokacijapostanskiBroj,
                        principalTable: "Lokacije",
                        principalColumn: "postanskiBroj");
                });

            migrationBuilder.CreateTable(
                name: "Pasosi",
                columns: table => new
                {
                    pasosID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KlijentID = table.Column<int>(type: "INTEGER", nullable: false),
                    klijentId = table.Column<string>(type: "TEXT", nullable: true),
                    drzavaKojaIzdaje = table.Column<string>(type: "TEXT", nullable: false),
                    nacionalnost = table.Column<string>(type: "TEXT", nullable: false),
                    datumIsteka = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    napomene = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasosi", x => x.pasosID);
                    table.ForeignKey(
                        name: "FK_Pasosi_Klijenti_klijentId",
                        column: x => x.klijentId,
                        principalTable: "Klijenti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Putovanja",
                columns: table => new
                {
                    putovanjeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mjestoPolaskapostanskiBroj = table.Column<string>(type: "TEXT", nullable: true),
                    mjestoDolaskapostanskiBroj = table.Column<string>(type: "TEXT", nullable: true),
                    duzinaPutovanja = table.Column<int>(type: "INTEGER", nullable: false),
                    datumPolaska = table.Column<DateTime>(type: "TEXT", nullable: false),
                    datumDolaska = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cijenaPoOsobi = table.Column<double>(type: "REAL", nullable: false),
                    prijevoznaSredstva = table.Column<string>(type: "TEXT", nullable: false),
                    smjestajID = table.Column<int>(type: "INTEGER", nullable: false),
                    vodicID = table.Column<int>(type: "INTEGER", nullable: false),
                    vodicId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putovanja", x => x.putovanjeID);
                    table.ForeignKey(
                        name: "FK_Putovanja_Lokacije_mjestoDolaskapostanskiBroj",
                        column: x => x.mjestoDolaskapostanskiBroj,
                        principalTable: "Lokacije",
                        principalColumn: "postanskiBroj");
                    table.ForeignKey(
                        name: "FK_Putovanja_Lokacije_mjestoPolaskapostanskiBroj",
                        column: x => x.mjestoPolaskapostanskiBroj,
                        principalTable: "Lokacije",
                        principalColumn: "postanskiBroj");
                    table.ForeignKey(
                        name: "FK_Putovanja_Turisticki vodici_vodicId",
                        column: x => x.vodicId,
                        principalTable: "Turisticki vodici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sobe",
                columns: table => new
                {
                    SobaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tipSobe = table.Column<int>(type: "INTEGER", nullable: false),
                    kapacitetSobe = table.Column<int>(type: "INTEGER", nullable: false),
                    cijena = table.Column<double>(type: "REAL", nullable: false),
                    smjestajID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobe", x => x.SobaID);
                    table.ForeignKey(
                        name: "FK_Sobe_Smjestaji_smjestajID",
                        column: x => x.smjestajID,
                        principalTable: "Smjestaji",
                        principalColumn: "SmjestajID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    RecenzijaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tekstRecenzije = table.Column<string>(type: "TEXT", nullable: false),
                    putovanjeID = table.Column<int>(type: "INTEGER", nullable: false),
                    KlijentID = table.Column<int>(type: "INTEGER", nullable: false),
                    klijentId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzije", x => x.RecenzijaID);
                    table.ForeignKey(
                        name: "FK_Recenzije_Klijenti_klijentId",
                        column: x => x.klijentId,
                        principalTable: "Klijenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recenzije_Putovanja_putovanjeID",
                        column: x => x.putovanjeID,
                        principalTable: "Putovanja",
                        principalColumn: "putovanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    rezervacijaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    putovanjeID = table.Column<int>(type: "INTEGER", nullable: false),
                    brojPutnika = table.Column<int>(type: "INTEGER", nullable: false),
                    ukupnaCijena = table.Column<double>(type: "REAL", nullable: false),
                    MilesBodovi = table.Column<int>(type: "INTEGER", nullable: false),
                    smjestajID = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    klijentID = table.Column<int>(type: "INTEGER", nullable: false),
                    klijentId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.rezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Klijenti_klijentId",
                        column: x => x.klijentId,
                        principalTable: "Klijenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezervacije_Putovanja_putovanjeID",
                        column: x => x.putovanjeID,
                        principalTable: "Putovanja",
                        principalColumn: "putovanjeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Smjestaji_smjestajID",
                        column: x => x.smjestajID,
                        principalTable: "Smjestaji",
                        principalColumn: "SmjestajID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pasosi_klijentId",
                table: "Pasosi",
                column: "klijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanja_mjestoDolaskapostanskiBroj",
                table: "Putovanja",
                column: "mjestoDolaskapostanskiBroj");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanja_mjestoPolaskapostanskiBroj",
                table: "Putovanja",
                column: "mjestoPolaskapostanskiBroj");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanja_vodicId",
                table: "Putovanja",
                column: "vodicId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_klijentId",
                table: "Recenzije",
                column: "klijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_putovanjeID",
                table: "Recenzije",
                column: "putovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_klijentId",
                table: "Rezervacije",
                column: "klijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_putovanjeID",
                table: "Rezervacije",
                column: "putovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_smjestajID",
                table: "Rezervacije",
                column: "smjestajID");

            migrationBuilder.CreateIndex(
                name: "IX_Smjestaji_lokacijapostanskiBroj",
                table: "Smjestaji",
                column: "lokacijapostanskiBroj");

            migrationBuilder.CreateIndex(
                name: "IX_Sobe_smjestajID",
                table: "Sobe",
                column: "smjestajID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pasosi");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Sobe");

            migrationBuilder.DropTable(
                name: "Klijenti");

            migrationBuilder.DropTable(
                name: "Putovanja");

            migrationBuilder.DropTable(
                name: "Smjestaji");

            migrationBuilder.DropTable(
                name: "Turisticki vodici");

            migrationBuilder.DropTable(
                name: "Lokacije");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
