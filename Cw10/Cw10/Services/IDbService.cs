using Cw10.DTO;
using Cw10.Models;

namespace Cw10.Services;

public interface IDbService
{
    Task<bool> DoesMedicamentExist(ICollection<MedicamentDTO> medicaments);
    Task<bool> DoesPatientExist(int idPatient);
    Task AddPrescription(PrescriptionDTO prescription);
    Task AddPatient(Patient prescriptionPatient);
}