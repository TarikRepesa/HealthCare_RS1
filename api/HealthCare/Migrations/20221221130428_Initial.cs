using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolnica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolnica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ambulanta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolnicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulanta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ambulanta_Bolnica_BolnicaId",
                        column: x => x.BolnicaId,
                        principalTable: "Bolnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apoteka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolnicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoteka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apoteka_Bolnica_BolnicaId",
                        column: x => x.BolnicaId,
                        principalTable: "Bolnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opstina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolnicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lokacija_Bolnica_BolnicaId",
                        column: x => x.BolnicaId,
                        principalTable: "Bolnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menadzment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uloga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolnicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menadzment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menadzment_Bolnica_BolnicaId",
                        column: x => x.BolnicaId,
                        principalTable: "Bolnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odjeljenje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojOsoblja = table.Column<int>(type: "int", nullable: false),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolnicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odjeljenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odjeljenje_Bolnica_BolnicaId",
                        column: x => x.BolnicaId,
                        principalTable: "Bolnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    KorisniciId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikUloga_Uloga_UlogeId",
                        column: x => x.UlogeId,
                        principalTable: "Uloga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Osoblje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GodineIskustva = table.Column<int>(type: "int", nullable: false),
                    OdjeljenjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoblje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osoblje_Korisnik_Id",
                        column: x => x.Id,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Osoblje_Odjeljenje_OdjeljenjeId",
                        column: x => x.OdjeljenjeId,
                        principalTable: "Odjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmbulantaOsoblje",
                columns: table => new
                {
                    AmbulanteId = table.Column<int>(type: "int", nullable: false),
                    OsobljaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbulantaOsoblje", x => new { x.AmbulanteId, x.OsobljaId });
                    table.ForeignKey(
                        name: "FK_AmbulantaOsoblje_Ambulanta_AmbulanteId",
                        column: x => x.AmbulanteId,
                        principalTable: "Ambulanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmbulantaOsoblje_Osoblje_OsobljaId",
                        column: x => x.OsobljaId,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Asistent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Specijalizacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kvalifikacija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asistent_Osoblje_Id",
                        column: x => x.Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Farmaceut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Radnik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApotekaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmaceut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmaceut_Apoteka_ApotekaId",
                        column: x => x.ApotekaId,
                        principalTable: "Apoteka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Farmaceut_Osoblje_Id",
                        column: x => x.Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ljekar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specjalizacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specifikacija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ljekar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ljekar_Osoblje_Id",
                        column: x => x.Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tehnicar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Specijalizacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kvalifikacija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tehnicar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tehnicar_Osoblje_Id",
                        column: x => x.Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recept",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Doza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SifraBolesti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LjekarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recept", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recept_Ljekar_LjekarId",
                        column: x => x.LjekarId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lijek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    NacinUpotrebe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jacina = table.Column<float>(type: "real", nullable: false),
                    ReceptId = table.Column<int>(type: "int", nullable: false),
                    ProizvodjacId = table.Column<int>(type: "int", nullable: false),
                    ApotekaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lijek_Apoteka_ApotekaId",
                        column: x => x.ApotekaId,
                        principalTable: "Apoteka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lijek_Proizvodjac_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lijek_Recept_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pacijent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DatumRodenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MjestoRodenja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacijent_Korisnik_Id",
                        column: x => x.Id,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacijent_Recept_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Karton",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Karton_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nalaz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioritet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false),
                    LjekarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalaz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nalaz_Ljekar_LjekarId",
                        column: x => x.LjekarId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nalaz_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioritet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false),
                    AmbulantaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Termin_Ambulanta_AmbulantaId",
                        column: x => x.AmbulantaId,
                        principalTable: "Ambulanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Termin_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uputnica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odjeljenje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dijagnoza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Primjedba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVazenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false),
                    LjekarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uputnica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uputnica_Ljekar_LjekarId",
                        column: x => x.LjekarId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uputnica_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZdravstvenaLegitimacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DopunskoOsiguranje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SrodstvoOsiguranika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdravstvenaLegitimacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZdravstvenaLegitimacija_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KartonLjekar",
                columns: table => new
                {
                    KartoniId = table.Column<int>(type: "int", nullable: false),
                    LjekariId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartonLjekar", x => new { x.KartoniId, x.LjekariId });
                    table.ForeignKey(
                        name: "FK_KartonLjekar_Karton_KartoniId",
                        column: x => x.KartoniId,
                        principalTable: "Karton",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KartonLjekar_Ljekar_LjekariId",
                        column: x => x.LjekariId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ambulanta_BolnicaId",
                table: "Ambulanta",
                column: "BolnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_AmbulantaOsoblje_OsobljaId",
                table: "AmbulantaOsoblje",
                column: "OsobljaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apoteka_BolnicaId",
                table: "Apoteka",
                column: "BolnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmaceut_ApotekaId",
                table: "Farmaceut",
                column: "ApotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_Karton_PacijentId",
                table: "Karton",
                column: "PacijentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KartonLjekar_LjekariId",
                table: "KartonLjekar",
                column: "LjekariId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogeId",
                table: "KorisnikUloga",
                column: "UlogeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lijek_ApotekaId",
                table: "Lijek",
                column: "ApotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lijek_ProizvodjacId",
                table: "Lijek",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Lijek_ReceptId",
                table: "Lijek",
                column: "ReceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_BolnicaId",
                table: "Lokacija",
                column: "BolnicaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menadzment_BolnicaId",
                table: "Menadzment",
                column: "BolnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nalaz_LjekarId",
                table: "Nalaz",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Nalaz_PacijentId",
                table: "Nalaz",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_BolnicaId",
                table: "Odjeljenje",
                column: "BolnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Osoblje_OdjeljenjeId",
                table: "Osoblje",
                column: "OdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijent_ReceptId",
                table: "Pacijent",
                column: "ReceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Recept_LjekarId",
                table: "Recept",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_AmbulantaId",
                table: "Termin",
                column: "AmbulantaId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_PacijentId",
                table: "Termin",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_LjekarId",
                table: "Uputnica",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_PacijentId",
                table: "Uputnica",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdravstvenaLegitimacija_PacijentId",
                table: "ZdravstvenaLegitimacija",
                column: "PacijentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmbulantaOsoblje");

            migrationBuilder.DropTable(
                name: "Asistent");

            migrationBuilder.DropTable(
                name: "Farmaceut");

            migrationBuilder.DropTable(
                name: "KartonLjekar");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "Lijek");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Menadzment");

            migrationBuilder.DropTable(
                name: "Nalaz");

            migrationBuilder.DropTable(
                name: "Tehnicar");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "Uputnica");

            migrationBuilder.DropTable(
                name: "ZdravstvenaLegitimacija");

            migrationBuilder.DropTable(
                name: "Karton");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Apoteka");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "Ambulanta");

            migrationBuilder.DropTable(
                name: "Pacijent");

            migrationBuilder.DropTable(
                name: "Recept");

            migrationBuilder.DropTable(
                name: "Ljekar");

            migrationBuilder.DropTable(
                name: "Osoblje");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Odjeljenje");

            migrationBuilder.DropTable(
                name: "Bolnica");
        }
    }
}
