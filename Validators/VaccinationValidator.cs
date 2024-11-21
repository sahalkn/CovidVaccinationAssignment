using CovidVaccinationPatientDetailsSystem.Models;
using FluentValidation;

namespace CovidVaccinationPatientDetailsSystem.Validators
{
    public class VaccinationValidator: AbstractValidator<Vaccination> 
    {
        public VaccinationValidator()
        {
            RuleFor(p => p.VaccineName).NotEmpty().WithMessage("VaccineName is required.");
        }
    }
    
}
