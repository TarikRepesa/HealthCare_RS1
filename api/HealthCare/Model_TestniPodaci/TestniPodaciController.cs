using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Model_TestniPodaci
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestniPodaciController : ControllerBase
    {
        private const string DefaultUserPassword = "Pass123$";
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Count()
        {
            Dictionary<string, int> data = new();

            data.Add("Ambulanta", _dbContext.Ambulanta.Count());
            data.Add("Apoteka", _dbContext.Apoteka.Count());
            data.Add("Asistent", _dbContext.Asistent.Count());
            data.Add("Bolnica", _dbContext.Bolnica.Count());
            data.Add("Farmaceut", _dbContext.Farmaceut.Count());
            data.Add("Karton", _dbContext.Karton.Count());
            data.Add("Korisnik", _dbContext.Korisnik.Count());
            data.Add("Lijek", _dbContext.Lijek.Count());
            data.Add("Lokacija", _dbContext.Lokacija.Count());
            data.Add("Ljekar", _dbContext.Ljekar.Count());
            data.Add("Menadzment", _dbContext.Menadzment.Count());
            data.Add("Nalaz", _dbContext.Nalaz.Count());
            data.Add("Odjeljenje", _dbContext.Odjeljenje.Count());
            data.Add("Odsjek", _dbContext.Odsjek.Count());
            data.Add("Osoblje", _dbContext.Osoblje.Count());
            data.Add("Pacijent", _dbContext.Pacijent.Count());
            data.Add("Proizvodac", _dbContext.Proizvodjac.Count());
            data.Add("Recept", _dbContext.Recept.Count());
            data.Add("SifraBolesti", _dbContext.SifraBolesti.Count());
            data.Add("Tehnicar", _dbContext.Tehnicar.Count());
            data.Add("Termin", _dbContext.Termin.Count());
            data.Add("Uloga", _dbContext.Uloga.Count());
            data.Add("Uputnica", _dbContext.Uputnica.Count());
            data.Add("ZdravstvenaLegitimacija", _dbContext.ZdravstvenaLegitimacija.Count());

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            if (_dbContext.Korisnik.Any())
            {
                return Count();
            }

            var uloga = new List<Uloga>();
            var bolnica = new List<Bolnica>();
            var lokacija = new List<Lokacija>();
            var ambulanta = new List<Ambulanta>();
            var apoteka = new List<Apoteka>();
            var menadzment = new List<Menadzment>();
            var odjeljenje = new List<Odjeljenje>();
            var odsjek = new List<Odsjek>();
            var asistent = new List<Asistent>();
            var ljekar = new List<Ljekar>();
            var tehnicar = new List<Tehnicar>();
            var farmaceut = new List<Farmaceut>();
            var pacijent = new List<Pacijent>();
            var recept = new List<Recept>();
            var karton = new List<Karton>();
            var zdravstvenaLegitimacija = new List<ZdravstvenaLegitimacija>();
            var nalaz = new List<Nalaz>();
            var uputnica = new List<Uputnica>();
            var proizvodjac = new List<Proizvodjac>();
            var lijek = new List<Lijek>();
            var termin = new List<Termin>();
            var sifraBolesti = new List<SifraBolesti>();
            var korisnik = new List<Korisnik>();

            uloga.Add(new Uloga { Naziv = "Admin" });
            uloga.Add(new Uloga { Naziv = "Ljekar" });
            uloga.Add(new Uloga { Naziv = "Pacijent" });
            uloga.Add(new Uloga { Naziv = "Tehnicar" });
            uloga.Add(new Uloga { Naziv = "Farmaceut" });
            uloga.Add(new Uloga { Naziv = "Asistent" });

            _dbContext.AddRange(uloga);
            _dbContext.SaveChanges();

            bolnica.Add(new Bolnica { Naziv = "Klinicki centar", Telefon = "061/000-112", Email = "klinicki_centar@gmail.com" });
            bolnica.Add(new Bolnica { Naziv = "Specijalizovana bolnica", Telefon = "060/113-322", Email = "specijalizovana_bolnica@gmail.com" });
            bolnica.Add(new Bolnica { Naziv = "Plućna bolnica", Telefon = "062/221-211", Email = "plucna@gmail.com" });

            lokacija.Add(new Lokacija { Grad = "Sarajevo", Opstina = "Novi Grad", Ulica = "ulica 22", Bolnica = bolnica[0] });
            lokacija.Add(new Lokacija { Grad = "Sarajevo", Opstina = "Sarajevo", Ulica = "ulica 12", Bolnica = bolnica[1] });
            lokacija.Add(new Lokacija { Grad = "Mostar", Opstina = "Mostar", Ulica = "ulica 15", Bolnica = bolnica[2] });

            ambulanta.Add(new Ambulanta { Naziv = "Opca", Telefon = "031/111-222", Email = "opca@gmail.com", Vrsta = "Opca Ambulanta", Bolnica = bolnica[0] });
            ambulanta.Add(new Ambulanta { Naziv = "Labaratorijska", Telefon = "031/111-221", Email = "labaratorija@gmail.com", Vrsta = "Labaratorijska Ambulanta", Bolnica = bolnica[0] });
            ambulanta.Add(new Ambulanta { Naziv = "Raioloska", Telefon = "031/111-223", Email = "raiologijaa@gmail.com", Vrsta = "Raioloska Ambulanta", Bolnica = bolnica[0] });
            ambulanta.Add(new Ambulanta { Naziv = "Fizikalna terapija", Telefon = "031/111-224", Email = "fizikalna_terapija@gmail.com", Vrsta = "Fizikalna terapija Ambulanta", Bolnica = bolnica[0] });
            ambulanta.Add(new Ambulanta { Naziv = "Endokrinoloska ", Telefon = "031/111-225", Email = "endokrinologija@gmail.com", Vrsta = "Endokrinoloska Ambulanta", Bolnica = bolnica[0] });

            apoteka.Add(new Apoteka { Vrsta = "Ljekarna 'Zdravlje'", Telefon = "030/881-112", Email = "ljekarna_zdravlje@gmail.com", Bolnica = bolnica[0] });
            apoteka.Add(new Apoteka { Vrsta = "Apoteka 'Farmacia Vita'", Telefon = "030/881-113", Email = "farmaciaVita@gmail.com", Bolnica = bolnica[1] });
            apoteka.Add(new Apoteka { Vrsta = "Ljekarna 'MediLine'", Telefon = "030/881-113", Email = "mediLine@gmail.com", Bolnica = bolnica[2] });

            odjeljenje.Add(new Odjeljenje { Naziv = "Hirurgija", Vrsta = "Odjel-hirurgije", Bolnica = bolnica[0] });
            odjeljenje.Add(new Odjeljenje { Naziv = "Pedijatrija", Vrsta = "Odjel-pedijatrija", Bolnica = bolnica[1] });
            odjeljenje.Add(new Odjeljenje { Naziv = "Radiologija", Vrsta = "Odjel-radiologije", Bolnica = bolnica[2] });

            odsjek.Add(new Odsjek { Naziv = "Opšta hirurgija", Odjeljenje = odjeljenje[0] });
            odsjek.Add(new Odsjek { Naziv = "Ortopedska hirurgija", Odjeljenje = odjeljenje[0] });
            odsjek.Add(new Odsjek { Naziv = "Vaskularna hirurgija", Odjeljenje = odjeljenje[0] });

            odsjek.Add(new Odsjek { Naziv = "Neonatologija", Odjeljenje = odjeljenje[1] });
            odsjek.Add(new Odsjek { Naziv = "Pedijatrijska pulmologija", Odjeljenje = odjeljenje[1] });
            odsjek.Add(new Odsjek { Naziv = "Pedijatrijska hematologija-onkologija", Odjeljenje = odjeljenje[1] });

            odsjek.Add(new Odsjek { Naziv = "Dijagnostička radiologija", Odjeljenje = odjeljenje[2] });
            odsjek.Add(new Odsjek { Naziv = "Interventna radiologija", Odjeljenje = odjeljenje[2] });
            odsjek.Add(new Odsjek { Naziv = "Nuklearna medicina", Odjeljenje = odjeljenje[2] });

            sifraBolesti.Add(new SifraBolesti { Sifra = "SB001", Naziv = "Bolest #1" });
            sifraBolesti.Add(new SifraBolesti { Sifra = "SB002", Naziv = "Bolest #2" });
            sifraBolesti.Add(new SifraBolesti { Sifra = "SB003", Naziv = "Bolest #3" });

            menadzment.Add(new Menadzment { Ime = "Marco", Prezime = "Eggers", Uloga = "Izvrsni direktor", Email = "marco.eggers@gmail.com", Telefon = "+38762/113-444", Bolnica = bolnica[0] });
            menadzment.Add(new Menadzment { Ime = "David", Prezime = "Vogel", Uloga = "Upravitelj kvalitete", Email = "david.vogel@gmail.com", Telefon = "+38762/113-412", Bolnica = bolnica[0] });

            menadzment.Add(new Menadzment { Ime = "Tom", Prezime = "Werner", Uloga = "Izvrsni direktor", Email = "tom.werner@gmail.com", Telefon = "+38761/113-144", Bolnica = bolnica[1] });
            menadzment.Add(new Menadzment { Ime = "Philipp", Prezime = "Baader", Uloga = "Upravitelj kvalitete", Email = "philipp.baader@gmail.com", Telefon = "+38762/113-422", Bolnica = bolnica[1] });

            menadzment.Add(new Menadzment { Ime = "Peter", Prezime = "Frey", Uloga = "Izvrsni direktor", Email = "peter.frey@gmail.com", Telefon = "+38761/113-231", Bolnica = bolnica[2] });
            menadzment.Add(new Menadzment { Ime = "Benjamin", Prezime = "Baecker", Uloga = "Upravitelj kvalitete", Email = "benjamin.baecker@gmail.com", Telefon = "+38762/113-124", Bolnica = bolnica[2] });

            asistent.Add(new Asistent { Id = Generator.GenerateStringId(), KorisnickoIme = "emma", Email = "emma@gmail.com", Password = DefaultUserPassword, Ime = "Emma", Prezime = "Johnson", BrojTelefona = "061/111-001", GodineIskustva = 2, Odjeljenje = odjeljenje[0], Specijalizacija = "Medicinska sestra", Kvalifikacija = "Strucna osposobljavanja i prakse" });
            asistent.Add(new Asistent { Id = Generator.GenerateStringId(), KorisnickoIme = "liam", Email = "liam@gmail.com", Password = DefaultUserPassword, Ime = "Liam", Prezime = "Anderson", BrojTelefona = "061/111-002", GodineIskustva = 5, Odjeljenje = odjeljenje[0], Specijalizacija = "Tehnicar anesteziologije", Kvalifikacija = "Certifikat/licenca" });
            asistent.Add(new Asistent { Id = Generator.GenerateStringId(), KorisnickoIme = "olivia", Email = "olivia@gmail.com", Password = DefaultUserPassword, Ime = "Olivia", Prezime = "Martinez", BrojTelefona = "061/111-003", GodineIskustva = 2, Odjeljenje = odjeljenje[0], Specijalizacija = "Medicinska sestra", Kvalifikacija = "Strucna osposobljavanja i prakse" });
            asistent.Add(new Asistent { Id = Generator.GenerateStringId(), KorisnickoIme = "isabella", Email = "isabella@gmail.com", Password = DefaultUserPassword, Ime = "Isabella", Prezime = "Smith", BrojTelefona = "061/111-004", GodineIskustva = 4, Odjeljenje = odjeljenje[0], Specijalizacija = "Medicinska sestra", Kvalifikacija = "Strucna osposobljavanja i prakse" });
            asistent.Add(new Asistent { Id = Generator.GenerateStringId(), KorisnickoIme = "sophia", Email = "sophia@gmail.com", Password = DefaultUserPassword, Ime = "Sophia", Prezime = "Rodriguez", BrojTelefona = "061/111-005", GodineIskustva = 6, Odjeljenje = odjeljenje[0], Specijalizacija = "Tehnicar rehabilitacije", Kvalifikacija = "Certifikat/licenca" });
            asistent.Add(new Asistent { Id = Generator.GenerateStringId(), KorisnickoIme = "amelia", Email = "amelia@gmail.com", Password = DefaultUserPassword, Ime = "Amelia", Prezime = "Harris", BrojTelefona = "061/111-006", GodineIskustva = 3, Odjeljenje = odjeljenje[0], Specijalizacija = "Tehnicar rehabilitacije", Kvalifikacija = "Certifikat/licenca" });

            ljekar.Add(new Ljekar { Id = Generator.GenerateStringId(), KorisnickoIme = "tom", Email = "tom@gmail.com", Password = DefaultUserPassword, Ime = "Tom", Prezime = "Schultz", BrojTelefona = "062/111-111", GodineIskustva = 13, Odjeljenje = odjeljenje[0], Sifra = "0001121", Specjalizacija = "Kardiolog", Specifikacija = "Certifikat/licenca" });
            ljekar.Add(new Ljekar { Id = Generator.GenerateStringId(), KorisnickoIme = "mario", Email = "mario@gmail.com", Password = DefaultUserPassword, Ime = "Mario", Prezime = "Scholz", BrojTelefona = "062/111-113", GodineIskustva = 10, Odjeljenje = odjeljenje[0], Sifra = "0001122", Specjalizacija = "Hirurg", Specifikacija = "Certifikat/licenca" });
            ljekar.Add(new Ljekar { Id = Generator.GenerateStringId(), KorisnickoIme = "mathias", Email = "mathias@gmail.com", Password = DefaultUserPassword, Ime = "Mathias", Prezime = "Muller", BrojTelefona = "062/111-113", GodineIskustva = 15, Odjeljenje = odjeljenje[0], Sifra = "0001123", Specjalizacija = "Ortoped", Specifikacija = "Certifikat/licenca" });
            ljekar.Add(new Ljekar { Id = Generator.GenerateStringId(), KorisnickoIme = "patrick", Email = "patrick@gmail.com", Password = DefaultUserPassword, Ime = "Patrick", Prezime = "Harris", BrojTelefona = "062/111-114", GodineIskustva = 20, Odjeljenje = odjeljenje[0], Sifra = "0001124", Specjalizacija = "Hirurg", Specifikacija = "Certifikat/licenca" });
            ljekar.Add(new Ljekar { Id = Generator.GenerateStringId(), KorisnickoIme = "dominik", Email = "dominik@gmail.com", Password = DefaultUserPassword, Ime = "Dominik", Prezime = "Ebersbacher", BrojTelefona = "062/111-115", GodineIskustva = 5, Odjeljenje = odjeljenje[0], Sifra = "0001125", Specjalizacija = "Psihijatar", Specifikacija = "Certifikat/licenca" });
            ljekar.Add(new Ljekar { Id = Generator.GenerateStringId(), KorisnickoIme = "kristian", Email = "kristian@gmail.com", Password = DefaultUserPassword, Ime = "Kristian", Prezime = "Bergmann", BrojTelefona = "062/111-116", GodineIskustva = 7, Odjeljenje = odjeljenje[0], Sifra = "0001126", Specjalizacija = "Dermatolog", Specifikacija = "Certifikat/licenca" });

            tehnicar.Add(new Tehnicar { Id = Generator.GenerateStringId(), KorisnickoIme = "frank", Email = "frank_scholz@gmail.com", Password = DefaultUserPassword, Ime = "Frank", Prezime = "Scholz", BrojTelefona = "063/111-111", GodineIskustva = 7, Odjeljenje = odjeljenje[0], Specijalizacija = "Labaratorija", Kvalifikacija = "Certifikat/licenca" });
            tehnicar.Add(new Tehnicar { Id = Generator.GenerateStringId(), KorisnickoIme = "luca", Email = "luca_herzog@gmail.com", Password = DefaultUserPassword, Ime = "Luca", Prezime = "Herzog", BrojTelefona = "063/111-121", GodineIskustva = 10, Odjeljenje = odjeljenje[0], Specijalizacija = "EKG", Kvalifikacija = "Certifikat/licenca" });
            tehnicar.Add(new Tehnicar { Id = Generator.GenerateStringId(), KorisnickoIme = "janw", Email = "jan_weiss@gmail.com", Password = DefaultUserPassword, Ime = "Jan", Prezime = "Weiß", BrojTelefona = "063/111-136", GodineIskustva = 10, Odjeljenje = odjeljenje[0], Specijalizacija = "Radiolog", Kvalifikacija = "Certifikat/licenca" });
            tehnicar.Add(new Tehnicar { Id = Generator.GenerateStringId(), KorisnickoIme = "janb", Email = "jan_beyer@gmail.com", Password = DefaultUserPassword, Ime = "Jan", Prezime = "Beyer", BrojTelefona = "063/111-137", GodineIskustva = 5, Odjeljenje = odjeljenje[0], Specijalizacija = "Labaratorija", Kvalifikacija = "Certifikat/licenca" });

            farmaceut.Add(new Farmaceut { Id = Generator.GenerateStringId(), KorisnickoIme = "martina", Email = "martina@gmail.com", Password = DefaultUserPassword, Ime = "Martina", Prezime = "Reinhard", BrojTelefona = "064/441-136", GodineIskustva = 10, Odjeljenje = odjeljenje[0], Radnik = "Farmaceut", Apoteka = apoteka[0] });
            farmaceut.Add(new Farmaceut { Id = Generator.GenerateStringId(), KorisnickoIme = "robert", Email = "robert@gmail.com", Password = DefaultUserPassword, Ime = "Robert", Prezime = "Gerste", BrojTelefona = "064/442-136", GodineIskustva = 3, Odjeljenje = odjeljenje[0], Radnik = "Farmaceut", Apoteka = apoteka[0] });
            farmaceut.Add(new Farmaceut { Id = Generator.GenerateStringId(), KorisnickoIme = "thomas", Email = "thomas@gmail.com", Password = DefaultUserPassword, Ime = "Thomas", Prezime = "Schroder", BrojTelefona = "064/443-136", GodineIskustva = 15, Odjeljenje = odjeljenje[0], Radnik = "Farmaceut", Apoteka = apoteka[1] });
            farmaceut.Add(new Farmaceut { Id = Generator.GenerateStringId(), KorisnickoIme = "christina", Email = "christina@gmail.com", Password = DefaultUserPassword, Ime = "Christina", Prezime = "Ackermann", BrojTelefona = "064/444-126", GodineIskustva = 8, Odjeljenje = odjeljenje[0], Radnik = "Farmaceut", Apoteka = apoteka[2] });

            korisnik.Add(new Korisnik { Id = Generator.GenerateStringId(), KorisnickoIme = "admin", Email = "admin@test.com", Password = DefaultUserPassword, Ime = "Admin", Prezime = "Test", BrojTelefona = "064/444-126" });
            tehnicar.Add(new Tehnicar { Id = Generator.GenerateStringId(), KorisnickoIme = "tehnicar", Email = "tehnicar@test.com", Password = DefaultUserPassword, Ime = "Tehnicar", Prezime = "Test", BrojTelefona = "063/111-111", GodineIskustva = 7, Odjeljenje = odjeljenje[0], Specijalizacija = "Labaratorija", Kvalifikacija = "Certifikat/licenca" });
            ljekar.Add(new Ljekar { Id = Generator.GenerateStringId(), KorisnickoIme = "ljekar", Email = "ljekar@test.com", Password = DefaultUserPassword, Ime = "Ljekar", Prezime = "Test", BrojTelefona = "062/111-115", GodineIskustva = 5, Odjeljenje = odjeljenje[0], Sifra = "0001125", Specjalizacija = "Psihijatar", Specifikacija = "Certifikat/licenca" });
            farmaceut.Add(new Farmaceut { Id = Generator.GenerateStringId(), KorisnickoIme = "farmaceut", Email = "farmaceut@test.com", Password = DefaultUserPassword, Ime = "Martina", Prezime = "Test", BrojTelefona = "064/441-136", GodineIskustva = 10, Odjeljenje = odjeljenje[0], Radnik = "Farmaceut", Apoteka = apoteka[0] });
            asistent.Add(new Asistent { Id = Generator.GenerateStringId(), KorisnickoIme = "asistent", Email = "asistent@test.com", Password = DefaultUserPassword, Ime = "Emma", Prezime = "Test", BrojTelefona = "061/111-001", GodineIskustva = 2, Odjeljenje = odjeljenje[0], Specijalizacija = "Medicinska sestra", Kvalifikacija = "Strucna osposobljavanja i prakse" });
            pacijent.Add(new Pacijent
            {
                Id = Generator.GenerateStringId(),
                KorisnickoIme = "pacijent",
                Email = "pacijent@test.com",
                Password = DefaultUserPassword,
                Ime = "Pacijent",
                Prezime = "Test",
                BrojTelefona = $"064/111-002",
                DatumRodenja = DateTime.Now,
                MjestoRodenja = "Test",
            });

            for (int i = 0; i < 20; i++)
            {
                var newPacijent = new Pacijent
                {
                    Id = Generator.GenerateStringId(),
                    KorisnickoIme = Generator.GenerisiKorisnickoIme(6),
                    Email = Generator.GenerisiKorisnickoIme(10) + "@gmail.com",
                    Password = DefaultUserPassword,
                    Ime = Generator.GenerateRandomName(),
                    Prezime = Generator.GenerateRandomSurname(),
                    BrojTelefona = $"064/4412-00{i}",
                    DatumRodenja = DateTime.Now,
                    MjestoRodenja = Generator.GenerateRandomPlaceOfBirth(),
                };
                pacijent.Add(newPacijent);
            }

            foreach (var user in korisnik)
            {
                AssignRoleToUser(user, "Admin");
            }

            foreach (var user in asistent)
            {
                AssignRoleToUser(user, "Asistent");
            }

            foreach (var user in ljekar)
            {
                AssignRoleToUser(user, "Ljekar");
            }

            foreach (var user in tehnicar)
            {
                AssignRoleToUser(user, "Tehnicar");
            }

            foreach (var user in farmaceut)
            {
                AssignRoleToUser(user, "Farmaceut");
            }

            foreach (var user in pacijent)
            {
                AssignRoleToUser(user, "Pacijent");


                zdravstvenaLegitimacija.Add(new ZdravstvenaLegitimacija
                {
                    JMBG = Generator.GenerateJMBG(),
                    DatumIzdavanja = DateTime.Now,
                    DopunskoOsiguranje = Generator.GenerateDopunskoOsiguranje(),
                    SrodstvoOsiguranika = "Osiguranik",
                    Pacijent = user
                });

                karton.Add(new Karton
                {
                    Sifra = Generator.GenerateSifra(),
                    Pacijent = user
                });
            }

            recept.Add(new Recept { DatumIzdavanja = DateTime.Now, Doza = "50 mg", Napomena = "Uzimati svakih 6 sati.", SifraBolesti = "A123.2", Pacijent = pacijent[0], Ljekar = ljekar[0] });
            recept.Add(new Recept { DatumIzdavanja = DateTime.Now, Doza = "500 mg", Napomena = "Uzimati jednom dnevno.", SifraBolesti = "B321.5", Pacijent = pacijent[0], Ljekar = ljekar[0] });
            recept.Add(new Recept { DatumIzdavanja = DateTime.Now, Doza = "100 mg", Napomena = "Uzimati 3x dnevno.", SifraBolesti = "F324.7", Pacijent = pacijent[0], Ljekar = ljekar[0] });
            recept.Add(new Recept { DatumIzdavanja = DateTime.Now, Doza = "50 mg", Napomena = "Uzimati svakih 6 sati.", SifraBolesti = "A123.2", Pacijent = pacijent[0], Ljekar = ljekar[1] });
            recept.Add(new Recept { DatumIzdavanja = DateTime.Now, Doza = "500 mg", Napomena = "Uzimati jednom dnevno.", SifraBolesti = "B321.5", Pacijent = pacijent[0], Ljekar = ljekar[2] });
            recept.Add(new Recept { DatumIzdavanja = DateTime.Now, Doza = "50 mg", Napomena = "Uzimati svakih 6 sati.", SifraBolesti = "A123.2", Pacijent = pacijent[0], Ljekar = ljekar[1] });
            recept.Add(new Recept { DatumIzdavanja = DateTime.Now, Doza = "100 mg", Napomena = "Uzimati 3x dnevno.", SifraBolesti = "F324.7", Pacijent = pacijent[0], Ljekar = ljekar[3] });

            nalaz.Add(new Nalaz { Vrsta = "Krvni", Prioritet = "Hitni", Pacijent = pacijent[0], Ljekar = ljekar[0] });
            nalaz.Add(new Nalaz { Vrsta = "Urinarni", Prioritet = "Dijagnoza/lijecenje", Pacijent = pacijent[0], Ljekar = ljekar[0] });
            nalaz.Add(new Nalaz { Vrsta = "Kardiološki", Prioritet = "Dijagnoza/lijecenje", Pacijent = pacijent[0], Ljekar = ljekar[0] });
            nalaz.Add(new Nalaz { Vrsta = "Krvni", Prioritet = "Hitni", Pacijent = pacijent[1], Ljekar = ljekar[2] });
            nalaz.Add(new Nalaz { Vrsta = "Krvni", Prioritet = "Hitni", Pacijent = pacijent[2], Ljekar = ljekar[3] });
            nalaz.Add(new Nalaz { Vrsta = "Kardiološki", Prioritet = "Dijagnoza/lijecenje", Pacijent = pacijent[3], Ljekar = ljekar[1] });
            nalaz.Add(new Nalaz { Vrsta = "Urinarni", Prioritet = "Dijagnoza/lijecenje", Pacijent = pacijent[4], Ljekar = ljekar[4] });
            nalaz.Add(new Nalaz { Vrsta = "Krvni", Prioritet = "Hitni", Pacijent = pacijent[5], Ljekar = ljekar[5] });
            nalaz.Add(new Nalaz { Vrsta = "Kardiološki", Prioritet = "Dijagnoza/lijecenje", Pacijent = pacijent[5], Ljekar = ljekar[1] });
            nalaz.Add(new Nalaz { Vrsta = "Krvni", Prioritet = "Hitni", Pacijent = pacijent[10], Ljekar = ljekar[0] });

            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[0], Odsjek = odsjek[0], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[0], Ljekar = ljekar[0], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[0] }, new() { SifraBolesti = sifraBolesti[1] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[0], Odsjek = odsjek[1], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[0], Ljekar = ljekar[0], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[1] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[0], Odsjek = odsjek[2], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[0], Ljekar = ljekar[0], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[0] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[1], Odsjek = odsjek[3], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[1], Ljekar = ljekar[2], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[1] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[1], Odsjek = odsjek[4], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[2], Ljekar = ljekar[3], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[1] }, new() { SifraBolesti = sifraBolesti[0] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[1], Odsjek = odsjek[5], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[3], Ljekar = ljekar[1], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[0] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[2], Odsjek = odsjek[6], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[4], Ljekar = ljekar[4], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[0] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[2], Odsjek = odsjek[7], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[5], Ljekar = ljekar[5], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[1] }, new() { SifraBolesti = sifraBolesti[0] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[2], Odsjek = odsjek[8], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[5], Ljekar = ljekar[1], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[1] }, new() { SifraBolesti = sifraBolesti[0] } } });
            uputnica.Add(new Uputnica { Odjeljenje = odjeljenje[2], Odsjek = odsjek[8], Dijagnoza = "Lijecenje", Primjedba = "Nema primjedbi!", DatumIzdavanja = DateTime.Now, DatumVazenja = DateTime.Now.AddMonths(2), Pacijent = pacijent[10], Ljekar = ljekar[0], UputnicaSifraBolesti = new List<UputnicaSifraBolesti> { new() { SifraBolesti = sifraBolesti[0] } } });

            proizvodjac.Add(new Proizvodjac { Naziv = "Novartis", Telefon = "000/111-222", Email = "novartis@gmail.com" });
            proizvodjac.Add(new Proizvodjac { Naziv = "Roche", Telefon = "000/111-333", Email = "roche@gmail.com" });
            proizvodjac.Add(new Proizvodjac { Naziv = "Sanofi", Telefon = "000/111-444", Email = "sanofi@gmail.com" });


            lijek.Add(new Lijek { Naziv = "Antibiotik", Vrsta = "Lijek", KolicinaNaStanju = 50, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 10, Proizvodjac = proizvodjac[0], Apoteka = apoteka[0] });
            lijek.Add(new Lijek { Naziv = "Analgetik", Vrsta = "Lijek", KolicinaNaStanju = 50, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 20, Proizvodjac = proizvodjac[0], Apoteka = apoteka[0] });
            lijek.Add(new Lijek { Naziv = "Beta blokator", Vrsta = "Lijek", KolicinaNaStanju = 50, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 50, Proizvodjac = proizvodjac[1], Apoteka = apoteka[0] });
            lijek.Add(new Lijek { Naziv = "Analgin", Vrsta = "Tableta", KolicinaNaStanju = 80, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 30, Proizvodjac = proizvodjac[0], Apoteka = apoteka[0] });
            lijek.Add(new Lijek { Naziv = "Caffetin", Vrsta = "Tableta", KolicinaNaStanju = 100, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 60, Proizvodjac = proizvodjac[2], Apoteka = apoteka[0] });


            lijek.Add(new Lijek { Naziv = "Antibiotik", Vrsta = "Lijek", KolicinaNaStanju = 50, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 9.50, Proizvodjac = proizvodjac[0], Apoteka = apoteka[1] });
            lijek.Add(new Lijek { Naziv = "Analgetik", Vrsta = "Lijek", KolicinaNaStanju = 50, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 21, Proizvodjac = proizvodjac[0], Apoteka = apoteka[1] });
            lijek.Add(new Lijek { Naziv = "Beta blokator", Vrsta = "Lijek", KolicinaNaStanju = 50, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 48.50, Proizvodjac = proizvodjac[1], Apoteka = apoteka[1] });
            lijek.Add(new Lijek { Naziv = "Analgin", Vrsta = "Tableta", KolicinaNaStanju = 80, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 30, Proizvodjac = proizvodjac[0], Apoteka = apoteka[1] });
            lijek.Add(new Lijek { Naziv = "Caffetin", Vrsta = "Tableta", KolicinaNaStanju = 100, NacinUpotrebe = "Upotreba", Nuspojave = "Nema", Upozorenja = "---", Cijena = 60, Proizvodjac = proizvodjac[2], Apoteka = apoteka[1] });

            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[0], Ambulanta = ambulanta[0], Ljekar = ljekar[0] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[1], Ambulanta = ambulanta[1], Ljekar = ljekar[0] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[2], Ambulanta = ambulanta[0], Ljekar = ljekar[1] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[3], Ambulanta = ambulanta[3], Ljekar = ljekar[1] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[4], Ambulanta = ambulanta[4], Ljekar = ljekar[2] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[5], Ambulanta = ambulanta[2], Ljekar = ljekar[2] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[6], Ambulanta = ambulanta[0], Ljekar = ljekar[0] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[7], Ambulanta = ambulanta[1], Ljekar = ljekar[4] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[8], Ambulanta = ambulanta[0], Ljekar = ljekar[3] });
            termin.Add(new Termin { VrijemeOd = DateTime.Now, Vrsta = "Termin za pregled", Prioritet = "Pregled", Pacijent = pacijent[9], Ambulanta = ambulanta[3], Ljekar = ljekar[3] });


            _dbContext.AddRange(bolnica);
            _dbContext.AddRange(lokacija);
            _dbContext.AddRange(ambulanta);
            _dbContext.AddRange(apoteka);
            _dbContext.AddRange(odjeljenje);
            _dbContext.AddRange(odsjek);
            _dbContext.AddRange(sifraBolesti);
            _dbContext.AddRange(korisnik);
            _dbContext.AddRange(menadzment);
            _dbContext.AddRange(asistent);
            _dbContext.AddRange(ljekar);
            _dbContext.AddRange(tehnicar);
            _dbContext.AddRange(farmaceut);
            _dbContext.AddRange(recept);
            _dbContext.AddRange(pacijent);
            _dbContext.AddRange(karton);
            _dbContext.AddRange(zdravstvenaLegitimacija);
            _dbContext.AddRange(nalaz);
            _dbContext.AddRange(uputnica);
            _dbContext.AddRange(proizvodjac);
            _dbContext.AddRange(lijek);
            _dbContext.AddRange(termin);

            _dbContext.SaveChanges();

            return Count();
        }

        private void AssignRoleToUser(Korisnik user, string roleName)
        {
            var uloga = _dbContext.Uloga.FirstOrDefault(x => x.Naziv == roleName);
            if (uloga == null)
            {
                throw new Exception($"Uloga {roleName} nije pronadjena u bazi.");
            }
            user.Uloge ??= new List<Uloga>();
            user.Uloge.Add(uloga);
        }
    }

}
