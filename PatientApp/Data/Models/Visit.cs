namespace PatientApp.Data.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public DateTime VisitDateTime { get; set; }

        // Foreign key to connect with Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
