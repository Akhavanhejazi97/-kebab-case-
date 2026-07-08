using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PatientManagementSystem.Models;
using PatientManagementSystem.Data;

namespace WinFormsApp2.Forms
{
    public partial class AddEditDoctorForm : Form
    {
        private DoctorRepository doctorRepository;
        private Doctor doctor;

        public AddEditDoctorForm()
        {
            InitializeComponent();
        }
        public AddEditDoctorForm(DoctorRepository repository, Doctor doctor = null)
        {
            InitializeComponent();

            doctorRepository = repository;
            this.doctor = doctor;

            if (doctor != null)
            {
                doctorFirstName.Text = doctor.FirstName;
                doctorLastName.Text = doctor.LastName;
                doctorMedicalCode.Text = doctor.MedicalCode;
                doctorSpecialties.Text = doctor.Specialties;
                doctorMedicalCode.Enabled = false;
            }
        }

        private void AddEditDoctorForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(doctorFirstName.Text) ||
                string.IsNullOrWhiteSpace(doctorLastName.Text) ||
                string.IsNullOrWhiteSpace(doctorMedicalCode.Text) ||
                string.IsNullOrWhiteSpace(doctorSpecialties.Text))
            {
                MessageBox.Show("تمام اطلاعات پزشک را وارد کنید.");
                return;
            }

            if (doctor == null)
            {
                doctor = new Doctor(doctorMedicalCode.Text);
            }

            doctor.FirstName = doctorFirstName.Text;
            doctor.LastName = doctorLastName.Text;
            doctor.Specialties = doctorSpecialties.Text;

            if (doctorRepository.GetDoctorByMedicalCode(doctorMedicalCode.Text) == null)
            {
                doctorRepository.AddDoctor(doctor);
            }
            else
            {
                doctorRepository.UpdateDoctor(doctor);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}