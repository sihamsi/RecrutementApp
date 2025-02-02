using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Models
{
    public class CandidatDetails
    {
        public Candidat Candidat { get; set; }
        public Offres Offre { get; set; }
    }
}
