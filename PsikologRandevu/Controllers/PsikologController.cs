using Microsoft.AspNetCore.Mvc;
using PsikologRandevu.Models;

namespace PsikologRandevu.Controllers
{
    public class PsikologController : Controller
    {
        private readonly AppDbContext _context;

        public PsikologController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var psikologlar = _context.Psikologlar.ToList();
            return View(psikologlar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Psikolog psikolog)
        {
            _context.Psikologlar.Add(psikolog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var psikolog = _context.Psikologlar.Find(id);
            _context.Psikologlar.Remove(psikolog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}