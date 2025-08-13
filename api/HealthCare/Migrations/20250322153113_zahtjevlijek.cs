using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class zahtjevlijek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZahtjevLijekovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Kolicina = table.Column<double>(type: "float", nullable: false),
                    ApotekaId = table.Column<int>(type: "int", nullable: false),
                    LjekarId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevLijekovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahtjevLijekovi_Apoteka_ApotekaId",
                        column: x => x.ApotekaId,
                        principalTable: "Apoteka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtjevLijekovi_Ljekar_LjekarId",
                        column: x => x.LjekarId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjevLijekovi_ApotekaId",
                table: "ZahtjevLijekovi",
                column: "ApotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjevLijekovi_LjekarId",
                table: "ZahtjevLijekovi",
                column: "LjekarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZahtjevLijekovi");
        }
    }
}
