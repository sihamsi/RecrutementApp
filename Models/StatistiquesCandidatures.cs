using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Models
{
    
    public class StatistiquesCandidatures
    {
        public int TotalCandidatures { get; set; }
        public int NombreAcceptees { get; set; }
        public int NombreEnAttente { get; set; }
        public int NombreRefusees { get; set; }
        public Dictionary<string, int> CandidaturesParSecteur { get; set; }
        public Dictionary<string, int> CandidaturesParTypeContrat { get; set; }
    }
}
