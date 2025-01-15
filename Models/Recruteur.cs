using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Models
{
    public class Recruteur
    {
        [Key]
        public int IdRecruteur { get; set; }
        public string Nom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
    }

}
