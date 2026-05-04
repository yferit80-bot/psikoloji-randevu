using Microsoft.AspNetCore.Mvc;

namespace PsikologRandevu.Controllers
{
    public class RandevuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
