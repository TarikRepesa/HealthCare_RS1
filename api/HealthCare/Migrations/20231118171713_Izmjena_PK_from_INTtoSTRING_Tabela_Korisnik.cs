using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class IzmjenaPKfromINTtoSTRINGTabelaKorisnik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PacijentId",
                table: "ZdravstvenaLegitimacija",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LjekarId",
                table: "Uputnica",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacijentId",
                table: "Uputnica",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LjekarId",
                table: "Termin",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacijentId",
                table: "Termin",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LjekarId",
                table: "Recept",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacijentId",
                table: "Recept",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OdjeljenjeId",
                table: "Osoblje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LjekarId",
                table: "Nalaz",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacijentId",
                table: "Nalaz",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacijentId",
                table: "Karton",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ApotekaId",
                table: "Farmaceut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AmbulantaOsoblje",
                columns: table => new
                {
                    AmbulanteId = table.Column<int>(type: "int", nullable: false),
                    OsobljaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbulantaOsoblje", x => new { x.AmbulanteId, x.OsobljaId });
                    table.ForeignKey(
                        name: "FK_AmbulantaOsoblje_Ambulanta_AmbulanteId",
                        column: x => x.AmbulanteId,
                        principalTable: "Ambulanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AmbulantaOsoblje_Osoblje_OsobljaId",
                        column: x => x.OsobljaId,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KartonLjekar",
                columns: table => new
                {
                    KartoniId = table.Column<int>(type: "int", nullable: false),
                    LjekariId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartonLjekar", x => new { x.KartoniId, x.LjekariId });
                    table.ForeignKey(
                        name: "FK_KartonLjekar_Karton_KartoniId",
                        column: x => x.KartoniId,
                        principalTable: "Karton",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KartonLjekar_Ljekar_LjekariId",
                        column: x => x.LjekariId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    KorisniciId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UlogeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUloga", x => new { x.KorisniciId, x.UlogeId });
                    table.ForeignKey(
                        name: "FK_KorisnikUloga_Korisnik_KorisniciId",
                        column: x => x.KorisniciId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KorisnikUloga_Uloga_UlogeId",
                        column: x => x.UlogeId,
                        principalTable: "Uloga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZdravstvenaLegitimacija_PacijentId",
                table: "ZdravstvenaLegitimacija",
                column: "PacijentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_LjekarId",
                table: "Uputnica",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_PacijentId",
                table: "Uputnica",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_LjekarId",
                table: "Termin",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_PacijentId",
                table: "Termin",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recept_LjekarId",
                table: "Recept",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Recept_PacijentId",
                table: "Recept",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Osoblje_OdjeljenjeId",
                table: "Osoblje",
                column: "OdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nalaz_LjekarId",
                table: "Nalaz",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Nalaz_PacijentId",
                table: "Nalaz",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Karton_PacijentId",
                table: "Karton",
                column: "PacijentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farmaceut_ApotekaId",
                table: "Farmaceut",
                column: "ApotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_AmbulantaOsoblje_OsobljaId",
                table: "AmbulantaOsoblje",
                column: "OsobljaId");

            migrationBuilder.CreateIndex(
                name: "IX_KartonLjekar_LjekariId",
                table: "KartonLjekar",
                column: "LjekariId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogeId",
                table: "KorisnikUloga",
                column: "UlogeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmaceut_Apoteka_ApotekaId",
                table: "Farmaceut",
                column: "ApotekaId",
                principalTable: "Apoteka",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Karton_Pacijent_PacijentId",
                table: "Karton",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Nalaz_Ljekar_LjekarId",
                table: "Nalaz",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Nalaz_Pacijent_PacijentId",
                table: "Nalaz",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Osoblje_Odjeljenje_OdjeljenjeId",
                table: "Osoblje",
                column: "OdjeljenjeId",
                principalTable: "Odjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Recept_Ljekar_LjekarId",
                table: "Recept",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Recept_Pacijent_PacijentId",
                table: "Recept",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Ljekar_LjekarId",
                table: "Termin",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Pacijent_PacijentId",
                table: "Termin",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Uputnica_Ljekar_LjekarId",
                table: "Uputnica",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Uputnica_Pacijent_PacijentId",
                table: "Uputnica",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ZdravstvenaLegitimacija_Pacijent_PacijentId",
                table: "ZdravstvenaLegitimacija",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farmaceut_Apoteka_ApotekaId",
                table: "Farmaceut");

            migrationBuilder.DropForeignKey(
                name: "FK_Karton_Pacijent_PacijentId",
                table: "Karton");

            migrationBuilder.DropForeignKey(
                name: "FK_Nalaz_Ljekar_LjekarId",
                table: "Nalaz");

            migrationBuilder.DropForeignKey(
                name: "FK_Nalaz_Pacijent_PacijentId",
                table: "Nalaz");

            migrationBuilder.DropForeignKey(
                name: "FK_Osoblje_Odjeljenje_OdjeljenjeId",
                table: "Osoblje");

            migrationBuilder.DropForeignKey(
                name: "FK_Recept_Ljekar_LjekarId",
                table: "Recept");

            migrationBuilder.DropForeignKey(
                name: "FK_Recept_Pacijent_PacijentId",
                table: "Recept");

            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Ljekar_LjekarId",
                table: "Termin");

            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Pacijent_PacijentId",
                table: "Termin");

            migrationBuilder.DropForeignKey(
                name: "FK_Uputnica_Ljekar_LjekarId",
                table: "Uputnica");

            migrationBuilder.DropForeignKey(
                name: "FK_Uputnica_Pacijent_PacijentId",
                table: "Uputnica");

            migrationBuilder.DropForeignKey(
                name: "FK_ZdravstvenaLegitimacija_Pacijent_PacijentId",
                table: "ZdravstvenaLegitimacija");

            migrationBuilder.DropTable(
                name: "AmbulantaOsoblje");

            migrationBuilder.DropTable(
                name: "KartonLjekar");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropIndex(
                name: "IX_ZdravstvenaLegitimacija_PacijentId",
                table: "ZdravstvenaLegitimacija");

            migrationBuilder.DropIndex(
                name: "IX_Uputnica_LjekarId",
                table: "Uputnica");

            migrationBuilder.DropIndex(
                name: "IX_Uputnica_PacijentId",
                table: "Uputnica");

            migrationBuilder.DropIndex(
                name: "IX_Termin_LjekarId",
                table: "Termin");

            migrationBuilder.DropIndex(
                name: "IX_Termin_PacijentId",
                table: "Termin");

            migrationBuilder.DropIndex(
                name: "IX_Recept_LjekarId",
                table: "Recept");

            migrationBuilder.DropIndex(
                name: "IX_Recept_PacijentId",
                table: "Recept");

            migrationBuilder.DropIndex(
                name: "IX_Osoblje_OdjeljenjeId",
                table: "Osoblje");

            migrationBuilder.DropIndex(
                name: "IX_Nalaz_LjekarId",
                table: "Nalaz");

            migrationBuilder.DropIndex(
                name: "IX_Nalaz_PacijentId",
                table: "Nalaz");

            migrationBuilder.DropIndex(
                name: "IX_Karton_PacijentId",
                table: "Karton");

            migrationBuilder.DropIndex(
                name: "IX_Farmaceut_ApotekaId",
                table: "Farmaceut");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "ZdravstvenaLegitimacija");

            migrationBuilder.DropColumn(
                name: "LjekarId",
                table: "Uputnica");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "Uputnica");

            migrationBuilder.DropColumn(
                name: "LjekarId",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "LjekarId",
                table: "Recept");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "Recept");

            migrationBuilder.DropColumn(
                name: "OdjeljenjeId",
                table: "Osoblje");

            migrationBuilder.DropColumn(
                name: "LjekarId",
                table: "Nalaz");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "Nalaz");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "Karton");

            migrationBuilder.DropColumn(
                name: "ApotekaId",
                table: "Farmaceut");
        }
    }
}
