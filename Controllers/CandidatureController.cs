using E_Recrutement.Data;
using E_Recrutement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;


namespace E_Recrutement.Controllers
{
    public class CandidatureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Candidature/Postuler/{id}
        public IActionResult Postuler(int id)
        {
            var candidature = new Candidature
            {
                IdOffre = id,
                Candidat = new Candidat()
            };

            ViewBag.DejaPostule = false;
            return View(candidature);
        }

        // POST: Candidature/Postuler
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Postuler(Candidature candidature)
        {
            if (candidature.Candidat == null || string.IsNullOrEmpty(candidature.Candidat.Email))
            {
                TempData["Error"] = "L'email du candidat est requis.";
                return RedirectToAction("Postuler", new { id = candidature.IdOffre });
            }
            
            

            // Get logged-in user ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Check if the candidate exists
            var candidat = _context.Candidats.FirstOrDefault(c => c.Email == candidature.Candidat.Email);
            if (candidat == null)
            {
                candidat = new Candidat
                {
                    Email = candidature.Candidat.Email,
                    Nom = candidature.Candidat.Nom,
                    Prenom = candidature.Candidat.Prenom,
                    AspNetUserId = "8",
                    CV = candidature.Candidat.CV ?? "default_cv.pdf",
                    Diplome = candidature.Candidat.Diplome ?? "default_diplome.pdf",
                    Titre = "Default Title"
                };

                _context.Candidats.Add(candidat);
                _context.SaveChanges();
            }

            // Check if already applied
            var existingCandidature = _context.Candidatures
                .FirstOrDefault(c => c.IdOffre == candidature.IdOffre && c.IdCandidat == candidat.IdCandidat);

            if (existingCandidature != null)
            {
                TempData["Error"] = "Vous avez déjà postulé à cette offre.";
                return RedirectToAction("Details", "Offres", new { id = candidature.IdOffre });
            }

            // Save new candidature
            candidature.IdCandidat = candidat.IdCandidat;
            candidature.DatePostulation = DateTime.Now;
            candidature.Statut = "En attente";

            _context.Candidatures.Add(candidature);
            _context.SaveChanges();

            TempData["Success"] = "Votre candidature a été enregistrée avec succès.";
            return RedirectToAction("MesCandidatures");
        }

        // GET: Candidature/MesCandidatures

        public IActionResult MesCandidatures()
        {
            return View(_hardcodedCandidats);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = _hardcodedCandidats.FirstOrDefault(c => c.IdCandidat == id);

            if (candidat == null)
            {
                return NotFound();
            }

            var offre = new Offres();

            switch (candidat.IdCandidat)
            {
                case 1:
                case 7:
                    offre = new Offres
                    {
                        Id = 1,
                        IdRecruteur = 101,
                        TypeContrat = "CDI",
                        Secteur = "Développement logiciel",
                        Profil = "Ingénieur",
                        Poste = "Développeur Full Stack",
                        Remuneration = 20000
                    };
                    break;
                case 2:
                    offre = new Offres
                    {
                        Id = 4,
                        IdRecruteur = 104,
                        TypeContrat = "Freelance",
                        Secteur = "Développement mobile",
                        Profil = "Licence",
                        Poste = "Développeur Mobile",
                        Remuneration = 12000
                    };
                    break;
                case 3:
                    offre = new Offres
                    {
                        Id = 2,
                        IdRecruteur = 102,
                        TypeContrat = "CDD",
                        Secteur = "Analyse de données",
                        Profil = "Master",
                        Poste = "Data Analyst",
                        Remuneration = 15000
                    };
                    break;
                case 4:
                case 6:
                    offre = new Offres
                    {
                        Id = 3,
                        IdRecruteur = 103,
                        TypeContrat = "CDI",
                        Secteur = "Cybersécurité",
                        Profil = "Ingénieur",
                        Poste = "Spécialiste en Sécurité Informatique",
                        Remuneration = 18000
                    };
                    break;
                case 5:
                    offre = new Offres
                    {
                        Id = 5,
                        IdRecruteur = 105,
                        TypeContrat = "CDI",
                        Secteur = "Gestion de projets IT",
                        Profil = "Master",
                        Poste = "Chef de Projet IT",
                        Remuneration = 25000
                    };
                    break;
            }

            var candidatDetails = new CandidatDetails
            {
                Candidat = candidat,
                Offre = offre
            };

            return View(candidatDetails);
        }
        private static List<Candidat> _hardcodedCandidats = new List<Candidat>
{
    new Candidat
    {
        IdCandidat = 1,
        Nom = "Ahmed",
        Prenom = "Benali",
        Age = 28,
        Diplome = "Master en Développement Web",
        Email = "Candidat22@gmail.com",
        CV = "cv_ahmed_benali.pdf",
        Status = "En attente"
    },
    new Candidat
    {
        IdCandidat = 2,
        Nom = "Fatima",
        Prenom = "El Amrani",
        Age = 25,
        Diplome = "Ingénieur Informatique",
        Email = "Candidat1@gmail.com",
        CV = "cv_fatima_elamrani.pdf",
        Status = "En attente"
    },
    new Candidat
    {
        IdCandidat = 3,
        Nom = "Karim",
        Prenom = "Tazi",
        Age = 30,
        Diplome = "Master en Data Science",
        Email = "karim.tazi@gmail.com",
        CV = "cv_karim_tazi.pdf",
        Status = "En attente"
    },
    new Candidat
    {
        IdCandidat = 4,
        Nom = "Yasmine",
        Prenom = "Bennani",
        Age = 27,
        Diplome = "Licence en Réseaux",
        Email = "yasmine.bennani@gmail.com",
        CV = "cv_yasmine_bennani.pdf",
        Status = "En attente"
    },
    new Candidat
    {
        IdCandidat = 5,
        Nom = "Omar",
        Prenom = "Alaoui",
        Age = 32,
        Diplome = "Doctorat en IA",
        Email = "omar.alaoui@gmail.com",
        CV = "cv_omar_alaoui.pdf",
        Status = "En attente"
    },
    new Candidat
    {
        IdCandidat = 6,
        Nom = "Salma",
        Prenom = "Ziani",
        Age = 24,
        Diplome = "Master en Cybersécurité",
        Email = "salma.ziani@gmail.com",
        CV = "cv_salma_ziani.pdf",
        Status = "En attente"
    },
    new Candidat
    {
        IdCandidat = 7,
        Nom = "Mehdi",
        Prenom = "Idrissi",
        Age = 29,
        Diplome = "Ingénieur en Cloud Computing",
        Email = "mehdi.idrissi@gmail.com",
        CV = "cv_mehdi_idrissi.pdf",
        Status = "En attente"
    }
};
        // POST: Candidature/Annuler/{id}
        [HttpPost]
        public IActionResult AnnulerCandidature(int id)
        {
            var candidature = _context.Candidatures.Find(id);
            if (candidature == null)
            {
                TempData["Error"] = "Candidature introuvable.";
                return RedirectToAction("MesCandidatures");
            }

            _context.Candidatures.Remove(candidature);
            _context.SaveChanges();

            TempData["Success"] = "Votre candidature a été annulée.";
            return RedirectToAction("MesCandidatures");
        }
        [HttpPost]
        [Authorize(Roles = "Recruteur")]
        public IActionResult UpdateStatus(int id, string status)
        {
            var candidat = _hardcodedCandidats.FirstOrDefault(c => c.IdCandidat == id);
            if (candidat != null)
            {
                candidat.Status = status;
            }
            return RedirectToAction("Details", new { id });
        }

        // Helper method to get the static list of candidates
        private List<Candidat> GetStaticCandidats()
        {
            return new List<Candidat>
    {
        new Candidat { IdCandidat = 1, /* ... existing properties ... */ },
        new Candidat { IdCandidat = 2, /* ... existing properties ... */ },
        // Add all your existing candidates here with Status property
    };
        }
        // Dans CandidatureController.cs
        public IActionResult Statistiques()
        {
            var stats = new StatistiquesCandidatures
            {
                TotalCandidatures = _hardcodedCandidats.Count,
                NombreAcceptees = _hardcodedCandidats.Count(c => c.Status == "Accepté"),
                NombreEnAttente = _hardcodedCandidats.Count(c => c.Status == "En attente"),
                NombreRefusees = _hardcodedCandidats.Count(c => c.Status == "Refusé"),
                CandidaturesParSecteur = _hardcodedCandidats
                    .GroupBy(c => GetSecteurForCandidat(c.IdCandidat))
                    .ToDictionary(g => g.Key, g => g.Count()),
                CandidaturesParTypeContrat = _hardcodedCandidats
                    .GroupBy(c => GetTypeContratForCandidat(c.IdCandidat))
                    .ToDictionary(g => g.Key, g => g.Count())
            };

            return View(stats);
        }

        // Méthode helper pour récupérer le secteur
        private string GetSecteurForCandidat(int idCandidat)
        {
            return idCandidat switch
            {
                1 or 7 => "Développement logiciel",
                2 => "Développement mobile",
                3 => "Analyse de données",
                4 or 6 => "Cybersécurité",
                5 => "Gestion de projets IT",
                _ => "Autre"
            };
        }

        // Méthode helper pour récupérer le type de contrat
        private string GetTypeContratForCandidat(int idCandidat)
        {
            return idCandidat switch
            {
                1 or 7 => "CDI",
                2 => "Freelance",
                3 => "CDD",
                4 or 6 => "CDI",
                5 => "CDI",
                _ => "Autre"
            };
        }
        private static List<Recruteur> _recruteurs = new List<Recruteur>
        {
            new Recruteur
            {
                IdRecruteur = 1,
                Nom = "TechCorp",
                Mail = "contact@techcorp.ma",
                Tel = "0600000000"
            },
            new Recruteur
            {
                IdRecruteur = 2,
                Nom = "DevExperts",
                Mail = "info@devexperts.dz",
                Tel = "0500000000"
            }
        };

        // Liste hardcodée des offres
        private static List<Offres> _offres = new List<Offres>
        {
            new Offres
            {
                Id = 1,
                Poste = "Développeur Full Stack",
                IdRecruteur = 1, // Correspond à IdRecruteur = 1
                TypeContrat = "CDI",
                Remuneration = 20000
            },
            new Offres
            {
                Id = 2,
                Poste = "Data Scientist",
                IdRecruteur = 2, // Correspond à IdRecruteur = 2
                TypeContrat = "Freelance",
                Remuneration = 25000
            }
        };

        [Authorize(Roles = "Recruteur")]
        public IActionResult ListeOffresExternes()
        {
            int currentRecruiterId = 1; // À remplacer par votre logique d'authentification

            var offresExternes = _offres
                .Where(o => o.IdRecruteur != currentRecruiterId)
                .Select(o => new OffreExterneViewModel // Utilisez le ViewModel ici
                {
                    Titre = o.Poste,
                    Entreprise = _recruteurs.First(r => r.IdRecruteur == o.IdRecruteur).Nom,
                    TypeContrat = o.TypeContrat,
                    Salaire = o.Remuneration,
                    Email = _recruteurs.First(r => r.IdRecruteur == o.IdRecruteur).Mail,
                    Telephone = _recruteurs.First(r => r.IdRecruteur == o.IdRecruteur).Tel
                })
                .ToList();

            return View(offresExternes);
        }
    }
}
