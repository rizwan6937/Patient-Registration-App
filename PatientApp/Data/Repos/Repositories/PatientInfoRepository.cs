using Microsoft.EntityFrameworkCore;
using PatientApp.Data.Models;
using PatientApp.Data.Repos.Interfaces;

namespace PatientApp.Data.Repos.Repositories
{
    public class PatientInfoRepository : IPatientInfo
    {
        private readonly ApplicationDbContext _context;

        public PatientInfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatientAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int Id)
        {
            return await _context.Patients.FindAsync(Id);
        }

        public async Task<IEnumerable<Patient>> GetPatientBySearchTextAsync(string search)
        {
            var query = _context.Patients.AsEnumerable();
            

            // Apply filtering based on search criteria
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.Name.ToLower().Contains(search.ToLower()));
                //query = query.Where(m => m.Gender.Contains(search));
            }

            return query.ToList();
        }

        public async Task PostPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task PutPatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            //_context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int Id)
        {
            var patient = await _context.Patients.FindAsync(Id);

            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
