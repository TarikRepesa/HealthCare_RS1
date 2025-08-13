using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Helper.Auth;
using HealthCare.Models;
using HealthCare.ViewModels.Osoblje;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OsobljeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public OsobljeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Get(string id)
        {
            return Ok(_dbContext.Osoblje.FirstOrDefault(m => m.Id == id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _dbContext.Osoblje.OrderBy(s => s.Id).Select(s => new Osoblje()
                {
                    Id = s.Id,
                    GodineIskustva = s.GodineIskustva
                    // OdjeljenjeId
                    // Slika
                    // Enable2FA
                }).AsQueryable();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetByOdjeljenje(int id)
        {
            try
            {
                var data = _dbContext.Osoblje.Where(m => m.OdjeljenjeId == id).Select(s => new OsobljePrikazVM()
                {
                    Id = s.Id,
                    GodineIskustva = s.GodineIskustva,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    BrojTelefona = s.BrojTelefona,
                    Email = s.Email
                    // OdjeljenjeId
                    // Slika
                    // Enable2FA
                }).AsQueryable();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}")]
        [Autorizacija(admin: true)]
        public ActionResult Update(string id, [FromBody] OsobljeEditVM o)
        {
            Osoblje osoblje = _dbContext.Osoblje.FirstOrDefault(l => l.Id == id);

            if (osoblje == null)
                return BadRequest("Osoba ne postoji");

            osoblje.Ime = o.Ime;
            osoblje.Prezime = o.Prezime;
            osoblje.GodineIskustva = o.GodineIskustva;
            osoblje.BrojTelefona = o.BrojTelefona;
            osoblje.Email = o.Email;
            // OdjeljenjeId
            // Slika
            // Password
            // Enable2FA

            _dbContext.SaveChanges();
            return Ok(o);
        }

        [HttpPost]
        [Autorizacija(admin: true)]
        public ActionResult Add([FromBody] OsobljeAddVM request)
        {
            var osobljeEmail = _dbContext.Osoblje.Where(x => x.Email == request.Email).FirstOrDefault();
            if (osobljeEmail != null)
                return BadRequest("Ta osoba vec postoji u bazi!");

            var osobljeImePrezime = _dbContext.Osoblje.Where(x => x.Ime == request.Ime && x.Prezime == request.Prezime).FirstOrDefault();
            if (osobljeImePrezime != null)
                return BadRequest("Ta osoba vec postoji u bazi!");

            var odjeljenje = _dbContext.Odjeljenje.Where(x => x.Id == request.OdjeljenjeId).FirstOrDefault();
            if (odjeljenje == null)
                return BadRequest("Odjeljenje nije pronađeno u bazi!");

            var uloga = _dbContext.Uloga.Where(x => x.Naziv == request.Uloga).FirstOrDefault();
            if (uloga == null)
                return BadRequest("Uloga nije pronađena u bazi!");
            
            if (request.ApotekaId != null)
            {
                var apoteka = _dbContext.Apoteka.Find(request.ApotekaId);
                if (apoteka == null)
                    return BadRequest("Apoteka nije pronađena u bazi!");
            }

            try
            {
                var password = TokenGenerator.GenerisiAlfanumerickiToken(8);
                byte[]? slika = null;
                if (!string.IsNullOrEmpty(request.Slika))
                {
                    slika = request.Slika.ParsirajBase64();
                    if (slika == null)
                    {
                        throw new Exception("Format slike nije base64!");
                    }
                }

                Osoblje newOsoblje;
                if (uloga.Naziv == nameof(Ljekar))
                    newOsoblje = new Ljekar()
                    {
                        Specjalizacija = request.Specijalizacija ?? string.Empty,
                        Specifikacija = request.Specifikacija ?? string.Empty,
                        Sifra = request.Sifra ?? string.Empty
                    };
                else if (uloga.Naziv == nameof(Asistent))
                    newOsoblje = new Asistent()
                    {
                        Specijalizacija = request.Specijalizacija ?? string.Empty,
                        Kvalifikacija = request.Kvalifikacija ?? string.Empty
                    };
                else if (uloga.Naziv == nameof(Tehnicar))
                    newOsoblje = new Tehnicar()
                    {
                        Specijalizacija = request.Specijalizacija ?? string.Empty,
                        Kvalifikacija = request.Kvalifikacija ?? string.Empty,
                    };
                else if (uloga.Naziv == nameof(Farmaceut))
                    newOsoblje = new Farmaceut()
                    {
                        Radnik = "Farmaceut",
                        ApotekaId = request.ApotekaId ?? throw new Exception("Apoteka je obavezno polje"),
                    };
                else
                    return BadRequest("Uloga nije dozvoljena.");

                newOsoblje.Id = Guid.NewGuid().ToString();
                newOsoblje.Ime = request.Ime;
                newOsoblje.Prezime = request.Prezime;
                newOsoblje.Email = request.Email;
                newOsoblje.BrojTelefona = request.BrojTelefona;
                newOsoblje.GodineIskustva = request.GodineIskustva;
                newOsoblje.KorisnickoIme = $"{request.Ime.ToLower()}.{request.Prezime.ToLower()}";
                newOsoblje.Password = password;
                newOsoblje.OdjeljenjeId = odjeljenje.Id;
                newOsoblje.Odjeljenje = odjeljenje;
                newOsoblje.slika = slika;
                newOsoblje.IsEnabled2FA = request.Enable2FA;
                newOsoblje.Uloge = new List<Uloga> { uloga };

                _dbContext.Add(newOsoblje);
                _dbContext.SaveChanges();

                EmailHelper.SendMail($"Welcome to HealthCare, {newOsoblje.Ime} {newOsoblje.Prezime}!",
                    $"Hello {newOsoblje.Ime} {newOsoblje.Prezime}!<br><br>" +
                    $"Here are your login credentials:<br>" +
                    $"Email: {newOsoblje.Email}<br>" +
                    $"Password: {newOsoblje.Password}<br><br>" +
                    $"We hope you have a great experience using our application!",
                    newOsoblje.Email);

                return Ok(newOsoblje);
            }
            catch (Exception)
            {
                return BadRequest("Greska prilikom kreiranja korisnika.");
            }
        }

        [HttpGet]
        public ActionResult GetOdjeljenja()
        {
            var result = _dbContext.Odjeljenje.Select(x => new OsobljeNazivVM()
            {
                Id = x.Id,
                Naziv = x.Naziv
            }).OrderByDescending(x => x.Id).ToList();

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            Osoblje osoblje = _dbContext.Osoblje.Find(id);

            if (osoblje == null || id == "")
                return BadRequest("pogresan ID");

            _dbContext.Remove(osoblje);
            _dbContext.SaveChanges();
            return Ok(osoblje);
        }
    }
}
