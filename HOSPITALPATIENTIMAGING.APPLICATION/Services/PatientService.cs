using HOSPITALPATIENTIMAGING.APPLICATION.Interfaces;
using HOSPITALPATIENTIMAGING.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITALPATIENTIMAGING.APPLICATION.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalPatientImagingContext _context;
        public PatientService(HospitalPatientImagingContext context)
        {
            _context = context;
        }
        public async Task<Patient> CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patients
             .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<Patient>> GetPatientsList()
        {
            //TODO add pagination
            return await _context.Patients
           .ToListAsync();
        }

        public async Task UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
