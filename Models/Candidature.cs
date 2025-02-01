using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Models
{
    public class Candidature
    {
        public int Id { get; set; }
        
        public int IdCandidat { get; set; }
        public int IdOffre { get; set; }
        public DateTime DatePostulation { get; set; }
        public string Statut { get; set; }

        [ForeignKey("IdCandidat")]
        public virtual Candidat Candidat { get; set; }

        [ForeignKey("IdOffre")]
        public virtual Offres Offre { get; set; }
    }
}
