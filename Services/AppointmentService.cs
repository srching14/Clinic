using System;
using System.Linq;
using Hospital.Domain;
using Hospital.Repositories;
using Hospital.Utils;

namespace Hospital.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IPatientRepository _patientRepo;
        private readonly EmailService _emailService;

        public AppointmentService(IAppointmentRepository repo, IDoctorRepository doctorRepo, IPatientRepository patientRepo, EmailService emailService)
        {
            _repo = repo;
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
            _emailService = emailService;
        }

        public void ScheduleInteractive()
        {
            Console.Write("Patient document: "); var pdoc = Console.ReadLine() ?? "";
            var patient = _patientRepo.GetByDocument(pdoc);
            if (patient == null) { Console.WriteLine("Patient not found."); Console.ReadLine(); return; }

            Console.Write("Doctor document: "); var ddoc = Console.ReadLine() ?? "";
            var doctor = _doctorRepo.GetByDocument(ddoc);
            if (doctor == null) { Console.WriteLine("Doctor not found."); Console.ReadLine(); return; }

            Console.Write("Date and time (YYYY-MM-DD HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var when)) { Console.WriteLine("Invalid datetime"); Console.ReadLine(); return; }

            if (_repo.ExistsConflictForDoctor(doctor.Id, when)) { Console.WriteLine("Doctor has a conflict at that time."); Console.ReadLine(); return; }
            if (_repo.ExistsConflictForPatient(patient.Id, when)) { Console.WriteLine("Patient has a conflict at that time."); Console.ReadLine(); return; }

            var ap = new Appointment { DoctorId = doctor.Id, PatientId = patient.Id, When = when };
            _repo.Add(ap);

            // send confirmation email
            try
            {
                string subject = $"Appointment Confirmation - {when:yyyy-MM-dd HH:mm}";
                string body = $@"Dear {patient.Name},

Your appointment has been successfully scheduled.

Details:
- Date: {when:dddd, MMMM dd, yyyy}
- Time: {when:HH:mm}
- Doctor: Dr. {doctor.Name}
- Specialty: {doctor.Specialty}

Location: Hospital Medical Center
Please arrive 15 minutes before your appointment.

If you need to reschedule or cancel your appointment, please contact us.

Best regards,
Hospital Medical Center";

                _emailService.SendEmailWithAdminCopy(patient.Email, subject, body);
                ap.EmailSentStatus = "sent";
            }
            catch
            {
                ap.EmailSentStatus = "not sent";
            }
            _repo.Update(ap);
            Console.WriteLine("Appointment scheduled."); Console.ReadLine();
        }

        public void CancelInteractive()
        {
            Console.Write("Appointment id: "); if (!Guid.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("Invalid id"); Console.ReadLine(); return; }
            var a = _repo.GetById(id);
            if (a == null) { Console.WriteLine("Not found"); Console.ReadLine(); return; }
            a.Status = AppointmentStatus.Cancelled;
            _repo.Update(a);
            Console.WriteLine("Cancelled."); Console.ReadLine();
        }

        public void MarkAttendedInteractive()
        {
            Console.Write("Appointment id: "); if (!Guid.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("Invalid id"); Console.ReadLine(); return; }
            var a = _repo.GetById(id);
            if (a == null) { Console.WriteLine("Not found"); Console.ReadLine(); return; }
            a.Status = AppointmentStatus.Attended;
            _repo.Update(a);
            Console.WriteLine("Marked attended."); Console.ReadLine();
        }

        public void ListByPatientInteractive()
        {
            Console.Write("Patient document: "); var doc = Console.ReadLine() ?? "";
            var p = _patientRepo.GetByDocument(doc);
            if (p == null) { Console.WriteLine("Patient not found"); Console.ReadLine(); return; }
            var list = _repo.GetByPatient(p.Id).ToList();
            Console.WriteLine($"Appointments ({list.Count}) for {p.Name}:");
            foreach (var a in list) Console.WriteLine($"{a.Id} | {a.When:yyyy-MM-dd HH:mm} | {a.Status} | Email: {a.EmailSentStatus}");
            Console.ReadLine();
        }

        public void ListByDoctorInteractive()
        {
            Console.Write("Doctor document: "); var doc = Console.ReadLine() ?? "";
            var d = _doctorRepo.GetByDocument(doc);
            if (d == null) { Console.WriteLine("Doctor not found"); Console.ReadLine(); return; }
            var list = _repo.GetByDoctor(d.Id).ToList();
            Console.WriteLine($"Appointments ({list.Count}) for Dr. {d.Name}:");
            foreach (var a in list) Console.WriteLine($"{a.Id} | {a.When:yyyy-MM-dd HH:mm} | {a.Status} | Email: {a.EmailSentStatus}");
            Console.ReadLine();
        }
    }
}
