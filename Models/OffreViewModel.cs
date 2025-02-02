using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Models
{
    public class OffreViewModel
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Entreprise { get; set; }
        public string Localisation { get; set; }
        public string TypeContrat { get; set; }
        public DateTime DatePublication { get; set; }
        public decimal SalaireMoyen { get; set; }
        public List<string> Competences { get; set; }
        public int NombreCandidatures { get; set; }
    }
}
