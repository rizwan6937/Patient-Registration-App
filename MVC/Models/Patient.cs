
namespace MVC.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
       
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public string Gender { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Navigation property for visits
        public List<Visit> Visits { get; set; }

        public List<Disease> Diseases { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
