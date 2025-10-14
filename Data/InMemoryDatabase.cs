using System;
using System.Collections.Generic;
using Hospital.Domain;

namespace Hospital.Repositories
{
    public class InMemoryDatabase
    {
        public List<Doctor> Doctors { get; set; } = new();
        public List<Patient> Patients { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
    }
}
