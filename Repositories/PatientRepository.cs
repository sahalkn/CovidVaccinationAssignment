using CovidVaccinationPatientDetailsSystem.Data;
using CovidVaccinationPatientDetailsSystem.Models;
using Microsoft.EntityFrameworkCore;
using static CovidVaccinationPatientDetailsSystem.Repositories.IRepository;

namespace CovidVaccinationPatientDetailsSystem.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly CovidContext _context;

        public PatientRepository(CovidContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.Include(p => p.Vaccination).ToListAsync();
        }
        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.Include(p => p.Vaccination)
                                          .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Add a new patient along with their vaccination ID
        public async Task AddAsync(Patient entity)
        {
            // Ensure that we are not adding a new vaccination here, but only linking by VaccinationId
            _context.Patients.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Patient entity)
        {
            _context.Patients.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Delete a patient by ID
        public async Task DeleteAsync(int id)
        {
            var patient = await GetByIdAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
