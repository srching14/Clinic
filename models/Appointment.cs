

namespace HospitalDoctorsPatients.models
{
    public enum AppointmentStatus { Scheduled, Cancelled, Attended }
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime When { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        public string? EmailSentStatus { get; set; } = null; // "sent" or "not sent"  
    }
}