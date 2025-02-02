using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using E_Recrutement.Data;
using E_Recrutement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace E_Recrutement.Controllers
{
    public class OffresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OffresController> _logger;

        public OffresController(ApplicationDbContext context, ILogger<OffresController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Offres
        public IActionResult Index(string searchPoste, string secteur, string profil, string remuneration)
        {
            var query = _context.Offres.AsQueryable();

            if (!string.IsNullOrEmpty(searchPoste))
                query = query.Where(o => o.Poste.Contains(searchPoste));

            if (!string.IsNullOrEmpty(secteur))
                query = query.Where(o => o.Secteur == secteur);

            if (!string.IsNullOrEmpty(profil))
                query = query.Where(o => o.Profil == profil);

            if (!string.IsNullOrEmpty(remuneration))
            {
                var rem = int.Parse(remuneration);
                query = rem switch
                {
                    10000 => query.Where(o => o.Remuneration < 10000),
                    20000 => query.Where(o => o.Remuneration >= 10000 && o.Remuneration <= 20000),
                    30000 => query.Where(o => o.Remuneration > 20000),
                    _ => query
                };
            }

            return View(query.ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offre = await _context.Offres
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offre == null)
            {
                return NotFound();
            }


            return View(offre);
        }

        // GET: Offres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Offres offre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(offre);
        }

        // GET: Offres/Edit/5
        public IActionResult Edit(int id)
        {
            var offre = _context.Offres.Find(id);
            return offre == null ? NotFound() : View(offre);
        }

        // POST: Offres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Offres offre)
        {
            if (id != offre.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(offre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(offre);
        }

        // GET: Offres/Delete/5
        public IActionResult Delete(int id)
        {
            var offre = _context.Offres.FirstOrDefault(o => o.Id == id);
            return offre == null ? NotFound() : View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var offre = _context.Offres.Find(id);
            if (offre != null)
            {
                _context.Offres.Remove(offre);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}