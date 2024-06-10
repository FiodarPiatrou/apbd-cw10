using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Models;

[Table("Prescription_Medication")]
[PrimaryKey(nameof(IdMedication), nameof(IdPrescription))]
public class PrescriptionMedicament
{
    [ForeignKey(nameof(IdPrescription))] 
    public int IdPrescription { get; set; }
    [ForeignKey(nameof(IdMedication))] 
    public int IdMedication { get; set; }

    public int? Dose { get; set; }
    [MaxLength(100)] 
    public string Details { get; set; } = string.Empty;
}