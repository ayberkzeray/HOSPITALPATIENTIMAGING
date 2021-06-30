using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITALPATIENTIMAGING.DATA.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(8)]
        public int RegistrationNumber { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
