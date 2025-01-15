using E_Recrutement.Data;
using E_Recrutement.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Recrutement.Controllers
{
    public class CandidaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Postuler(int offreId)
        {
            // Get the current user's email from claims
            var userEmail = User.Identity.Name; // or User.FindFirstValue(ClaimTypes.Email);

            // Get the candidat based on the logged-in user
            var candidat = _context.Candidats
                .FirstOrDefault(c => c.Email == userEmail); // You'll need to add Email property to Candidat model

            if (candidat == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Check for existing application
            var existingApplication = _context.Candidatures
                .FirstOrDefault(c => c.IdCandidat == candidat.IdCandidat && c.IdOffre == offreId);

            if (existingApplication != null)
            {
                TempData["Error"] = "Vous avez déjà postulé à cette offre.";
                return RedirectToAction("Details", "Offres", new { id = offreId });
            }

            var candidature = new Candidature
            {
                IdCandidat = candidat.IdCandidat,
                IdOffre = offreId,
                DatePostulation = DateTime.Now,
                Statut = "En attente"
            };

            _context.Candidatures.Add(candidature);
            _context.SaveChanges();

            return RedirectToAction("MesCandidatures");
        }

        [Authorize]
        public IActionResult MesCandidatures()
        {
            var userEmail = User.Identity.Name;
            var candidat = _context.Candidats
                .FirstOrDefault(c => c.Email == userEmail);

            if (candidat == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var candidatures = _context.Candidatures
                .Include(c => c.Offre)
                .Where(c => c.IdCandidat == candidat.IdCandidat)
                .OrderByDescending(c => c.DatePostulation)
                .ToList();

            return View(candidatures);
        }
    }
}
