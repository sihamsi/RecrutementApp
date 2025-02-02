using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Recrutement.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidatureTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Candidats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "Candidats",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Candidats");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Candidats");
        }
    }
}
