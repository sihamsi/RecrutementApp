using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Recrutement.Migrations
{
    /// <inheritdoc />
    public partial class UpdtAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Candidats",
                keyColumn: "IdCandidat",
                keyValue: 1,
                columns: new[] { "AspNetUserId", "Email" },
                values: new object[] { "41b7e077-2d75-4568-b3a5-5d494f40b129", "Candidat22@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Candidats",
                keyColumn: "IdCandidat",
                keyValue: 1,
                columns: new[] { "AspNetUserId", "Email" },
                values: new object[] { "174a3829-5c06-4be5-b6f0-8fd390a590c9", "Candidat@gmail.com" });
        }
    }
}
