using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class vezalijekirecept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lijek_Recept_ReceptId",
                table: "Lijek");

            migrationBuilder.DropIndex(
                name: "IX_Lijek_ReceptId",
                table: "Lijek");

            migrationBuilder.DropColumn(
                name: "ReceptId",
                table: "Lijek");

            migrationBuilder.CreateTable(
                name: "LijekRecept",
                columns: table => new
                {
                    LijekoviId = table.Column<int>(type: "int", nullable: false),
                    ReceptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LijekRecept", x => new { x.LijekoviId, x.ReceptId });
                    table.ForeignKey(
                        name: "FK_LijekRecept_Lijek_LijekoviId",
                        column: x => x.LijekoviId,
                        principalTable: "Lijek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LijekRecept_Recept_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LijekRecept_ReceptId",
                table: "LijekRecept",
                column: "ReceptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LijekRecept");

            migrationBuilder.AddColumn<int>(
                name: "ReceptId",
                table: "Lijek",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lijek_ReceptId",
                table: "Lijek",
                column: "ReceptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lijek_Recept_ReceptId",
                table: "Lijek",
                column: "ReceptId",
                principalTable: "Recept",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
