using Microsoft.AspNetCore.Mvc;
using PsikologRandevu.Models;

namespace PsikologRandevu.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly AppDbContext _context;

        public KullaniciController(AppDbContext context)
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

            var kullanicilar = _context.Kullanicilar.ToList();
            return View(kullanicilar);
        }

        public IActionResult Create()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");
            if (rol != "Doktor")
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Kullanicilar kullanici)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == null)
                return RedirectToAction("Index", "Giris");

            _context.Kullanicilar.Add(kullanici);
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

            var kullanici = _context.Kullanicilar.Find(id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}