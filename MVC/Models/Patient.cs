
namespace MVC.Models
{
    public class Patient
    {
        public Patient()
        {
            Visits = new List<Visit>();
            Diseases = new List<Disease>();
            Doctors = new List<Doctor>();
        }
        public int PatientId { get; set; }
       
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public string Gender { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Navigation property for visits
        public ICollection<Visit> Visits { get; set; } 

        public ICollection<Disease> Diseases { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
