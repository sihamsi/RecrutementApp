using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Models
{
    [Table("Candidats")]
    public class Candidat
    {
        [Key]
        public int IdCandidat { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string Titre { get; set; }
        public string Diplome { get; set; }
        public int NombreAnneeExperience { get; set; }
        public string CV { get; set; }
        [NotMapped] // This prevents EF from mapping it to the database
        public IFormFile CVFile { get; set; }
        public string Email { get; set; }  // Add this property
    }

}
