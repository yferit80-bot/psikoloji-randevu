using Microsoft.AspNetCore.Mvc;
using PsikologRandevu.Models;

namespace PsikologRandevu.Controllers
{
    public class KayitController : Controller
    {
        private readonly AppDbContext _context;

        public KayitController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult HastaKayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HastaKayit(string ad, string soyad, string email, string sifre)
        {
            var kullanici = new Kullanicilar
            {
                Ad = ad,
                Soyad = soyad,
                Email = email,
                Sifre = sifre,
                Rol = "Hasta"
            };
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();

            var hasta = new Hastalar
            {
                KullaniciId = kullanici.Id,
                Telefon = "-"
            };
            _context.Hastalar.Add(hasta);
            _context.SaveChanges();

            return RedirectToAction("HastaGiris", "Giris");
        }

        public IActionResult PsikologKayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PsikologKayit(string ad, string soyad, string email, string sifre, string uzmanlik, decimal seansUcreti, string biyografi)
        {
            var kullanici = new Kullanicilar
            {
                Ad = ad,
                Soyad = soyad,
                Email = email,
                Sifre = sifre,
                Rol = "Psikolog"
            };
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();

            var psikolog = new Psikologlar
            {
                KullaniciId = kullanici.Id,
                Uzmanlik = uzmanlik,
                SeansUcreti = seansUcreti,
                Biyografi = biyografi
            };
            _context.Psikologlar.Add(psikolog);
            _context.SaveChanges();

            return RedirectToAction("DoktorGiris", "Giris");
        }
    }
}