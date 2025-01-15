using E_Recrutement.Data;
using E_Recrutement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Recrutement.Controllers
{
    public class OffresController : Controller
    {
        private readonly ApplicationDbContext _context;
        
       
        public OffresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchPoste, string secteur, string profil, string remuneration)
        {
            var offres = _context.Offres.AsQueryable();

            if (!string.IsNullOrEmpty(searchPoste))
                offres = offres.Where(o => o.Poste.Contains(searchPoste));

            if (!string.IsNullOrEmpty(secteur))
                offres = offres.Where(o => o.Secteur == secteur);

            if (!string.IsNullOrEmpty(profil))
                offres = offres.Where(o => o.Profil == profil);

            if (!string.IsNullOrEmpty(remuneration))
            {
                var rem = int.Parse(remuneration);
                if (rem == 10000)
                    offres = offres.Where(o => o.Remuneration < 10000);
                else if (rem == 20000)
                    offres = offres.Where(o => o.Remuneration >= 10000 && o.Remuneration <= 20000);
                else if (rem == 30000)
                    offres = offres.Where(o => o.Remuneration > 20000);
            }

            return View(offres.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Offres offre)
        {
            if (ModelState.IsValid)
            {
                _context.Offres.Add(offre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(offre);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var offre = _context.Offres.FirstOrDefault(o => o.Id == id);
            if (offre == null)
            {
                return NotFound();
            }
            return View(offre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Offres offre)
        {
            if (ModelState.IsValid)
            {
                _context.Update(offre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(offre);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var offre = _context.Offres.FirstOrDefault(o => o.Id == id);
            if (offre == null)
            {
                return NotFound();
            }
            return View(offre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var offre = _context.Offres.FirstOrDefault(o => o.Id == id);
            if (offre != null)
            {
                _context.Offres.Remove(offre);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var offre = _context.Offres.FirstOrDefault(o => o.Id == id);
            if (offre == null)
            {
                return NotFound();
            }
            return View(offre);
        }


    }
}
