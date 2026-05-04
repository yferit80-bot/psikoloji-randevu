using Microsoft.AspNetCore.Mvc;
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
            var randevular = _context.Randevular.ToList();
            return View(randevular);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Randevu randevu)
        {
            randevu.Durum = "Bekliyor";
            _context.Randevular.Add(randevu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Onayla(int id)
        {
            var randevu = _context.Randevular.Find(id);
            randevu.Durum = "Onaylandi";
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Iptal(int id)
        {
            var randevu = _context.Randevular.Find(id);
            randevu.Durum = "Iptal";
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var randevu = _context.Randevular.Find(id);
            _context.Randevular.Remove(randevu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}