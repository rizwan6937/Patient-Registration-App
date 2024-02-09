using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MVC.Controllers
{
    public class PatientController : Controller
    {
       
        public async Task<ActionResult> Index()
        {
            IEnumerable<Patient> patientList;
            HttpResponseMessage response = await GlobalModel.client.GetAsync("Patient");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                patientList = JsonConvert.DeserializeObject<IEnumerable<Patient>>(responseBody);
            }
            else
            {
                    return View("Home/Error");
            }
            return View(patientList);
        }

        public async Task<ActionResult> AddOrEditPatient(int Id = 0)
        {
            if (Id==0)
            {
                return View(new Patient());
            }
            else
            {
                HttpResponseMessage response = await GlobalModel.client.GetAsync("Patient/"+Id.ToString()); 
                var responseBody = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Patient>(responseBody);
                return View(model);
            }
            
        }
        [HttpPost]
        public async Task<ActionResult> AddOrEditPatient(Patient model)
        {
            //var json = JsonConvert.SerializeObject(model);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (model.PatientId == 0)
            {

                HttpResponseMessage response = await GlobalModel.client.PostAsJsonAsync("Patient", model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                HttpResponseMessage response = await GlobalModel.client.PutAsJsonAsync("Patient/" + model.PatientId, model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("AddOrEditPatient");

        }

        public IActionResult AddPatientVisit(int Id)
        {
            // Adding in DB logic here
            // Add Patient visit along with Id
            Visit visit = new Visit()
            {
                PatientId = Id,
                VisitDateTime = DateTime.Now
            };
            // Save this object (visit) in database
            return RedirectToAction("Index");
        }

        public IActionResult AddPatientDisease(int Id)
        {
            // Adding in DB logic here
            // Add Patient Disease along with Id
            Disease disease = new Disease()
            {
                DiseaseName = "ABC",
                PatientId= Id
            };
            // Save this object (disease) in database
            return RedirectToAction("Index");
        }

        public IActionResult AddPatientDoctor(int Id)
        {
            // Adding in DB logic here
            // Add Patient Doctor along with Id
            Doctor doctor = new Doctor()
            {
                DoctorName = "XYZ",
                Specialization = "Dentist",
                PatientId = Id
            };

            // Save this object (doctor) in database
            return RedirectToAction("Index");
        }
    }
}
