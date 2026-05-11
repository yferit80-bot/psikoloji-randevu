using Microsoft.AspNetCore.Mvc;

namespace PsikologRandevu.Controllers
{
    public class GirisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HastaGiris()
        {
            HttpContext.Session.SetString("Rol", "Hasta");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DoktorGiris()
        {
            HttpContext.Session.SetString("Rol", "Doktor");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Giris");
        }
    }
}