﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab11.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescription { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [ForeignKey("Doctor")]
        public int IdDoctor { get; set; }

        public Doctor Doctor{ get; set; }

        [ForeignKey("Patient")]
        public int IdPatient { get; set; }

        public Patient Patient { get; set; }

        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    }
}
