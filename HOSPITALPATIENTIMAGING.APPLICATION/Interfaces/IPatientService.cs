using HOSPITALPATIENTIMAGING.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITALPATIENTIMAGING.APPLICATION.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsList();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(Patient patient);
    }
}
