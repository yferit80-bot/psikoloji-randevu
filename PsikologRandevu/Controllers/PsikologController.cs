using Microsoft.AspNetCore.Mvc;

namespace PsikologRandevu.Controllers
{
    public class PsikologController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
