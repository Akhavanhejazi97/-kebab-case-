using System;

namespace PatientManagementSystem.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("نام الزامی است.");

            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("نام خانوادگی الزامی است.");
        }
    }
}