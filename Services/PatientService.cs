using System;
using System.Linq;
using Hospital.Domain;
using Hospital.Repositories;

namespace Hospital.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _repo;
        public PatientService(IPatientRepository repo) => _repo = repo;

        public void CreateInteractive()
        {
            Console.WriteLine("Create Patient:");
            var p = new Patient();
            Console.Write("Name: "); p.Name = Console.ReadLine() ?? "";
            Console.Write("Document: "); p.Document = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(p.Document) && _repo.GetByDocument(p.Document) != null)
            {
                Console.WriteLine("A patient with that document already exists."); return;
            }
            Console.Write("Age: "); int.TryParse(Console.ReadLine(), out var age); p.Age = age;
            Console.Write("Phone: "); p.Phone = Console.ReadLine() ?? "";
            Console.Write("Email: "); p.Email = Console.ReadLine() ?? "";
            _repo.Add(p);
            Console.WriteLine("Patient added."); Console.ReadLine();
        }

        public void EditInteractive()
        {
            Console.Write("Enter patient document to edit: ");
            var doc = Console.ReadLine() ?? "";
            var p = _repo.GetByDocument(doc);
            if (p == null) { Console.WriteLine("Patient not found."); Console.ReadLine(); return; }
            Console.WriteLine($"Editing {p.Name}");
            Console.Write("New name (enter to keep): "); var nm = Console.ReadLine(); if (!string.IsNullOrEmpty(nm)) p.Name = nm;
            Console.Write("New age (enter to keep): "); var ag = Console.ReadLine(); if (int.TryParse(ag, out var age)) p.Age = age;
            Console.Write("New phone (enter to keep): "); var ph = Console.ReadLine(); if (!string.IsNullOrEmpty(ph)) p.Phone = ph;
            Console.Write("New email (enter to keep): "); var em = Console.ReadLine(); if (!string.IsNullOrEmpty(em)) p.Email = em;
            _repo.Update(p);
            Console.WriteLine("Updated."); Console.ReadLine();
        }

        public void ListAll()
        {
            var list = _repo.GetAll().ToList();
            Console.WriteLine($"Patients ({list.Count}):");
            foreach (var p in list) Console.WriteLine($"{p.Name} | {p.Document} | {p.Age} | {p.Email} | {p.Phone}");
            Console.ReadLine();
        }
    }
}
