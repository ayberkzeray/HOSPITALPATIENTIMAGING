using Microsoft.EntityFrameworkCore;

namespace HOSPITALPATIENTIMAGING.DATA.Models
{
    public class HospitalPatientImagingContext : DbContext
    {
        public HospitalPatientImagingContext()
        {

        }
        public HospitalPatientImagingContext(DbContextOptions<HospitalPatientImagingContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<Gender>().ToTable("Gender");
        }
    }
}
