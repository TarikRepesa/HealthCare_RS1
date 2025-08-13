using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HealthCare.Helper.Auth
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(
            bool admin = false,
            bool asistent = false,
            bool farmaceut = false,
            bool tehnicar = false,
            bool ljekar = false,
            bool pacijent = false)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { admin, asistent, farmaceut, tehnicar, ljekar, pacijent  };
        }
    }

    public class MyAuthorizeImpl : IActionFilter
    {
        private readonly bool _admin;
        private readonly bool _asistent;
        private readonly bool _farmaceut;
        private readonly bool _tehnicar;
        private readonly bool _ljekar;
        private readonly bool _pacijent;

        public MyAuthorizeImpl(bool admin = false, bool asistent = false, bool farmaceut = false, bool tehnicar = false, bool ljekar = false, bool pacijent = false)
        {
            _admin = admin;
            _asistent = asistent;
            _farmaceut = farmaceut;
            _tehnicar = tehnicar;
            _ljekar = ljekar;
            _pacijent = pacijent;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var loginInfo = filterContext.HttpContext.GetLoginInfo();
            if (!loginInfo.IsLogiran)
            {
                // Korisnik nije prijavljen, nema pravo pristupa
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            if (loginInfo.AuthToken.IsAllowed2FA == false)
            {
                filterContext.Result = new UnauthorizedResult();
            }

            if (!_admin && !_asistent && !_farmaceut && !_tehnicar && !_pacijent && !_ljekar) {
                // Endpoint ne trazi autorizaciju po roli, imamo pravo pristupa
                return;
            }

            if (loginInfo.IsPermisijaAdmin && _admin)
            {
                return;//ok - ima pravo pristupa
            }
            if (loginInfo.IsPermisijaAsistent && _asistent)
            {
                return;//ok - ima pravo pristupa
            }
            if (loginInfo.IsPermisijaFarmaceut && _farmaceut)
            {
                return;//ok - ima pravo pristupa
            }
            if (loginInfo.IsPermisijaTehnicar && _tehnicar)
            {
                return;//ok - ima pravo pristupa
            }
            if (loginInfo.IsPermisijaLjekar && _ljekar)
            {
                return;//ok - ima pravo pristupa
            }
            if (loginInfo.IsPermisijaPacijent && _pacijent)
            {
                return;//ok - ima pravo pristupa
            }

            //else nema pravo pristupa
            filterContext.Result = new UnauthorizedResult();
        }
    }
}
