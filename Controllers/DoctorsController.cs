using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab11.Models;
using lab11.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab11.Controllers
{
    [Route(("api/doctors"))]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsDbService _service;

        public DoctorsController(IDoctorsDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            try
            {
                _service.AddDoctor(doctor);
                return Ok(doctor);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, Doctor doctor)
        {
            try
            {
                _service.UpdateDoctor(id, doctor);
                return Ok(doctor);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                _service.DeleteDoctor(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}