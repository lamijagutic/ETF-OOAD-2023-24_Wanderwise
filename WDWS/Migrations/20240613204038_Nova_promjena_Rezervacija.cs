using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class Nova_promjena_Rezervacija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Klijenti_klijentId",
                table: "Rezervacije");*/

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
            
            

            /*migrationBuilder.RenameColumn(
                name: "klijentID",
                table: "Rezervacije",
                newName: "klijentId");*/

            /*migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_klijentId",
                table: "Rezervacije",
                column: "klijentID");

            migrationBuilder.AlterColumn<string>(
                name: "klijentID",
                table: "Rezervacije",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);*/

            migrationBuilder.AddColumn<string>(
                name: "adresa",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "datumRodjenja",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "pozicija",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "spol",
                table: "AspNetUsers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            /*migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Klijenti_klijentID",
                table: "Rezervacije",
                column: "klijentID",
                principalTable: "Klijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
            
            migrationBuilder.AddColumn<string>(
                name: "klijentID",
                table: "Rezervacije",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Klijenti_klijentID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "adresa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "datumRodjenja",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "pozicija",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "spol",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "klijentID",
                table: "Rezervacije",
                newName: "klijentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacije_klijentID",
                table: "Rezervacije",
                newName: "IX_Rezervacije_klijentId");

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

            migrationBuilder.AlterColumn<string>(
                name: "klijentId",
                table: "Rezervacije",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "clientID",
                table: "Rezervacije",
                type: "nvarchar(max)",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Klijenti_klijentId",
                table: "Rezervacije",
                column: "klijentId",
                principalTable: "Klijenti",
                principalColumn: "Id");
        }
    }
}
