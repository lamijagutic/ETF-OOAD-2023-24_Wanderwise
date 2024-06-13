using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WDWS.Migrations
{
    /// <inheritdoc />
    public partial class MakeGuideIDNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Putovanja_Smjestaji_smjestajID",
                table: "Putovanja");

            migrationBuilder.DropForeignKey(
                name: "FK_Putovanja_Turisticki vodici_guideID",
                table: "Putovanja");

            migrationBuilder.AlterColumn<int>(
                name: "smjestajID",
                table: "Putovanja",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "guideID",
                table: "Putovanja",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Putovanja_Smjestaji_smjestajID",
                table: "Putovanja",
                column: "smjestajID",
                principalTable: "Smjestaji",
                principalColumn: "lodgingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Putovanja_Turisticki vodici_guideID",
                table: "Putovanja",
                column: "guideID",
                principalTable: "Turisticki vodici",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Putovanja_Smjestaji_smjestajID",
                table: "Putovanja");

            migrationBuilder.DropForeignKey(
                name: "FK_Putovanja_Turisticki vodici_guideID",
                table: "Putovanja");

            migrationBuilder.AlterColumn<int>(
                name: "smjestajID",
                table: "Putovanja",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "guideID",
                table: "Putovanja",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Putovanja_Smjestaji_smjestajID",
                table: "Putovanja",
                column: "smjestajID",
                principalTable: "Smjestaji",
                principalColumn: "lodgingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Putovanja_Turisticki vodici_guideID",
                table: "Putovanja",
                column: "guideID",
                principalTable: "Turisticki vodici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
