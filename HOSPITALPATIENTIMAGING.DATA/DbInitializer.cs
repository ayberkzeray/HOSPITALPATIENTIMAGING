using HOSPITALPATIENTIMAGING.DATA.Models;
using System.Linq;

namespace HOSPITALPATIENTIMAGING.DATA
{
    public static class DbInitializer
    {
        public static void Initialize(HospitalPatientImagingContext context)
        {
            context.Database.EnsureCreated();

            if (context.Doctors.Any())
            {
                return;
            }

            var doctors = new Doctor[]
            {
                new Doctor{ FirstName="Can", LastName= "Uzun",  RegistrationNumber= 12345678},
                new Doctor{ FirstName="Atakan", LastName= "Çetin",  RegistrationNumber= 12345679},
            };

            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();

            if (context.Genders.Any())
            {
                return;
            }

            var genders = new Gender[]
            {
                new Gender{ Name="Erkek"},
                new Gender{ Name="Kadın"},
                new Gender{ Name="Diğer"},
            };

            foreach (Gender g in genders)
            {
                context.Genders.Add(g);
            }
            context.SaveChanges();
        }
    }
}
