using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class PromijenjenAtributClientID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "naziv",
                table: "Smjestaji",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "VodicUkljucen",
                table: "Rezervacije",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Putovanja",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpisPutovanja",
                table: "Putovanja",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "clientID",
                table: "Pasosi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "drzava",
                table: "Lokacije",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VodicUkljucen",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Putovanja");

            migrationBuilder.DropColumn(
                name: "OpisPutovanja",
                table: "Putovanja");

            migrationBuilder.AlterColumn<string>(
                name: "naziv",
                table: "Smjestaji",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "clientID",
                table: "Pasosi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "drzava",
                table: "Lokacije",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
