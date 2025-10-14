
using HospitalDoctorsPatients.models;

namespace HospitalDoctorsPatients.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Doctor? GetByDocument(string doc);
        IEnumerable<Doctor> GetBySpecialty(string specialty);
    }
}