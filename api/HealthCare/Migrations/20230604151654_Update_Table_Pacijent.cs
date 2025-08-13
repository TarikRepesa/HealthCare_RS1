using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablePacijent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacijent_Recept_ReceptId",
                table: "Pacijent");

            migrationBuilder.AlterColumn<int>(
                name: "ReceptId",
                table: "Pacijent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijent_Recept_ReceptId",
                table: "Pacijent",
                column: "ReceptId",
                principalTable: "Recept",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacijent_Recept_ReceptId",
                table: "Pacijent");

            migrationBuilder.AlterColumn<int>(
                name: "ReceptId",
                table: "Pacijent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijent_Recept_ReceptId",
                table: "Pacijent",
                column: "ReceptId",
                principalTable: "Recept",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
