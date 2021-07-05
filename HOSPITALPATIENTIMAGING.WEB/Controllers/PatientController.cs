using HOSPITALPATIENTIMAGING.APPLICATION.Interfaces;
using HOSPITALPATIENTIMAGING.DATA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOSPITALPATIENTIMAGING.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
        {
            return await _patientService.GetPatientsList();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            var Patient = await _patientService.GetPatientById(id);

            if (Patient == null)
            {
                return NotFound();
            }

            return Ok(Patient);
        }

        // POST: api/Patients
        [HttpPost]
        public async Task<ActionResult<Patient>> Post(Patient Patient)
        {
            await _patientService.CreatePatient(Patient);

            return CreatedAtAction("Post", new { id = Patient.ID }, Patient);
        }

        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Patient Patient)
        {
            if (id != Patient.ID)
            {
                return BadRequest("Not a valid Patient ID");
            }

            await _patientService.UpdatePatient(Patient);

            return NoContent();
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Patient ID");

            var Patient = await _patientService.GetPatientById(id);
            if (Patient == null)
            {
                return NotFound();
            }

            await _patientService.DeletePatient(Patient);

            return NoContent();
        }
    }
}
