
using HospitalDoctorsPatients.models;

namespace HospitalDoctorsPatients.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient? GetByDocument(string doc);

    }
}