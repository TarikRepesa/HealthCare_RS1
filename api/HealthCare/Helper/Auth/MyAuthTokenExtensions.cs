using System.Text.Json.Serialization;
using HealthCare.Data;
using Microsoft.EntityFrameworkCore;
using HealthCare.Models;
using HealthCare.WebAPI.Models;

namespace HealthCare.Helper.Auth
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AuthToken authToken)
            {
                AuthToken = authToken;
            }

            [JsonIgnore]
            public Korisnik Korisnik => AuthToken?.Korisnik;
            public AuthToken AuthToken { get; set; }

            public bool IsLogiran => Korisnik != null;
            public bool IsPermisijaAdmin => IsLogiran && Korisnik.Uloge.Any(x => x.Naziv == "Admin");
            public bool IsPermisijaAsistent => IsLogiran && Korisnik.Uloge.Any(x => x.Naziv == "Asistent");
            public bool IsPermisijaFarmaceut => IsLogiran && Korisnik.Uloge.Any(x => x.Naziv == "Farmaceut");
            public bool IsPermisijaTehnicar => IsLogiran && Korisnik.Uloge.Any(x => x.Naziv == "Tehnicar");
            public bool IsPermisijaLjekar => IsLogiran && Korisnik.Uloge.Any(x => x.Naziv == "Ljekar");
            public bool IsPermisijaPacijent => IsLogiran && Korisnik.Uloge.Any(x => x.Naziv == "Pacijent");
        }


        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }

        public static AuthToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext context = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AuthToken? authToken = context.AuthToken.Where(x => x.Token == token)
                .Include(x => x.Korisnik.Uloge)
                .FirstOrDefault();

            return authToken;
        }

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            return httpContext.Request.Headers.Authorization;
        }
    }
}
