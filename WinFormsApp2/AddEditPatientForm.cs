using System;
using System.Windows.Forms;
using PatientManagementSystem.Data;
using PatientManagementSystem.Helpers;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Forms
{
    public partial class AddEditPatientForm : Form
    {
        private PatientRepository _repository;
        private Patient _editingPatient;
        private bool _isEditMode;

        // سازنده برای افزودن بیمار جدید
        public AddEditPatientForm(PatientRepository repository)
        {
            _repository = repository;
            _isEditMode = false;
            _editingPatient = null;
            InitializeComponent();
            this.Text = "افزودن بیمار جدید";
            btnSave.Text = "ثبت بیمار";
        }

        // سازنده برای ویرایش بیمار
        public AddEditPatientForm(PatientRepository repository, Patient patient)
        {
            _repository = repository;
            _editingPatient = patient;
            _isEditMode = true;
            InitializeComponent();
            this.Text = "ویرایش بیمار";
            btnSave.Text = "به‌روزرسانی";
            LoadPatientData();
        }

        private void InitializeComponent()
        {
            this.lblNationalCode = new System.Windows.Forms.Label();
            this.txtNationalCode = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // کد ملی
            this.lblNationalCode.AutoSize = true;
            this.lblNationalCode.Location = new System.Drawing.Point(340, 20);
            this.lblNationalCode.Text = "کد ملی:";

            this.txtNationalCode.Location = new System.Drawing.Point(150, 17);
            this.txtNationalCode.Size = new System.Drawing.Size(184, 20);
            this.txtNationalCode.MaxLength = 10;

            // نام
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(367, 55);
            this.lblFirstName.Text = "نام:";

            this.txtFirstName.Location = new System.Drawing.Point(150, 52);
            this.txtFirstName.Size = new System.Drawing.Size(184, 20);

            // نام خانوادگی
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(333, 90);
            this.lblLastName.Text = "نام خانوادگی:";

            this.txtLastName.Location = new System.Drawing.Point(150, 87);
            this.txtLastName.Size = new System.Drawing.Size(184, 20);

            // تاریخ تولد
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(341, 125);
            this.lblDateOfBirth.Text = "تاریخ تولد:";

            this.dtpDateOfBirth.Location = new System.Drawing.Point(150, 122);
            this.dtpDateOfBirth.Size = new System.Drawing.Size(184, 20);
            this.dtpDateOfBirth.MaxDate = DateTime.Now;

            // تلفن
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(360, 160);
            this.lblPhone.Text = "تلفن:";

            this.txtPhone.Location = new System.Drawing.Point(150, 157);
            this.txtPhone.Size = new System.Drawing.Size(184, 20);
            this.txtPhone.MaxLength = 11;

            // آدرس
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(356, 195);
            this.lblAddress.Text = "آدرس:";

            this.txtAddress.Location = new System.Drawing.Point(150, 192);
            this.txtAddress.Size = new System.Drawing.Size(184, 60);
            this.txtAddress.Multiline = true;

            // دکمه ذخیره
            this.btnSave.Location = new System.Drawing.Point(210, 270);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // دکمه انصراف
            this.btnCancel.Location = new System.Drawing.Point(100, 270);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // تنظیمات فرم
            this.ClientSize = new System.Drawing.Size(420, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtNationalCode);
            this.Controls.Add(this.lblNationalCode);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.RightToLeft = RightToLeft.Yes;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNationalCode;
        private System.Windows.Forms.TextBox txtNationalCode;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void LoadPatientData()
        {
            txtNationalCode.Text = _editingPatient.NationalCode;
            txtFirstName.Text = _editingPatient.FirstName;
            txtLastName.Text = _editingPatient.LastName;
            dtpDateOfBirth.Value = _editingPatient.DateOfBirth;
            txtPhone.Text = _editingPatient.Phone;
            txtAddress.Text = _editingPatient.Address;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtNationalCode.Text) || txtNationalCode.Text.Trim() == "")
            {
                ValidationHelper.ShowValidationError("وارد کردن کد ملی اجباری است.");
                txtNationalCode.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidNationalCode(txtNationalCode.Text))
            {
                ValidationHelper.ShowValidationError("کد ملی وارد شده نامعتبر است.");
                txtNationalCode.Focus();
                return false;
            }

            Patient existing = _repository.GetPatientByNationalCode(txtNationalCode.Text);
            if (existing != null)
            {
                if (!_isEditMode || existing.Id != _editingPatient.Id)
                {
                    ValidationHelper.ShowValidationError("این کد ملی قبلاً ثبت شده است.");
                    txtNationalCode.Focus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtFirstName.Text) || txtFirstName.Text.Trim() == "")
            {
                ValidationHelper.ShowValidationError("وارد کردن نام اجباری است.");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text) || txtLastName.Text.Trim() == "")
            {
                ValidationHelper.ShowValidationError("وارد کردن نام خانوادگی اجباری است.");
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text.Trim() == "")
            {
                ValidationHelper.ShowValidationError ("وارد کردن شماره تلفن اجباری است.");
                txtPhone.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidPhone(txtPhone.Text))
            {
                ValidationHelper.ShowValidationError ("شماره تلفن نامعتبر است" );
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text.Trim() == "")
            {
                ValidationHelper.ShowValidationError ("وارد کردن آدرس اجباری است.");
                txtAddress.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            Patient patient = new Patient(txtNationalCode.Text.Trim());
            patient.NationalCode = txtNationalCode.Text.Trim();
            patient.FirstName = txtFirstName.Text.Trim();
            patient.LastName = txtLastName.Text.Trim();
            patient.DateOfBirth = dtpDateOfBirth.Value;
            patient.Phone = txtPhone.Text.Trim();
            patient.Address = txtAddress.Text.Trim();

            bool success;

            if (_isEditMode)
            {
                patient.Id = _editingPatient.Id;
                success = _repository.UpdatePatient(patient);
                if (success)
                    ValidationHelper.ShowSuccess("بیمار با موفقیت ویرایش شد.");
            }
            else
            {
                success = _repository.AddPatient(patient);
                if (success)
                    ValidationHelper.ShowSuccess("بیمار با موفقیت ثبت شد.");
            }

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ValidationHelper.ShowValidationError("خطا در ذخیره اطلاعات.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}