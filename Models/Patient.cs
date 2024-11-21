using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CovidVaccinationPatientDetailsSystem.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime VaccinationDate { get; set; }

        [ForeignKey("Vaccination")]
        public int VaccinationId { get; set; }

        public Vaccination? Vaccination { get; set; }
    }

}
