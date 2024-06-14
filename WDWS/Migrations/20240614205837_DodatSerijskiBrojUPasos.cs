using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class DodatSerijskiBrojUPasos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzije_Klijenti_klijentId",
                table: "Recenzije");

            migrationBuilder.DropIndex(
                name: "IX_Recenzije_klijentId",
                table: "Recenzije");

            migrationBuilder.DropColumn(
                name: "klijentId",
                table: "Recenzije");

            migrationBuilder.AlterColumn<string>(
                name: "clientID",
                table: "Recenzije",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "serijskiBroj",
                table: "Pasosi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_clientID",
                table: "Recenzije",
                column: "clientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzije_Klijenti_clientID",
                table: "Recenzije",
                column: "clientID",
                principalTable: "Klijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzije_Klijenti_clientID",
                table: "Recenzije");

            migrationBuilder.DropIndex(
                name: "IX_Recenzije_clientID",
                table: "Recenzije");

            migrationBuilder.DropColumn(
                name: "serijskiBroj",
                table: "Pasosi");

            migrationBuilder.AlterColumn<string>(
                name: "clientID",
                table: "Recenzije",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "klijentId",
                table: "Recenzije",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_klijentId",
                table: "Recenzije",
                column: "klijentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzije_Klijenti_klijentId",
                table: "Recenzije",
                column: "klijentId",
                principalTable: "Klijenti",
                principalColumn: "Id");
        }
    }
}
