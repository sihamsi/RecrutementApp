using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Models
{
    
    public class OffreExterneViewModel
    {
        public string Titre { get; set; }
        public string Entreprise { get; set; }
        public string TypeContrat { get; set; }
        public decimal Salaire { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
