using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class newNullableAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Smjestaji_Lokacije_lokacijapostanskiBroj",
                table: "Smjestaji");

            migrationBuilder.AlterColumn<string>(
                name: "lokacijapostanskiBroj",
                table: "Smjestaji",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "napomene",
                table: "Pasosi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nacionalnost",
                table: "Pasosi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "drzavaKojaIzdaje",
                table: "Pasosi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Smjestaji_Lokacije_lokacijapostanskiBroj",
                table: "Smjestaji",
                column: "lokacijapostanskiBroj",
                principalTable: "Lokacije",
                principalColumn: "postanskiBroj");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Smjestaji_Lokacije_lokacijapostanskiBroj",
                table: "Smjestaji");

            migrationBuilder.AlterColumn<string>(
                name: "lokacijapostanskiBroj",
                table: "Smjestaji",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "napomene",
                table: "Pasosi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nacionalnost",
                table: "Pasosi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "drzavaKojaIzdaje",
                table: "Pasosi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Smjestaji_Lokacije_lokacijapostanskiBroj",
                table: "Smjestaji",
                column: "lokacijapostanskiBroj",
                principalTable: "Lokacije",
                principalColumn: "postanskiBroj",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
