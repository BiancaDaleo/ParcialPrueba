using System.Web.Mvc;
using Negocio.Logica;

namespace Presentacion1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (!Negocio.Logica.UsuarioLogica.ValidarLogin(email, password))
            {
                return View("Login");
            }
            var accesos = UsuarioLogica.ObtenerAccesos(6);
            return View("Accesos", accesos);
        }
    }
}