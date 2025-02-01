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

        // GET: Offres/Details/5
        public IActionResult Details(int id)
        {
            var offre = _context.Offres.FirstOrDefault(o => o.Id == id);
            if (offre == null) return NotFound();

            // Ajoutez cette logique
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var candidat = _context.Candidats.FirstOrDefault(c => c.Email == userEmail);
            var dejaPostule = false;

            if (candidat != null)
            {
                dejaPostule = _context.Candidatures
                    .Any(c => c.IdOffre == id && c.IdCandidat == candidat.IdCandidat);
            }

            ViewBag.DejaPostule = dejaPostule;
            ViewBag.EstAuthentifie = User.Identity.IsAuthenticated;

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

        [HttpGet]
        public IActionResult PostulerForm(int id)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userEmail)) return Unauthorized();

            var candidat = _context.Candidats.FirstOrDefault(c => c.Email == userEmail);
            if (candidat == null) return View("Error");

            // Vérifier si déjà postulé
            var dejaPostule = _context.Candidatures
                .Any(c => c.IdOffre == id && c.IdCandidat == candidat.IdCandidat);

            ViewBag.DejaPostule = dejaPostule;
            ViewBag.OffreId = id;

            return View(new Candidature
            {
                IdOffre = id,
                Candidat = candidat
            });
        }

        [HttpPost]
        public async Task<IActionResult> Postuler(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Récupère l'ID du candidat connecté

            var candidature = new Candidature
            {
                IdOffre = id,
                IdCandidat = int.Parse(userId),
                DatePostulation = DateTime.Now,
                Statut = "En attente"
            };

            _context.Candidatures.Add(candidature);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Candidature envoyée avec succès!" });
        }




        // GET: MesCandidatures
        public IActionResult MesCandidatures()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userEmail)) return View(new List<Candidature>());

            var candidatId = _context.Candidats
                .Where(c => c.Email == userEmail)
                .Select(c => c.IdCandidat)
                .FirstOrDefault();

            var applications = _context.Candidatures
                .Include(c => c.Offre)
                .Where(c => c.IdCandidat == candidatId)
                .ToList();

            return View(applications);
        }
    }
}