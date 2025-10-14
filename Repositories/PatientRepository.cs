using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Domain;

namespace Hospital.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly InMemoryDatabase _db;
        public PatientRepository(InMemoryDatabase db) => _db = db;

        public Patient Add(Patient entity)
        {
            _db.Patients.Add(entity);
            return entity;
        }

        public void Update(Patient entity)
        {
            var idx = _db.Patients.FindIndex(p => p.Id == entity.Id);
            if (idx >= 0) _db.Patients[idx] = entity;
        }

        public void Delete(Guid id)
        {
            var item = GetById(id);
            if (item != null) _db.Patients.Remove(item);
        }

        public Patient? GetById(Guid id) => _db.Patients.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Patient> GetAll() => _db.Patients;

        public Patient? GetByDocument(string doc) => _db.Patients.FirstOrDefault(p => p.Document == doc);
    }
}
