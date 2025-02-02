using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Recrutement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidatUserIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidats",
                columns: new[] { "IdCandidat", "Age", "AspNetUserId", "CV", "Diplome", "Email", "IdUser", "Nom", "NombreAnneeExperience", "Prenom", "Titre" },
                values: new object[,]
                {
                    { 1, 28, "174a3829-5c06-4be5-b6f0-8fd390a590c9", "cv_ahmed_benali.pdf", "Master", "Candidat@gmail.com", null, "Ahmed", 0, "Benali", "Développeur Full Stack" },
                    { 2, 25, "febd6dc0-5962-49be-bd03-7fa584e9bbec", "cv_fatima_elamrani.pdf", "Ingénieur", "Candidat1@gmail.com", null, "Fatima", 0, "El Amrani", "Ingénieur en Cybersécurité" }
                });

            migrationBuilder.InsertData(
                table: "Candidatures",
                columns: new[] { "Id", "DatePostulation", "IdCandidat", "IdOffre", "Statut" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "En attente" },
                    { 2, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Acceptée" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidatures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidatures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candidats",
                keyColumn: "IdCandidat",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidats",
                keyColumn: "IdCandidat",
                keyValue: 2);
        }
    }
}
