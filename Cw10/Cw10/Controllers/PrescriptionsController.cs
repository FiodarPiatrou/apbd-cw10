using Cw10.DTO;
using Cw10.Models;
using Cw10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController:ControllerBase
{
    private readonly IDbService _dbService;
    public PrescriptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    [HttpPut()]
    public async Task<IActionResult> PutNewPrescription(PrescriptionDTO prescription)
    {
        if (!await _dbService.DoesMedicamentExist(prescription.Medicaments))
        {
            return NotFound($"Medication does not exist");
        }

        if (!await _dbService.DoesPatientExist(prescription.IdPatient))
        {
           await _dbService.AddPatient(prescription.Patient);
        }

        if (prescription.Medicaments.Count>10)
        {
            return BadRequest("To many medications");
        }

        if (prescription.Date>=prescription.DueDate)
        {
            return BadRequest("DueDate is before or equal Date");
        }

        await _dbService.AddPrescription(prescription);
        return Created();
    }
}