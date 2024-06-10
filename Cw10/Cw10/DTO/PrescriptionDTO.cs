using Cw10.Models;

namespace Cw10.DTO;

public class PrescriptionDTO
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    public Patient Patient { get; set; } = null!;
    
    public Doctor Doctor { get; set; } = null!;
    public ICollection<MedicamentDTO> Medicaments { get; set; }
    public int IdPatient { get; set; }
    public string Details { get; set; }
}