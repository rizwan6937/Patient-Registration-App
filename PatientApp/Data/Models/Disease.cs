namespace PatientApp.Data.Models
{
    public class Disease
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }

        // Foreign key to connect with Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
