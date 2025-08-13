using Microsoft.AspNetCore.Mvc;
using HealthCare.Data;
using HealthCare.Models;
using HealthCare.WebAPI.Models;
using static HealthCare.Helper.Auth.MyAuthTokenExtension;
using HealthCare.ViewModels.Login;
using HealthCare.Helper;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM request)
        {
            //1- provjera logina

            var logiraniKorisnik = _dbContext.Korisnik
                .Where(x => x.Email != null && x.Email == request.Email && x.Password == request.Lozinka)
                .Include(x => x.Uloge)
                .FirstOrDefault();

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return new LoginInformacije(null);
            }

            var noviToken = new AuthToken()
            {
                IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Korisnik = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now,
                IsAllowed2FA = logiraniKorisnik.IsEnabled2FA == false
            };

            //2- generisati random string
            string randomString = TokenGenerator.GenerisiAlfanumerickiToken(10);

            //3- dodati novi zapis u tabelu AuthToken za logiraniKorisnikId i randomString
            noviToken.Token = randomString;
            _dbContext.AuthToken.Add(noviToken);
            _dbContext.SaveChanges();

            if (logiraniKorisnik.IsEnabled2FA)
            {
                logiraniKorisnik.VerificationCode = TokenGenerator.GenerisiNumerickiToken(6);
                _dbContext.SaveChanges();

                EmailHelper.SendMail("Two-factor verification",
                    $"Hello {logiraniKorisnik.Ime} {logiraniKorisnik.Prezime}!<br>" +
                    $"Here is your 2FA Verification code: {logiraniKorisnik.VerificationCode}<br>" +
                    $"<br>" +
                    $"Thank you for using HealthCare!",
                    logiraniKorisnik.Email);
            }
            //4- vratiti token string
            return new LoginInformacije(noviToken);     
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AuthToken authToken = HttpContext.GetAuthToken();

            if (authToken == null)
                return Ok();

            _dbContext.AuthToken.Remove(authToken);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<AuthToken> Get()
        {
            AuthToken authToken = HttpContext.GetAuthToken();

            return authToken;
        }

        [HttpPost]
        public ActionResult<LoginInformacije> Login2FA([FromBody] LoginWith2FAVM request)
        {
            var loginInformacije = HttpContext.GetLoginInfo();
            if (loginInformacije == null)
            {
                return new LoginInformacije(null);
            }

            Korisnik logiraniKorisnik = loginInformacije.Korisnik;

            if (logiraniKorisnik == null)
            {
                return new LoginInformacije(null);
            }

            if (HttpContext.GetLoginInfo().AuthToken.IsAllowed2FA)
            {
                return Ok(loginInformacije);
            }

            if (request.VerificationCode == logiraniKorisnik.VerificationCode)
            {
                loginInformacije.AuthToken.IsAllowed2FA = true;
                loginInformacije.Korisnik.VerificationCode = null;
                _dbContext.SaveChanges();
                return Ok(loginInformacije);
            }
            return BadRequest();
        }
    }
}