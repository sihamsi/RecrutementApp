using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Recrutement.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Candidats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Candidatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidat = table.Column<int>(type: "int", nullable: false),
                    IdOffre = table.Column<int>(type: "int", nullable: false),
                    DatePostulation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidatIdCandidat = table.Column<int>(type: "int", nullable: false),
                    OffreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatures_Candidats_CandidatIdCandidat",
                        column: x => x.CandidatIdCandidat,
                        principalTable: "Candidats",
                        principalColumn: "IdCandidat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidatures_Offres_OffreId",
                        column: x => x.OffreId,
                        principalTable: "Offres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_CandidatIdCandidat",
                table: "Candidatures",
                column: "CandidatIdCandidat");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatures_OffreId",
                table: "Candidatures",
                column: "OffreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatures");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Candidats");
        }
    }
}
