using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class BazniTip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spol = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    pozicija = table.Column<int>(type: "int", nullable: false),
                    datumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacije",
                columns: table => new
                {
                    postanskiBroj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nazivMjesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzava = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacije", x => x.postanskiBroj);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    kontaktZaHitneSlucajeve = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    napomene = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nagradniBodovi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klijenti_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turisticki vodici",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    jezici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dostupnost = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turisticki vodici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turisticki vodici_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smjestaji",
                columns: table => new
                {
                    lodgingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VrstaSmjestaja = table.Column<int>(type: "int", nullable: false),
                    lokacijaID = table.Column<int>(type: "int", nullable: false),
                    lokacijapostanskiBroj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KontaktTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxKapacitet = table.Column<int>(type: "int", nullable: false),
                    CijenaSmjestaja = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smjestaji", x => x.lodgingID);
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    drzavaKojaIzdaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nacionalnost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datumIsteka = table.Column<DateOnly>(type: "date", nullable: false),
                    napomene = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasosi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pasosi_Klijenti_clientID",
                        column: x => x.clientID,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Putovanja",
                columns: table => new
                {
                    travelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mjestoPolaskaID = table.Column<int>(type: "int", nullable: false),
                    mjestoDolaskaID = table.Column<int>(type: "int", nullable: false),
                    duzinaPutovanja = table.Column<int>(type: "int", nullable: false),
                    nazivPutovanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumPolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumDolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cijenaPoOsobi = table.Column<double>(type: "float", nullable: false),
                    prijevoz = table.Column<int>(type: "int", nullable: false),
                    smjestajID = table.Column<int>(type: "int", nullable: true),
                    guideID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisPutovanja = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putovanja", x => x.travelId);
                    table.ForeignKey(
                        name: "FK_Putovanja_Smjestaji_smjestajID",
                        column: x => x.smjestajID,
                        principalTable: "Smjestaji",
                        principalColumn: "lodgingID");
                    table.ForeignKey(
                        name: "FK_Putovanja_Turisticki vodici_guideID",
                        column: x => x.guideID,
                        principalTable: "Turisticki vodici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sobe",
                columns: table => new
                {
                    roomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipSobe = table.Column<int>(type: "int", nullable: false),
                    kapacitetSobe = table.Column<int>(type: "int", nullable: false),
                    cijena = table.Column<double>(type: "float", nullable: false),
                    smjestajID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobe", x => x.roomID);
                    table.ForeignKey(
                        name: "FK_Sobe_Smjestaji_smjestajID",
                        column: x => x.smjestajID,
                        principalTable: "Smjestaji",
                        principalColumn: "lodgingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    reviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tekstRecenzije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    putID = table.Column<int>(type: "int", nullable: false),
                    clientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    klijentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzije", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_Recenzije_Klijenti_klijentId",
                        column: x => x.klijentId,
                        principalTable: "Klijenti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recenzije_Putovanja_putID",
                        column: x => x.putID,
                        principalTable: "Putovanja",
                        principalColumn: "travelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    reservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    putovanjeID = table.Column<int>(type: "int", nullable: false),
                    brojPutnika = table.Column<int>(type: "int", nullable: false),
                    ukupnaCijena = table.Column<double>(type: "float", nullable: false),
                    MilesBodovi = table.Column<int>(type: "int", nullable: false),
                    rezervisanaSobaID = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    klijentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VodicUkljucen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.reservationID);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Klijenti_klijentID",
                        column: x => x.klijentID,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Putovanja_putovanjeID",
                        column: x => x.putovanjeID,
                        principalTable: "Putovanja",
                        principalColumn: "travelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pasosi_clientID",
                table: "Pasosi",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanja_guideID",
                table: "Putovanja",
                column: "guideID");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanja_smjestajID",
                table: "Putovanja",
                column: "smjestajID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_klijentId",
                table: "Recenzije",
                column: "klijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_putID",
                table: "Recenzije",
                column: "putID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_klijentID",
                table: "Rezervacije",
                column: "klijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_putovanjeID",
                table: "Rezervacije",
                column: "putovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Smjestaji_lokacijapostanskiBroj",
                table: "Smjestaji",
                column: "lokacijapostanskiBroj");

            migrationBuilder.CreateIndex(
                name: "IX_Sobe_smjestajID",
                table: "Sobe",
                column: "smjestajID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Pasosi");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Sobe");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "AspNetUsers");
        }
    }
}
