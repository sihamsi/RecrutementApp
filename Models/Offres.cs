using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace E_Recrutement.Models
{
    public class Offres
    {
        [Key]
        public int Id { get; set; }
        public int IdRecruteur { get; set; }
        public string TypeContrat { get; set; }
        
        public string Secteur { get; set; }
       
        public string Profil { get; set; }
       
        public string Poste { get; set; }
       
        public int Remuneration { get; set; }
    }
}
