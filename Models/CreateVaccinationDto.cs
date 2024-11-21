using System.ComponentModel.DataAnnotations;

namespace CovidVaccinationPatientDetailsSystem.Models
{
    public class CreateVaccinationDto
    {
        [Required]
        public required string VaccineName { get; set; }
    }
}
