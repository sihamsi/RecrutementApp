using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Models
{
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
        public string Email { get; set; }  // Add this property
    }

}
