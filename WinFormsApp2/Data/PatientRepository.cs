using System;
using System.Collections.Generic;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Data
{
    public class PatientRepository
    {
        private List<Patient> patients = new List<Patient>();
        private int nextId = 1;

        // ============== GetAllPatients (برای MainForm) ==============
        public List<Patient> GetAllPatients()
        {
            return patients;
        }

        // ============== GetAll (برای فرم‌های دیگر) ==============
        public List<Patient> GetAll()
        {
            return patients;
        }

        // ============== پیدا کردن بیمار با کد ملی ==============
        public Patient GetPatientByNationalCode(string nationalCode)
        {
            foreach (Patient p in patients)
            {
                if (p.NationalCode == nationalCode)
                    return p;
            }
            return null;
        }

        // ============== پیدا کردن بیمار با شناسه ==============
        public Patient GetPatientById(int id)
        {
            foreach (Patient p in patients)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }

        // ============== اضافه کردن بیمار جدید ==============
        public bool AddPatient(Patient patient)
        {
            if (GetPatientByNationalCode(patient.NationalCode) != null)
                return false;

            patient.Id = nextId;
            nextId++;
            patient.RegistrationDate = DateTime.Now;
            patients.Add(patient);
            return true;
        }

        // ============== Add (برای فرم‌های دیگر) ==============
        public bool Add(Patient patient)
        {
            return AddPatient(patient);
        }

        // ============== ویرایش بیمار ==============
        public bool UpdatePatient(Patient patient)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == patient.Id)
                {
                    if (patients[i].NationalCode != patient.NationalCode)
                    {
                        if (GetPatientByNationalCode(patient.NationalCode) != null)
                            return false;
                    }

                    patients[i].NationalCode = patient.NationalCode;
                    patients[i].FirstName = patient.FirstName;
                    patients[i].LastName = patient.LastName;
                    patients[i].DateOfBirth = patient.DateOfBirth;
                    patients[i].Phone = patient.Phone;
                    patients[i].Address = patient.Address;
                    return true;
                }
            }
            return false;
        }

        // ============== Update (برای فرم‌های دیگر) ==============
        public bool Update(Patient patient)
        {
            return UpdatePatient(patient);
        }

        // ============== حذف بیمار ==============
        public bool DeletePatient(int id)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == id)
                {
                    patients.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // ============== Delete (برای فرم‌های دیگر) ==============
        public bool Delete(int id)
        {
            return DeletePatient(id);
        }

        // ============== جستجوی بیماران ==============
        public List<Patient> SearchPatients(string keyword)
        {
            List<Patient> results = new List<Patient>();

            if (string.IsNullOrEmpty(keyword) || keyword.Trim() == "")
                return patients;

            keyword = keyword.Trim().ToLower();

            foreach (Patient p in patients)
            {
                if (p.NationalCode.ToLower().Contains(keyword) ||
                    p.FirstName.ToLower().Contains(keyword) ||
                    p.LastName.ToLower().Contains(keyword) ||
                    p.Phone.Contains(keyword))
                {
                    results.Add(p);
                }
            }

            return results;
        }

        // ============== Search (برای فرم‌های دیگر) ==============
        public List<Patient> Search(string keyword)
        {
            return SearchPatients(keyword);
        }
    }
}