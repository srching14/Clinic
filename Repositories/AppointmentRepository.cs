using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Domain;

namespace Hospital.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly InMemoryDatabase _db;
        public AppointmentRepository(InMemoryDatabase db) => _db = db;

        public Appointment Add(Appointment entity)
        {
            _db.Appointments.Add(entity);
            return entity;
        }

        public void Update(Appointment entity)
        {
            var idx = _db.Appointments.FindIndex(a => a.Id == entity.Id);
            if (idx >= 0) _db.Appointments[idx] = entity;
        }

        public void Delete(Guid id)
        {
            var item = GetById(id);
            if (item != null) _db.Appointments.Remove(item);
        }

        public Appointment? GetById(Guid id) => _db.Appointments.FirstOrDefault(a => a.Id == id);

        public IEnumerable<Appointment> GetAll() => _db.Appointments;

        public IEnumerable<Appointment> GetByDoctor(Guid doctorId) => _db.Appointments.Where(a => a.DoctorId == doctorId);

        public IEnumerable<Appointment> GetByPatient(Guid patientId) => _db.Appointments.Where(a => a.PatientId == patientId);

        public bool ExistsConflictForDoctor(Guid doctorId, DateTime when)
            => _db.Appointments.Any(a => a.DoctorId == doctorId && a.When == when && a.Status == AppointmentStatus.Scheduled);

        public bool ExistsConflictForPatient(Guid patientId, DateTime when)
            => _db.Appointments.Any(a => a.PatientId == patientId && a.When == when && a.Status == AppointmentStatus.Scheduled);
    }
}
