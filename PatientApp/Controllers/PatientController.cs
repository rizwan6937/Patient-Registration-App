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

    [HttpPost]
    public async Task<IActionResult> PostPatient(Patient patient)
    {
        await _patientRepository.PostPatientAsync(patient);
        //return Ok();
        return CreatedAtAction(nameof(GetPatientById), new { Id = patient.PatientId }, patient);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> PutPatient(int Id, Patient updatedPatient)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(Id);

        if (patient == null)
            return NotFound();

        // Update properties of the patient

        await _patientRepository.PutPatientAsync(updatedPatient);
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

