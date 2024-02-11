namespace MVC.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }

        // Foreign key to connect with Patient
        public int PatientId { get; set; }
        //public Patient Patient { get; set; }
    }
}
