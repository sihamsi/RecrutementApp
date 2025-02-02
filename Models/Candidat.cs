using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace E_Recrutement.Models
{
    [Table("Candidats")]
    public class Candidat
    {
        [Key]
        public int IdCandidat { get; set; }

        // Stocke l'ID de l'utilisateur Identity (string)
        public string AspNetUserId { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string Titre { get; set; }
        public string Diplome { get; set; }
        public int NombreAnneeExperience { get; set; }
        public string CV { get; set; }
        [NotMapped]
        public IFormFile CVFile { get; set; }
        public string Email { get; set; }

        // Vous pouvez retirer ou adapter IdUser ou Id si nécessaire
        public string? IdUser { get; internal set; }
        public string Status { get; set; } = "En attente"; 
    }
}
