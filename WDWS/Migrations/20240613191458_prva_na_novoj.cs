using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class prva_na_novoj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Klijenti_Korisnici_Id",
                table: "Klijenti");

            migrationBuilder.DropForeignKey(
                name: "FK_Turisticki vodici_Korisnici_Id",
                table: "Turisticki vodici");*/

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.AddColumn<string>(
                name: "adresa",
                table: "Turisticki vodici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "datumRodjenja",
                table: "Turisticki vodici",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Turisticki vodici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "pozicija",
                table: "Turisticki vodici",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "Turisticki vodici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "spol",
                table: "Turisticki vodici",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "adresa",
                table: "Klijenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "datumRodjenja",
                table: "Klijenti",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Klijenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "pozicija",
                table: "Klijenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "Klijenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "spol",
                table: "Klijenti",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            /*migrationBuilder.AddForeignKey(
                name: "FK_Klijenti_AspNetUsers_Id",
                table: "Klijenti",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/

            migrationBuilder.AddForeignKey(
                name: "FK_Turisticki vodici_AspNetUsers_Id",
                table: "Turisticki vodici",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijenti_AspNetUsers_Id",
                table: "Klijenti");

            migrationBuilder.DropForeignKey(
                name: "FK_Turisticki vodici_AspNetUsers_Id",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "adresa",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "datumRodjenja",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "pozicija",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "spol",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "adresa",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "datumRodjenja",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "pozicija",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "spol",
                table: "Klijenti");

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pozicija = table.Column<int>(type: "int", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spol = table.Column<string>(type: "nvarchar(1)", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Klijenti_Korisnici_Id",
                table: "Klijenti",
                column: "Id",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turisticki vodici_Korisnici_Id",
                table: "Turisticki vodici",
                column: "Id",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
