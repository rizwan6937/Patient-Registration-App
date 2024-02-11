using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientApp.Data.Models;
using PatientApp.Data.Repos.Interfaces;

// PatientController.cs

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientInfo _patientRepository;

    public PatientController(IPatientInfo patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatient()
    {
        var patients = await _patientRepository.GetPatientAllAsync();
        return Ok(patients);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetPatientById(int Id)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(Id);

        if (patient == null)
            return NotFound();

        return Ok(patient);
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetPatientBySearchText(string search)
    {
        var patient = await _patientRepository.GetPatientBySearchTextAsync(search);

        if (patient == null)
            return NotFound();

        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> PostPatient(Patient patient)
    {
        await _patientRepository.PostPatientAsync(patient);
        return Ok(patient);
        //return CreatedAtAction(nameof(GetPatientById), new { Id = patient.PatientId }, patient);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> PutPatient(int Id, Patient updatedPatient)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(Id);

        if (patient == null)
            return NotFound();

        // Update properties of the patient
        patient.Name = updatedPatient.Name;
        patient.Age = updatedPatient.Age;
        patient.Gender = updatedPatient.Gender;
        patient.PhoneNumber = updatedPatient.PhoneNumber;
        patient.Address = updatedPatient.Address;


    await _patientRepository.PutPatientAsync(patient);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeletePatient(int Id)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(Id);

        if (patient == null)
            return NotFound();

        await _patientRepository.DeletePatientAsync(Id);
        return NoContent();
    }
}

