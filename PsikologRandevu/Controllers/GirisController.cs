using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsikologRandevu.Models;

namespace PsikologRandevu.Controllers
{
    public class GirisController : Controller
    {
        private readonly AppDbContext _context;

        public GirisController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Hasta Giriş Sayfası
        public IActionResult HastaGiris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HastaGiris(string email, string sifre)
        {
            var kullanici = _context.Kullanicilar
                .FirstOrDefault(k => k.Email == email && k.Sifre == sifre && k.Rol == "Hasta");

            if (kullanici != null)
            {
                var hasta = _context.Hastalar
                    .FirstOrDefault(h => h.KullaniciId == kullanici.Id);

                HttpContext.Session.SetString("KullaniciAd", kullanici.Ad + " " + kullanici.Soyad);
                HttpContext.Session.SetString("Rol", "Hasta");
                HttpContext.Session.SetInt32("KullaniciId", kullanici.Id);
                if (hasta != null)
                    HttpContext.Session.SetInt32("HastaId", hasta.Id);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Hata = "Email veya şifre hatalı!";
            return View();
        }

        // Doktor Giriş Sayfası
        public IActionResult DoktorGiris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoktorGiris(string email, string sifre)
        {
            var kullanici = _context.Kullanicilar
                .FirstOrDefault(k => k.Email == email && k.Sifre == sifre && k.Rol == "Psikolog");

            if (kullanici != null)
            {
                var psikolog = _context.Psikologlar
                    .FirstOrDefault(p => p.KullaniciId == kullanici.Id);

                HttpContext.Session.SetString("KullaniciAd", kullanici.Ad + " " + kullanici.Soyad);
                HttpContext.Session.SetString("Rol", "Doktor");
                HttpContext.Session.SetInt32("KullaniciId", kullanici.Id);
                if (psikolog != null)
                    HttpContext.Session.SetInt32("PsikologId", psikolog.Id);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Hata = "Email veya şifre hatalı!";
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Giris");
        }
    }
}