using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab11.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab11.Services
{
    public interface IDoctorsDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        void AddDoctor(Doctor doctor);
        void DeleteDoctor(int id);
        void UpdateDoctor(int id, Doctor doctor);
    }
}
