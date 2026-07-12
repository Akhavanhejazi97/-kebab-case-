using System;
using System.Collections.Generic;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Data
{
    public class DoctorRepository
    {
        private List<Doctor> doctors = new List<Doctor>();

        private int nextId = 1;
        public List<Doctor> GetAllDoctors()
        {
            return doctors;
        }
        public Doctor GetDoctorByMedicalCode(string medicalCode)
        {
            foreach (Doctor d in doctors)
            {
                if (d.MedicalCode == medicalCode)
                    return d;
            }

            return null;
        }
        

        public bool AddDoctor(Doctor doctor)
        {
            if (GetDoctorByMedicalCode(doctor.MedicalCode) != null)
                return false;

            doctor.Id = nextId;
            nextId++;

            doctors.Add(doctor);

            return true;

        }
        public bool UpdateDoctor(Doctor doctor)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == doctor.Id)
                {
                    if (doctors[i].MedicalCode != doctor.MedicalCode)
                    {
                        if (GetDoctorByMedicalCode(doctor.MedicalCode) != null)
                            return false;
                    }

                    doctors[i] = doctor;
                    return true;
                }
            }

            return false;
        }
        public bool DeleteDoctor(int id)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == id)
                {
                    doctors.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
        public List<Doctor> SearchDoctors(string keyword)
        {
            List<Doctor> results = new List<Doctor>();

            if (string.IsNullOrWhiteSpace(keyword))
                return doctors;

            keyword = keyword.Trim().ToLower();

            foreach (Doctor d in doctors)
            {
                if (d.FirstName.ToLower().Contains(keyword) ||
                    d.LastName.ToLower().Contains(keyword) ||
                    d.MedicalCode.ToLower().Contains(keyword) ||
                    d.Specialties.ToLower().Contains(keyword))
                {
                    results.Add(d);
                }
            }

            return results;
        }
    }
}




