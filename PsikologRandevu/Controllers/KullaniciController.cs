using Microsoft.AspNetCore.Mvc;

namespace PsikologRandevu.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
