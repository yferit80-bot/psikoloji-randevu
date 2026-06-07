using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");
            if (rol != "Doktor")
                return RedirectToAction("Index", "Home");

            var hastalar = _context.Hastalar
                .Include(h => h.Kullanici)
                .ToList();
            return View(hastalar);
        }

        public IActionResult Create()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");

            var psikologlar = _context.Psikologlar
                .Include(p => p.Kullanici)
                .Select(p => new {
                    p.Id,
                    AdSoyad = p.Kullanici.Ad + " " + p.Kullanici.Soyad
                }).ToList();

            ViewBag.PsikologId = new SelectList(psikologlar, "Id", "AdSoyad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Randevular randevu)
        {
            var hastaId = HttpContext.Session.GetInt32("HastaId");
            randevu.HastaId = hastaId ?? 0;
            randevu.Durum = "Bekliyor";
            _context.Randevular.Add(randevu);
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

            var hasta = _context.Hastalar.Find(id);
            if (hasta != null)
            {
                _context.Hastalar.Remove(hasta);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}