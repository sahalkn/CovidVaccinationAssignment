using CovidVaccinationPatientDetailsSystem.Models;
using FluentValidation;

namespace CovidVaccinationPatientDetailsSystem.Validators
{
    public class PatientValidator: AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
