using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab11.Models
{
    [Table("Prescription_Medicament")]
    public class PrescriptionMedicament
    {
        [ForeignKey("Medicament")]
        public int IdMedicament { get; set; }

        public Medicament Medicament { get; set; }

        [ForeignKey("Prescription")]
        public int IdPrescription { get; set; }

        public Prescription Prescription { get; set; }

        public int? Dose { get; set; }

        [MaxLength(100)]
        public string Details { get; set; }

    }
}
