using CovidVaccinationPatientDetailsSystem.Data;
using CovidVaccinationPatientDetailsSystem.Models;
using Microsoft.EntityFrameworkCore;
using static CovidVaccinationPatientDetailsSystem.Repositories.IRepository;

namespace CovidVaccinationPatientDetailsSystem.Repositories
{
    public class VaccinationRepository : IRepository<Vaccination>
    {
        private readonly CovidContext _context;

        public VaccinationRepository(CovidContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vaccination>> GetAllAsync()
        {
            return await _context.Vaccinations.ToListAsync();
        }

        public async Task<Vaccination> GetByIdAsync(int id)
        {
            return await _context.Vaccinations.FindAsync(id);
        }

        public async Task AddAsync(Vaccination entity)
        {
            await _context.Vaccinations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vaccination entity)
        {
            _context.Vaccinations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vaccination = await _context.Vaccinations.FindAsync(id);
            if (vaccination != null)
            {
                _context.Vaccinations.Remove(vaccination);
                await _context.SaveChangesAsync();
            }
        }
    }
}
