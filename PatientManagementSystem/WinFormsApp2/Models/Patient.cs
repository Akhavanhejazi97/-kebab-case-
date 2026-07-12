using System;

namespace PatientManagementSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string NationalCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Patient(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
                throw new ArgumentException("کد ملی الزامی است.", nameof(nationalCode));

            NationalCode = nationalCode;
            RegistrationDate = DateTime.Now;
        }
    }
}