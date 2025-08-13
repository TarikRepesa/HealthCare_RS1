using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class PovezivanjeTabeleTerminLjekar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vrijeme",
                table: "Termin",
                newName: "VrijemeOd");

            migrationBuilder.AddColumn<int>(
                name: "LjekarId",
                table: "Termin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "VrijemeDo",
                table: "Termin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isZakazan",
                table: "Termin",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Termin_LjekarId",
                table: "Termin",
                column: "LjekarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Ljekar_LjekarId",
                table: "Termin",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Ljekar_LjekarId",
                table: "Termin");

            migrationBuilder.DropIndex(
                name: "IX_Termin_LjekarId",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "LjekarId",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "VrijemeDo",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "isZakazan",
                table: "Termin");

            migrationBuilder.RenameColumn(
                name: "VrijemeOd",
                table: "Termin",
                newName: "Vrijeme");
        }
    }
}
