using System;
using System.Collections.Generic;

namespace Hospital.Domain
{
    public enum AppointmentStatus { Scheduled, Cancelled, Attended }

    public class Doctor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty; // unique
        public string Specialty { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty; // unique
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

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
