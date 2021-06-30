using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITALPATIENTIMAGING.DATA.Models
{
    public class Gender
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
