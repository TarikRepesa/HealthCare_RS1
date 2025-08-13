using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class addtableuputnicamanytomanysifrabolesti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UputnicaSifraBolesti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UputnicaId = table.Column<int>(type: "int", nullable: false),
                    SifraBolestiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UputnicaSifraBolesti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UputnicaSifraBolesti_SifraBolesti_SifraBolestiId",
                        column: x => x.SifraBolestiId,
                        principalTable: "SifraBolesti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UputnicaSifraBolesti_Uputnica_UputnicaId",
                        column: x => x.UputnicaId,
                        principalTable: "Uputnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UputnicaSifraBolesti_SifraBolestiId",
                table: "UputnicaSifraBolesti",
                column: "SifraBolestiId");

            migrationBuilder.CreateIndex(
                name: "IX_UputnicaSifraBolesti_UputnicaId",
                table: "UputnicaSifraBolesti",
                column: "UputnicaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UputnicaSifraBolesti");
        }
    }
}
