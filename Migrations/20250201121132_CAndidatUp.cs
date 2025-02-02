using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Recrutement.Migrations
{
    /// <inheritdoc />
    public partial class CAndidatUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Candidats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Candidats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
