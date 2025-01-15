using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Identity;
namespace E_Recrutement.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }

    }
}
