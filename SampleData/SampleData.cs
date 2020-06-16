using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab11.Models;

namespace lab11.SampleData
{
    public class SampleData
    {
        public static void CreateSampleData(DoctorsDbContext dbContext)
        {
            var medicaments = Medicaments();
            var doctors = Doctors();
            var patients = Patients();
            var prescriptions = Prescriptions(doctors, patients);
            var prescriptionMedicaments = PrescriptionMedicaments(prescriptions, medicaments);

            dbContext.AddRange(medicaments);
            dbContext.AddRange(doctors);
            dbContext.AddRange(patients);
            dbContext.AddRange(prescriptions);
            dbContext.AddRange(prescriptionMedicaments);
            dbContext.SaveChanges();
        }

        private static List<PrescriptionMedicament> PrescriptionMedicaments(List<Prescription> prescriptions, List<Medicament> medicaments)
        {
            return new List<PrescriptionMedicament>()
            {
                new PrescriptionMedicament()
                {
                    Prescription = prescriptions[0],
                    Medicament = medicaments[0],
                    Details = "rano i wieczorem",
                    Dose = 2
                },
                new PrescriptionMedicament()
                {
                    Prescription = prescriptions[0],
                    Medicament = medicaments[1],
                    Details = "po posilku",
                },
                new PrescriptionMedicament()
                {
                    Prescription = prescriptions[1],
                    Medicament = medicaments[1],
                    Details = "rano",
                    Dose = 1
                },
                new PrescriptionMedicament()
                {
                    Prescription = prescriptions[2],
                    Medicament = medicaments[0],
                    Details = "na czczo",
                    Dose = 1
                }

            };
        }

        private static List<Medicament> Medicaments()
        {
            return new List<Medicament>
            {
                new Medicament()
                {
                    Description = "lek przeciwbolowy",
                    Name = "Apap",
                    Type = "przeciwbolowy"
                },
                new Medicament()
                {
                    Description = "lek przeciwgoraczkowy o silnym dzialaniu",
                    Name = "Nurofen Forte",
                    Type = "przeciwgoraczkowy"
                }
            };
        }

        private static List<Prescription> Prescriptions(List<Doctor> doctors, List<Patient> patients)
        {
            return new List<Prescription>
            {
                new Prescription()
                {
                    Date = new DateTime(2020, 5, 16),
                    Doctor = doctors[0],
                    DueDate = new DateTime(2020, 11, 16),
                    Patient = patients[0]
                },
                new Prescription()
                {
                    Date = new DateTime(2020, 5, 16),
                    Doctor = doctors[1],
                    DueDate = new DateTime(2020, 11, 16),
                    Patient = patients[1]
                },

                new Prescription()
                {
                    Date = new DateTime(2020, 5, 17),
                    Doctor = doctors[1],
                    DueDate = new DateTime(2020, 11, 17),
                    Patient = patients[2]
                }
            };
        }

        private static List<Patient> Patients()
        {
            return new List<Patient>
            {
                new Patient()
                {
                    FirstName = "Piotr",
                    LastName = "Kowalewski",
                    BirthDate = new DateTime(1989, 11, 13)
                },
                new Patient()
                {
                    FirstName = "Katarzyna",
                    LastName = "Kowalewska",
                    BirthDate = new DateTime(1990, 1, 1)
                },
                new Patient()
                {
                    FirstName = "Maciej",
                    LastName = "Kowalewski",
                    BirthDate = new DateTime(2015, 2, 21)
                }
            };
        }

        private static List<Doctor> Doctors()
        {
            return new List<Doctor>
            {
                new Doctor()
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jankowalski@gmail.com"
                },
                new Doctor()
                {
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Email = "annanowak@gmail.com"
                }
            };
        }
    }
}