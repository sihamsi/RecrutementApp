using E_Recrutement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Recrutement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Offres> Offres  { get; set; }
        public DbSet<Recruteur> Recruteurs { get; set; }
        public DbSet<Candidat> Candidats { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Offres>().HasData(
                new Offres
                {
                    Id = 1,
                    IdRecruteur = 101,
                    TypeContrat = "CDI",
                    Secteur = "Développement logiciel",
                    Profil = "Ingénieur",
                    Poste = "Développeur Full Stack",
                    Remuneration = 20000
                },
                new Offres
                {
                    Id = 2,
                    IdRecruteur = 102,
                    TypeContrat = "CDD",
                    Secteur = "Analyse de données",
                    Profil = "Master",
                    Poste = "Data Analyst",
                    Remuneration = 15000
                },
                new Offres
                {
                    Id = 3,
                    IdRecruteur = 103,
                    TypeContrat = "CDI",
                    Secteur = "Cybersécurité",
                    Profil = "Ingénieur",
                    Poste = "Spécialiste en Sécurité Informatique",
                    Remuneration = 18000
                },
                new Offres
                {
                    Id = 4,
                    IdRecruteur = 104,
                    TypeContrat = "Freelance",
                    Secteur = "Développement mobile",
                    Profil = "Licence",
                    Poste = "Développeur Mobile",
                    Remuneration = 12000
                },
                new Offres
                {
                    Id = 5,
                    IdRecruteur = 105,
                    TypeContrat = "CDI",
                    Secteur = "Gestion de projets IT",
                    Profil = "Master",
                    Poste = "Chef de Projet IT",
                    Remuneration = 25000
                }
            );
        }

    }
}
