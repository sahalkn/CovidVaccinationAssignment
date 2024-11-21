using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CovidVaccinationPatientDetailsSystem.Models
{
    public class Vaccination
    {
        [Key]
        public int VaccinationId { get; set; }
        [Required]
        public required string VaccineName { get; set; }
    }
}
