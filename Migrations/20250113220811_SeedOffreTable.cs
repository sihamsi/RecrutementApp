using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Recrutement.Migrations
{
    /// <inheritdoc />
    public partial class SeedOffreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Offres",
                columns: new[] { "Id", "IdRecruteur", "Poste", "Profil", "Remuneration", "Secteur", "TypeContrat" },
                values: new object[,]
                {
                    { 1, 101, "Développeur Full Stack", "Ingénieur", 20000, "Développement logiciel", "CDI" },
                    { 2, 102, "Data Analyst", "Master", 15000, "Analyse de données", "CDD" },
                    { 3, 103, "Spécialiste en Sécurité Informatique", "Ingénieur", 18000, "Cybersécurité", "CDI" },
                    { 4, 104, "Développeur Mobile", "Licence", 12000, "Développement mobile", "Freelance" },
                    { 5, 105, "Chef de Projet IT", "Master", 25000, "Gestion de projets IT", "CDI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offres",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
