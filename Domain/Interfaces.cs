using System;
using System.Collections.Generic;

namespace Hospital.Domain
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T? GetById(Guid id);
        IEnumerable<T> GetAll();
    }

    public interface IDoctorRepository : IRepository<Doctor>
    {
        Doctor? GetByDocument(string doc);
        IEnumerable<Doctor> GetBySpecialty(string specialty);
    }

    public interface IPatientRepository : IRepository<Patient>
    {
        Patient? GetByDocument(string doc);
    }

    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetByDoctor(Guid doctorId);
        IEnumerable<Appointment> GetByPatient(Guid patientId);
        bool ExistsConflictForDoctor(Guid doctorId, DateTime when);
        bool ExistsConflictForPatient(Guid patientId, DateTime when);
    }
}
