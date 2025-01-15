using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Recrutement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatures_Candidats_CandidatIdCandidat",
                table: "Candidatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidatures_Offres_OffreId",
                table: "Candidatures");

            migrationBuilder.DropIndex(
                name: "IX_Candidatures_CandidatIdCandidat",
                table: "Candidatures");

            migrationBuilder.DropIndex(
                name: "IX_Candidatures_OffreId",
                table: "Candidatures");

            migrationBuilder.DropColumn(
                name: "CandidatIdCandidat",
                table: "Candidatures");

            migrationBuilder.DropColumn(
                name: "OffreId",
                table: "Candidatures");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_IdCandidat",
                table: "Candidatures",
                column: "IdCandidat");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_IdOffre",
                table: "Candidatures",
                column: "IdOffre");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatures_Candidats_IdCandidat",
                table: "Candidatures",
                column: "IdCandidat",
                principalTable: "Candidats",
                principalColumn: "IdCandidat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatures_Offres_IdOffre",
                table: "Candidatures",
                column: "IdOffre",
                principalTable: "Offres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatures_Candidats_IdCandidat",
                table: "Candidatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidatures_Offres_IdOffre",
                table: "Candidatures");

            migrationBuilder.DropIndex(
                name: "IX_Candidatures_IdCandidat",
                table: "Candidatures");

            migrationBuilder.DropIndex(
                name: "IX_Candidatures_IdOffre",
                table: "Candidatures");

            migrationBuilder.AddColumn<int>(
                name: "CandidatIdCandidat",
                table: "Candidatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OffreId",
                table: "Candidatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_CandidatIdCandidat",
                table: "Candidatures",
                column: "CandidatIdCandidat");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_OffreId",
                table: "Candidatures",
                column: "OffreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatures_Candidats_CandidatIdCandidat",
                table: "Candidatures",
                column: "CandidatIdCandidat",
                principalTable: "Candidats",
                principalColumn: "IdCandidat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatures_Offres_OffreId",
                table: "Candidatures",
                column: "OffreId",
                principalTable: "Offres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
