using System;
using Hospital.Services;

namespace Hospital
{
    public class Menu
    {
        private readonly DoctorService _doctorService;
        private readonly PatientService _patientService;
        private readonly AppointmentService _appointmentService;

        public Menu(DoctorService doctorService, PatientService patientService, AppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _appointmentService = appointmentService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hospital - Doctors & Patients\n");
                Console.WriteLine("1. Manage Doctors");
                Console.WriteLine("2. Manage Patients");
                Console.WriteLine("3. Manage Appointments");
                Console.WriteLine("0. Exit");
                Console.Write("Select: ");
                var key = Console.ReadLine();
                try
                {
                    switch (key)
                    {
                        case "1": ManageDoctors(); break;
                        case "2": ManagePatients(); break;
                        case "3": ManageAppointments(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid option"); Pause(); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Pause();
                }
            }
        }

        private void ManageDoctors()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Doctors\n1. Add\n2. Edit\n3. List all\n4. Filter by specialty\n0. Back");
                Console.Write("Select: ");
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1": _doctorService.CreateInteractive(); break;
                    case "2": _doctorService.EditInteractive(); break;
                    case "3": _doctorService.ListAll(); break;
                    case "4": _doctorService.ListBySpecialty(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid"); Pause(); break;
                }
            }
        }

        private void ManagePatients()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Patients\n1. Add\n2. Edit\n3. List all\n0. Back");
                Console.Write("Select: ");
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1": _patientService.CreateInteractive(); break;
                    case "2": _patientService.EditInteractive(); break;
                    case "3": _patientService.ListAll(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid"); Pause(); break;
                }
            }
        }

        private void ManageAppointments()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Appointments\n1. Schedule\n2. Cancel\n3. Mark attended\n4. List by patient\n5. List by doctor\n0. Back");
                Console.Write("Select: ");
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1": _appointmentService.ScheduleInteractive(); break;
                    case "2": _appointmentService.CancelInteractive(); break;
                    case "3": _appointmentService.MarkAttendedInteractive(); break;
                    case "4": _appointmentService.ListByPatientInteractive(); break;
                    case "5": _appointmentService.ListByDoctorInteractive(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid"); Pause(); break;
                }
            }
        }

        private void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
