using CovidVaccinationPatientDetailsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using static CovidVaccinationPatientDetailsSystem.Repositories.IRepository;

namespace CovidVaccinationPatientDetailsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private readonly IRepository<Vaccination> _vaccinationRepository;

        public VaccinationController(IRepository<Vaccination> vaccinationRepository)
        {
            _vaccinationRepository = vaccinationRepository;
        }
        [HttpGet ("GetVaccinations")]
        public async Task<IActionResult> GetVaccinations()
        {
            var vaccinations = await _vaccinationRepository.GetAllAsync();
            return Ok(vaccinations);
        }
        [HttpGet("GetVaccinationsById/{id}")]
        public async Task<IActionResult> GetVaccinationsById(int id)
        {
            var vaccination = await _vaccinationRepository.GetByIdAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }
            return Ok(vaccination);
        }
        [HttpPost("CreateVaccination")]
        public async Task<IActionResult> CreateVaccination(CreateVaccinationDto vaccinationDto)
        {
            if (ModelState.IsValid)
            {
                var vaccination = new Vaccination
                {
                    VaccineName = vaccinationDto.VaccineName
                };
                await _vaccinationRepository.AddAsync(vaccination);
                return CreatedAtAction(nameof(GetVaccinationsById), new { id = vaccination.VaccinationId }, vaccination);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("UpdateVaccination/{id}")]
        public async Task<IActionResult> UpdateVaccination(int id, string name)
        {
            var existingVaccination = await _vaccinationRepository.GetByIdAsync(id);
            if (existingVaccination == null)
            {
                return NotFound();
            }
            existingVaccination.VaccineName = name;

            await _vaccinationRepository.UpdateAsync(existingVaccination);
            return NoContent();
        }

        [HttpDelete("DeleteVaccination/{id}")]
        public async Task<IActionResult> DeleteVaccination(int id)
        {
            var vaccination = await _vaccinationRepository.GetByIdAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }

            await _vaccinationRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
