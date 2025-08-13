using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class altertableuputnicaodjeljenjeodsjek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odjeljenje",
                table: "Uputnica");

            migrationBuilder.AddColumn<int>(
                name: "OdjeljenjeId",
                table: "Uputnica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OdsjekId",
                table: "Uputnica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_OdjeljenjeId",
                table: "Uputnica",
                column: "OdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_OdsjekId",
                table: "Uputnica",
                column: "OdsjekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uputnica_Odjeljenje_OdjeljenjeId",
                table: "Uputnica",
                column: "OdjeljenjeId",
                principalTable: "Odjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uputnica_Odsjek_OdsjekId",
                table: "Uputnica",
                column: "OdsjekId",
                principalTable: "Odsjek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uputnica_Odjeljenje_OdjeljenjeId",
                table: "Uputnica");

            migrationBuilder.DropForeignKey(
                name: "FK_Uputnica_Odsjek_OdsjekId",
                table: "Uputnica");

            migrationBuilder.DropIndex(
                name: "IX_Uputnica_OdjeljenjeId",
                table: "Uputnica");

            migrationBuilder.DropIndex(
                name: "IX_Uputnica_OdsjekId",
                table: "Uputnica");

            migrationBuilder.DropColumn(
                name: "OdjeljenjeId",
                table: "Uputnica");

            migrationBuilder.DropColumn(
                name: "OdsjekId",
                table: "Uputnica");

            migrationBuilder.AddColumn<string>(
                name: "Odjeljenje",
                table: "Uputnica",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
