using System;
using Hospital.Domain;
using Hospital.Repositories;
using Hospital.Services;
using Hospital.Utils;

namespace Hospital
{
    class Program
    {
        static void Main()
        {
            var db = new InMemoryDatabase();
            var doctorRepo = new DoctorRepository(db);
            var patientRepo = new PatientRepository(db);
            var appointmentRepo = new AppointmentRepository(db);
            var emailService = new EmailService();
            var doctorService = new DoctorService(doctorRepo);
            var patientService = new PatientService(patientRepo);
            var appointmentService = new AppointmentService(appointmentRepo, doctorRepo, patientRepo, emailService);

            var menu = new Menu(doctorService, patientService, appointmentService);
            menu.Run();
        }
    }
}
