using System;

namespace PatientManagementSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MedicalCode { get; private set; }

        public string Specialties { get; set; }

        public Doctor(string medicalCode)
        {
            if (string.IsNullOrWhiteSpace(medicalCode))
                throw new ArgumentException("شماره نظام پزشکی الزامی است.", nameof(medicalCode));

            MedicalCode = medicalCode;
        }
    }
}