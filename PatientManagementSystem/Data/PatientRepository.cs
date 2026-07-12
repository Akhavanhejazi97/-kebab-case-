using System;
using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Data
{
    public class PatientRepository
    {
        private static List<Patient> _patients = new List<Patient>();
        private static int _nextId = 1;

        public List<Patient> GetAllPatients()
        {
            return _patients.ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _patients.FirstOrDefault(p => p.Id == id);
        }

        public Patient GetPatientByNationalCode(string nationalCode)
        {
            return _patients.FirstOrDefault(p => p.NationalCode == nationalCode);
        }

        public bool AddPatient(Patient patient)
        {
            if (GetPatientByNationalCode(patient.NationalCode) != null)
                return false;

            patient.Id = _nextId++;
            patient.RegistrationDate = DateTime.Now;
            _patients.Add(patient);
            return true;
        }

        public bool UpdatePatient(Patient patient)
        {
            var existingPatient = GetPatientById(patient.Id);
            if (existingPatient == null)
                return false;

            var duplicateNationalCode = _patients.Any(p =>
                p.NationalCode == patient.NationalCode && p.Id != patient.Id);

            if (duplicateNationalCode)
                return false;

            existingPatient.NationalCode = patient.NationalCode;
            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Phone = patient.Phone;
            existingPatient.Address = patient.Address;

            return true;
        }

        public bool DeletePatient(int id)
        {
            var patient = GetPatientById(id);
            if (patient == null)
                return false;

            return _patients.Remove(patient);
        }

        public List<Patient> SearchPatients(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _patients.ToList();

            searchTerm = searchTerm.Trim().ToLower();

            return _patients.Where(p =>
                p.NationalCode.Contains(searchTerm) ||
                p.FirstName.Contains(searchTerm) ||
                p.LastName.Contains(searchTerm) ||
                p.Phone.Contains(searchTerm) ||
                p.Address.Contains(searchTerm)
            ).ToList();
        }
    }
}