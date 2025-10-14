using System;
using System.Linq;
using Hospital.Domain;
using Hospital.Repositories;

namespace Hospital.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _repo;
        public DoctorService(IDoctorRepository repo) => _repo = repo;

        public void CreateInteractive()
        {
            Console.WriteLine("Create Doctor:");
            var d = new Doctor();
            Console.Write("Name: "); d.Name = Console.ReadLine() ?? "";
            Console.Write("Document: "); d.Document = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(d.Document) && _repo.GetByDocument(d.Document) != null)
            {
                Console.WriteLine("A doctor with that document already exists."); return;
            }
            Console.Write("Specialty: "); d.Specialty = Console.ReadLine() ?? "";
            Console.Write("Phone: "); d.Phone = Console.ReadLine() ?? "";
            Console.Write("Email: "); d.Email = Console.ReadLine() ?? "";
            _repo.Add(d);
            Console.WriteLine("Doctor added.");
            Console.ReadLine();
        }

        public void EditInteractive()
        {
            Console.Write("Enter doctor document to edit: ");
            var doc = Console.ReadLine() ?? "";
            var doctor = _repo.GetByDocument(doc);
            if (doctor == null) { Console.WriteLine("Doctor not found."); Console.ReadLine(); return; }
            Console.WriteLine($"Editing {doctor.Name}");
            Console.Write("New name (enter to keep): "); var nm = Console.ReadLine(); if (!string.IsNullOrEmpty(nm)) doctor.Name = nm;
            Console.Write("New specialty (enter to keep): "); var sp = Console.ReadLine(); if (!string.IsNullOrEmpty(sp)) doctor.Specialty = sp;
            Console.Write("New phone (enter to keep): "); var ph = Console.ReadLine(); if (!string.IsNullOrEmpty(ph)) doctor.Phone = ph;
            Console.Write("New email (enter to keep): "); var em = Console.ReadLine(); if (!string.IsNullOrEmpty(em)) doctor.Email = em;
            _repo.Update(doctor);
            Console.WriteLine("Updated."); Console.ReadLine();
        }

        public void ListAll()
        {
            var list = _repo.GetAll().ToList();
            Console.WriteLine($"Doctors ({list.Count}):");
            foreach (var d in list) Console.WriteLine($"{d.Name} | {d.Document} | {d.Specialty} | {d.Email} | {d.Phone}");
            Console.ReadLine();
        }

        public void ListBySpecialty()
        {
            Console.Write("Specialty: "); var s = Console.ReadLine() ?? "";
            var list = _repo.GetBySpecialty(s).ToList();
            Console.WriteLine($"Doctors ({list.Count}) with specialty {s}:");
            foreach (var d in list) Console.WriteLine($"{d.Name} | {d.Document} | {d.Specialty}");
            Console.ReadLine();
        }
    }
}
