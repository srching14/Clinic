using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Domain;

namespace Hospital.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly InMemoryDatabase _db;
        public DoctorRepository(InMemoryDatabase db) => _db = db;

        public Doctor Add(Doctor entity)
        {
            _db.Doctors.Add(entity);
            return entity;
        }

        public void Update(Doctor entity)
        {
            var idx = _db.Doctors.FindIndex(d => d.Id == entity.Id);
            if (idx >= 0) _db.Doctors[idx] = entity;
        }

        public void Delete(Guid id)
        {
            var item = GetById(id);
            if (item != null) _db.Doctors.Remove(item);
        }

        public Doctor? GetById(Guid id) => _db.Doctors.FirstOrDefault(d => d.Id == id);

        public IEnumerable<Doctor> GetAll() => _db.Doctors;

        public Doctor? GetByDocument(string doc) => _db.Doctors.FirstOrDefault(d => d.Document == doc);

        public IEnumerable<Doctor> GetBySpecialty(string specialty)
            => _db.Doctors.Where(d => d.Specialty.Equals(specialty, StringComparison.OrdinalIgnoreCase));
    }
}
