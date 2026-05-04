using Microsoft.AspNetCore.Mvc;

namespace PsikologRandevu.Controllers
{
    public class HastaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
