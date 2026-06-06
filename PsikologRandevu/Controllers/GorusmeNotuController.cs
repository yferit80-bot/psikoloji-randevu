using Microsoft.AspNetCore.Mvc;
using PsikologRandevu.Models;

namespace PsikologRandevu.Controllers
{
    public class GorusmeNotuController : Controller
    {
        private readonly AppDbContext _context;

        public GorusmeNotuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notlar = _context.GorusmeNotlari.ToList();
            return View(notlar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GorusmeNotlari gorusmeNotu)
        {
            gorusmeNotu.Tarih = DateTime.Now;
            _context.GorusmeNotlari.Add(gorusmeNotu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var not = _context.GorusmeNotlari.Find(id);
            if (not != null)
            {
                _context.GorusmeNotlari.Remove(not);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}