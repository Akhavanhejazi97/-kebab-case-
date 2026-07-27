using System;

namespace PatientManagementSystem.Models
{
    public class Secretary : Person
    {
        public string PersonnelCode { get; set; }

        public string Shift { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (string.IsNullOrWhiteSpace(PersonnelCode))
                throw new ArgumentException("کد پرسنلی الزامی است.");

            if (PersonnelCode.Length < 4)
                throw new ArgumentException("کد پرسنلی باید حداقل 4 کاراکتر باشد.");
        }
    }
}