using PatientManagementSystem.Data;

namespace PatientManagementSystem.Forms
{
    internal class SearchPatientForm
    {
        private PatientRepository repository;

        public SearchPatientForm(PatientRepository repository)
        {
            this.repository = repository;
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}