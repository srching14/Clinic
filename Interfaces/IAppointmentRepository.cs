
using HospitalDoctorsPatients.models;

namespace HospitalDoctorsPatients.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetByDoctor(Guid doctorId);
        IEnumerable<Appointment> GetByPatient(Guid patientId);
        bool ExistsConflictForDoctor(Guid doctorId, DateTime when);
        bool ExistsConflictForPatient(Guid patientId, DateTime when);
    }
}