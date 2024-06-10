using Cw10.Data;
using Cw10.DTO;
using Cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Services;

public class DbService:IDbService
{
    private readonly ApplicationContext _context;
    public DbService(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<bool> DoesMedicamentExist(ICollection<MedicamentDTO> medicaments)
    {
        var flag = true;
        foreach (var medicament in medicaments)
        {
            flag = await _context.Medicaments.AnyAsync(m => m.IdMedicament == medicament.IdMedicament);
            if (!flag)
            {
                return flag;
            }
        }

        return flag;
    }

    public async Task<bool> DoesPatientExist(int idPatient)
    {
        return await _context.Patients.AnyAsync(p => p.IdPatient == idPatient);
    }

    public async Task AddPrescription(PrescriptionDTO prescription)
    {
        var newId = _context.Prescriptions.Count() + 1;
        await _context.AddAsync(new Prescription()
        {
            IdPrescription = newId,
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            Doctor = prescription.Doctor,
            Patient = prescription.Patient,
        });

    }
    

    public async Task AddPatient(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
    }
}