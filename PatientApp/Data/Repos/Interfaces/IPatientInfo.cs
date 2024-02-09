using PatientApp.Data.Models;

namespace PatientApp.Data.Repos.Interfaces
{
    public interface IPatientInfo
    {
        Task<IEnumerable<Patient>> GetPatientAllAsync();
        Task<Patient> GetPatientByIdAsync(int Id);
        Task PostPatientAsync(Patient patient);
        Task PutPatientAsync(Patient patient);
        Task DeletePatientAsync(int Id);
    }
}
