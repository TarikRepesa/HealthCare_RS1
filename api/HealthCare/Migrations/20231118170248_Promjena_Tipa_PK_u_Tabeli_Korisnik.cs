using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class PromjenaTipaPKuTabeliKorisnik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            /////////////////////////////////////////////////////////////////////////////////////////////
            ///

            migrationBuilder.DropUniqueConstraint("FK_Tehnicar_Osoblje_Id", "Tehnicar");
            migrationBuilder.DropUniqueConstraint("FK_Pacijent_Korisnik_Id", "Pacijent");
            migrationBuilder.DropUniqueConstraint("FK_Osoblje_Korisnik_Id", "Osoblje");
            migrationBuilder.DropUniqueConstraint("FK_Ljekar_Osoblje_Id", "Ljekar");
            migrationBuilder.DropUniqueConstraint("FK_Farmaceut_Osoblje_Id", "Farmaceut");
            migrationBuilder.DropUniqueConstraint("FK_Asistent_Osoblje_Id", "Asistent");

            migrationBuilder.DropUniqueConstraint("PK_Korisnik", "Korisnik");
            migrationBuilder.DropUniqueConstraint("PK_Tehnicar", "Tehnicar");
            migrationBuilder.DropUniqueConstraint("PK_Pacijent", "Pacijent");
            migrationBuilder.DropUniqueConstraint("PK_Osoblje", "Osoblje");
            migrationBuilder.DropUniqueConstraint("PK_Ljekar", "Ljekar");
            migrationBuilder.DropUniqueConstraint("PK_Farmaceut", "Farmaceut");
            migrationBuilder.DropUniqueConstraint("PK_Asistent", "Asistent");

            // Add new columns for string Id

            migrationBuilder.AddColumn<string>(
                name: "IdTemp_Korisnik",
                table: "Korisnik",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "IdTemp_Tehnicar",
                table: "Tehnicar",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "IdTemp_Pacijent",
                table: "Pacijent",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "IdTemp_Osoblje",
                table: "Osoblje",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "IdTemp_Ljekar",
                table: "Ljekar",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "IdTemp_Farmaceut",
                table: "Farmaceut",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "IdTemp_Asistent",
                table: "Asistent",
                type: "nvarchar(450)",
                nullable: false);

            // Update new columns with values from the old columns

            migrationBuilder.Sql("UPDATE Korisnik SET IdTemp_Korisnik = CONVERT(NVARCHAR(450), Id)");

            migrationBuilder.Sql("UPDATE Tehnicar SET IdTemp_Tehnicar = CONVERT(NVARCHAR(450), Id)");

            migrationBuilder.Sql("UPDATE Pacijent SET IdTemp_Pacijent = CONVERT(NVARCHAR(450), Id)");

            migrationBuilder.Sql("UPDATE Osoblje SET IdTemp_Osoblje = CONVERT(NVARCHAR(450), Id)");

            migrationBuilder.Sql("UPDATE Ljekar SET IdTemp_Ljekar = CONVERT(NVARCHAR(450), Id)");

            migrationBuilder.Sql("UPDATE Farmaceut SET IdTemp_Farmaceut = CONVERT(NVARCHAR(450), Id)");

            migrationBuilder.Sql("UPDATE Asistent SET IdTemp_Asistent = CONVERT(NVARCHAR(450), Id)");

            // Drop the old columns

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tehnicar");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pacijent");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Osoblje");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ljekar");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Farmaceut");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Asistent");


            // Rename the new columns to the original column names

            migrationBuilder.RenameColumn(
                name: "IdTemp_Korisnik",
                table: "Korisnik",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTemp_Tehnicar",
                table: "Tehnicar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTemp_Pacijent",
                table: "Pacijent",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTemp_Osoblje",
                table: "Osoblje",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTemp_Ljekar",
                table: "Ljekar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTemp_Farmaceut",
                table: "Farmaceut",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTemp_Asistent",
                table: "Asistent",
                newName: "Id");

            // Add primary key constraints on the new columns

            migrationBuilder.Sql("ALTER TABLE Korisnik ADD CONSTRAINT PK_Korisnik PRIMARY KEY (Id)");
            migrationBuilder.Sql("ALTER TABLE Tehnicar ADD CONSTRAINT PK_Tehnicar PRIMARY KEY (Id)");
            migrationBuilder.Sql("ALTER TABLE Pacijent ADD CONSTRAINT PK_Pacijent PRIMARY KEY (Id)");
            migrationBuilder.Sql("ALTER TABLE Osoblje ADD CONSTRAINT PK_Osoblje PRIMARY KEY (Id)");
            migrationBuilder.Sql("ALTER TABLE Ljekar ADD CONSTRAINT PK_Ljekar PRIMARY KEY (Id)");
            migrationBuilder.Sql("ALTER TABLE Farmaceut ADD CONSTRAINT PK_Farmaceut PRIMARY KEY (Id)");
            migrationBuilder.Sql("ALTER TABLE Asistent ADD CONSTRAINT PK_Asistent PRIMARY KEY (Id)");

            // Add back foreign key constraints if any
            migrationBuilder.Sql("ALTER TABLE Pacijent ADD CONSTRAINT FK_Pacijent_Korisnik_Id FOREIGN KEY (Id) REFERENCES Korisnik(Id)");

            migrationBuilder.Sql("ALTER TABLE Osoblje ADD CONSTRAINT FK_Osoblje_Korisnik_Id FOREIGN KEY (Id) REFERENCES Korisnik(Id)");

            migrationBuilder.Sql("ALTER TABLE Tehnicar ADD CONSTRAINT FK_Tehnicar_Osoblje_Id FOREIGN KEY (Id) REFERENCES Osoblje(Id)");

            migrationBuilder.Sql("ALTER TABLE Ljekar ADD CONSTRAINT FK_Ljekar_Osoblje_Id FOREIGN KEY (Id) REFERENCES Osoblje(Id)");

            migrationBuilder.Sql("ALTER TABLE Farmaceut ADD CONSTRAINT FK_Farmaceut_Osoblje_Id FOREIGN KEY (Id) REFERENCES Osoblje(Id)");

            migrationBuilder.Sql("ALTER TABLE Asistent ADD CONSTRAINT FK_Asistent_Osoblje_Id FOREIGN KEY (Id) REFERENCES Osoblje(Id)");

            ///////////////////////////////////////////////////////////////////
            ///

            /*migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Tehnicar",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Pacijent",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Osoblje",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Odjeljenje",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Ljekar",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Vrsta",
                table: "Lijek",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Upozorenja",
                table: "Lijek",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nuspojave",
                table: "Lijek",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Lijek",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NacinUpotrebe",
                table: "Lijek",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Korisnik",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Farmaceut",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Asistent",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "ZdravstvenaLegitimacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LjekarId",
                table: "Uputnica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "Uputnica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LjekarId",
                table: "Termin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "Termin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tehnicar",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LjekarId",
                table: "Recept",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "Recept",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Pacijent",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Osoblje",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "OdjeljenjeId",
                table: "Osoblje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Odjeljenje",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "LjekarId",
                table: "Nalaz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "Nalaz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ljekar",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Vrsta",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Upozorenja",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Nuspojave",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "NacinUpotrebe",
                table: "Lijek",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Korisnik",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "Karton",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Farmaceut",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ApotekaId",
                table: "Farmaceut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Asistent",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Karton_Pacijent_PacijentId",
                table: "Karton",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nalaz_Ljekar_LjekarId",
                table: "Nalaz",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nalaz_Pacijent_PacijentId",
                table: "Nalaz",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Osoblje_Odjeljenje_OdjeljenjeId",
                table: "Osoblje",
                column: "OdjeljenjeId",
                principalTable: "Odjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recept_Ljekar_LjekarId",
                table: "Recept",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recept_Pacijent_PacijentId",
                table: "Recept",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Ljekar_LjekarId",
                table: "Termin",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Pacijent_PacijentId",
                table: "Termin",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uputnica_Ljekar_LjekarId",
                table: "Uputnica",
                column: "LjekarId",
                principalTable: "Ljekar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uputnica_Pacijent_PacijentId",
                table: "Uputnica",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZdravstvenaLegitimacija_Pacijent_PacijentId",
                table: "ZdravstvenaLegitimacija",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
