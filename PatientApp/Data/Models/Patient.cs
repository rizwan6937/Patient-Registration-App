namespace PatientApp.Data.Models
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
        public ICollection<Visit?> Visits { get; set; } = null;

        public ICollection<Disease?> Diseases { get; set; } = null;

        public ICollection<Doctor?> Doctors { get; set; } = null;
    }
}
