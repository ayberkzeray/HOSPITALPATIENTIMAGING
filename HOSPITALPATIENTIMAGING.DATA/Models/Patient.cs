using System.ComponentModel.DataAnnotations;

namespace HOSPITALPATIENTIMAGING.DATA.Models
{
    public class Patient
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(4)]
        public int PoliclinicCode { get; set; }
        [Required]       
        public int DoctorID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public int GenderID { get; set; }
        [Required]
        [MaxLength(11)]
        public long IdentificationNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public int Phone { get; set; }       
        [Required]
        public string VisitDate { get; set; }
        public string ScheduledVisitDate { get; set; }
        [MaxLength(1000)]
        public string PatientNote{ get; set; }
        
        
      
        public virtual Doctor Doctor { get; set; }
        public virtual Gender Gender { get; set; }

    }
}
