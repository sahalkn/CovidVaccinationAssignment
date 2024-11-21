using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CovidVaccinationPatientDetailsSystem.Models
{
    public class PatientDto
    {
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime VaccinationDate { get; set; }

        [ForeignKey("Vaccination")]
        public int VaccinationId { get; set; }
    }
}
