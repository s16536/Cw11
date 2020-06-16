using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab11.Services
{
    public class EfDoctorsDbService : IDoctorsDbService
    {
        private readonly DoctorsDbContext _context;
        public EfDoctorsDbService(DoctorsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctor.ToList();
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.Doctor.Add(doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {

            var doctor = new Doctor() { IdDoctor= id };
            _context.Doctor.Attach(doctor);
            _context.Doctor.Remove(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(int id, Doctor doctor)
        {
            doctor.IdDoctor = id;
            _context.Doctor.Attach(doctor);
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
