using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablePacijentRecept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacijent_Recept_ReceptId",
                table: "Pacijent");

            migrationBuilder.DropIndex(
                name: "IX_Pacijent_ReceptId",
                table: "Pacijent");

            migrationBuilder.DropColumn(
                name: "ReceptId",
                table: "Pacijent");

            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "Recept",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recept_PacijentId",
                table: "Recept",
                column: "PacijentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recept_Pacijent_PacijentId",
                table: "Recept",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recept_Pacijent_PacijentId",
                table: "Recept");

            migrationBuilder.DropIndex(
                name: "IX_Recept_PacijentId",
                table: "Recept");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "Recept");

            migrationBuilder.AddColumn<int>(
                name: "ReceptId",
                table: "Pacijent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacijent_ReceptId",
                table: "Pacijent",
                column: "ReceptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijent_Recept_ReceptId",
                table: "Pacijent",
                column: "ReceptId",
                principalTable: "Recept",
                principalColumn: "Id");
        }
    }
}
