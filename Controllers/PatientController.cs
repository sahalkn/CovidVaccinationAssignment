using CovidVaccinationPatientDetailsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static CovidVaccinationPatientDetailsSystem.Repositories.IRepository;

namespace CovidVaccinationPatientDetailsSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController: ControllerBase
    {
        private readonly IRepository<Patient> _repository;

        public PatientController(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetPatientDetails")]
        public async Task<IActionResult> GetPatientDetails()
        {
            var patients = await _repository.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("GetPatientDetailsById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            return patient == null ? NotFound() : Ok(patient);
        }
        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
        {
            if (ModelState.IsValid)
            {
                var patient= new Patient
                {
                    Name = patientDto.Name,
                    Email = patientDto.Email,
                    DateOfBirth = patientDto.DateOfBirth,
                    VaccinationDate= patientDto.VaccinationDate,
                    VaccinationId= patientDto.VaccinationId,
                };
                if (patient.VaccinationId <= 0)
                {
                    return BadRequest("Invalid VaccinationId.");
                }
                await _repository.AddAsync(patient);
                return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("UpdatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            var patient = new Patient
            {
                Id = id,
                Name = patientDto.Name,
                Email = patientDto.Email,
                DateOfBirth = patientDto.DateOfBirth,
                VaccinationDate = patientDto.VaccinationDate,
                VaccinationId = patientDto.VaccinationId,
            };
            await _repository.UpdateAsync(patient);
            return NoContent();
        }

        [HttpDelete("DeletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
