using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PsikologRandevu.Models;

namespace PsikologRandevu.Controllers
{
    public class RandevuController : Controller
    {
        private readonly AppDbContext _context;

        public RandevuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");

            if (rol == "Hasta")
            {
                var hastaId = HttpContext.Session.GetInt32("HastaId");
                var randevular = _context.Randevular
                    .Include(r => r.Hasta).ThenInclude(h => h.Kullanici)
                    .Include(r => r.Psikolog).ThenInclude(p => p.Kullanici)
                    .Where(r => r.HastaId == hastaId)
                    .ToList();
                return View(randevular);
            }
            else if (rol == "Doktor")
            {
                var psikologId = HttpContext.Session.GetInt32("PsikologId");
                var randevular = _context.Randevular
                    .Include(r => r.Hasta).ThenInclude(h => h.Kullanici)
                    .Include(r => r.Psikolog).ThenInclude(p => p.Kullanici)
                    .Where(r => r.PsikologId == psikologId)
                    .ToList();
                return View(randevular);
            }

            return RedirectToAction("Index", "Giris");
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

        public IActionResult Onayla(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");

            var randevu = _context.Randevular.Find(id);
            if (randevu != null)
            {
                randevu.Durum = "Onaylandi";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Iptal(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");

            var randevu = _context.Randevular.Find(id);
            if (randevu != null)
            {
                randevu.Durum = "Iptal";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");

            var randevu = _context.Randevular.Find(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}