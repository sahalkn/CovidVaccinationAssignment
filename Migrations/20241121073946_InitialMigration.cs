using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidVaccinationPatientDetailsSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Patients_PatientId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_PatientId",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "VaccinationDate",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "IsVaccinated",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vaccinations",
                newName: "VaccinationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "VaccinationDate",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "VaccinationId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_VaccinationId",
                table: "Patients",
                column: "VaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Vaccinations_VaccinationId",
                table: "Patients",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Vaccinations_VaccinationId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_VaccinationId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "VaccinationDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "VaccinationId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "VaccinationId",
                table: "Vaccinations",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Vaccinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "VaccinationDate",
                table: "Vaccinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsVaccinated",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_PatientId",
                table: "Vaccinations",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Patients_PatientId",
                table: "Vaccinations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
