using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidVaccinationPatientDetailsSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVaccinationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VaccinationId1",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_VaccinationId1",
                table: "Patients",
                column: "VaccinationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Vaccinations_VaccinationId1",
                table: "Patients",
                column: "VaccinationId1",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Vaccinations_VaccinationId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_VaccinationId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "VaccinationId1",
                table: "Patients");
        }
    }
}
