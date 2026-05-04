using Microsoft.AspNetCore.Mvc;
using PsikologRandevu.Models;

namespace PsikologRandevu.Controllers
{
    public class HastaController : Controller
    {
        private readonly AppDbContext _context;

        public HastaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hastalar = _context.Hastalar.ToList();
            return View(hastalar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hasta hasta)
        {
            _context.Hastalar.Add(hasta);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var hasta = _context.Hastalar.Find(id);
            _context.Hastalar.Remove(hasta);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}