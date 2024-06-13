using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            
            migrationBuilder.DropColumn(
                name: "adresa",
                table: "AspNetUsers");
            
            migrationBuilder.DropColumn(
                name: "datumRodjenja",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Klijenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
            
            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "Klijenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
            
            migrationBuilder.AddColumn<string>(
                name: "adresa",
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
            
            migrationBuilder.AddColumn<DateTime>(
                name: "datumRodjenja",
                table: "Klijenti",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            
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
            
            migrationBuilder.AddColumn<int>(
                name: "pozicija",
                table: "Klijenti",
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
                table: "Turisticki vodici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
            /*migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Klijenti_klijentID",
                table: "Rezervacije",
                column: "klijentID",
                principalTable: "Klijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ime",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "spol",
                table: "Klijenti");
            
            migrationBuilder.DropColumn(
                name: "adresa",
                table: "Klijenti");
            
            migrationBuilder.DropColumn(
                name: "datumRodjenja",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "Turisticki vodici");

            migrationBuilder.DropColumn(
                name: "spol",
                table: "Turisticki vodici");
            
            migrationBuilder.DropColumn(
                name: "adresa",
                table: "Turisticki vodici");
            
            migrationBuilder.DropColumn(
                name: "datumRodjenja",
                table: "Turisticki vodici");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Klijenti_klijentID",
                table: "Rezervacije");
        }
    }
}
