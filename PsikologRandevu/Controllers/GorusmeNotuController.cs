using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");
            if (rol != "Doktor")
                return RedirectToAction("Index", "Home");

            var psikologId = HttpContext.Session.GetInt32("PsikologId");
            var notlar = _context.GorusmeNotlari
                .Where(n => n.PsikologId == psikologId)
                .ToList();
            return View(notlar);
        }

        public IActionResult Create()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");
            if (rol != "Doktor")
                return RedirectToAction("Index", "Home");

            var psikologId = HttpContext.Session.GetInt32("PsikologId");
            var randevular = _context.Randevular
                .Include(r => r.Hasta).ThenInclude(h => h.Kullanici)
                .Where(r => r.PsikologId == psikologId && r.Durum == "Onaylandi")
                .Select(r => new {
                    r.Id,
                    HastaAd = r.Hasta.Kullanici.Ad + " " + r.Hasta.Kullanici.Soyad + " - " + r.Tarih.ToShortDateString()
                }).ToList();

            ViewBag.RandevuId = new SelectList(randevular, "Id", "HastaAd");
            return View();
        }

        [HttpPost]
        public IActionResult Create(GorusmeNotlari gorusmeNotu)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");

            gorusmeNotu.Tarih = DateTime.Now;
            var psikologId = HttpContext.Session.GetInt32("PsikologId");
            gorusmeNotu.PsikologId = psikologId ?? 0;
            _context.GorusmeNotlari.Add(gorusmeNotu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");
            if (rol != "Doktor")
                return RedirectToAction("Index", "Home");

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