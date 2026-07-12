using PatientManagementSystem.Data;
using PatientManagementSystem.Forms;
using PatientManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp2.Forms;

namespace PatientManagementSystem
{
    public partial class MainForm : Form
    {
        private PatientRepository _repository;
        private AddEditPatientForm _addEditForm;
        private Button btnAddDoctor;
        private Button btnEditDoctor;
        private Button btnDeleteDoctor;
        private SearchPatientForm _searchForm;

        public MainForm()
        {
            _repository = new PatientRepository();
            InitializeComponent();
            LoadPatients();
        }

        private void InitializeComponent()
        {
            dgvPatients = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            btnRefresh = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnAddDoctor = new Button();
            btnEditDoctor = new Button();
            btnDeleteDoctor = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(14, 127);
            dgvPatients.Margin = new Padding(3, 4, 3, 4);
            dgvPatients.MultiSelect = false;
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(869, 486);
            dgvPatients.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(14, 9);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 54);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "افزودن بیمار";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(135, 9);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(114, 54);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "ویرایش بیمار";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(256, 9);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 54);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "حذف بیمار";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(376, 9);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 54);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "جستجوی پیشرفته";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(498, 9);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 54);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "بازخوانی";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(635, 29);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(228, 27);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(869, 32);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 7;
            lblSearch.Text = "جستجو:";
            lblSearch.Click += lblSearch_Click;
            // 
            // btnAddDoctor
            // 
            btnAddDoctor.Location = new Point(14, 65);
            btnAddDoctor.Name = "btnAddDoctor";
            btnAddDoctor.Size = new Size(114, 54);
            btnAddDoctor.TabIndex = 8;
            btnAddDoctor.Text = "افزودن پزشک";
            btnAddDoctor.UseVisualStyleBackColor = true;
            btnAddDoctor.Click += btnAddDoctor_Click;
            // 
            // btnEditDoctor
            // 
            btnEditDoctor.Location = new Point(135, 65);
            btnEditDoctor.Name = "btnEditDoctor";
            btnEditDoctor.Size = new Size(114, 54);
            btnEditDoctor.TabIndex = 9;
            btnEditDoctor.Text = "ویرایش پزشک";
            btnEditDoctor.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDoctor
            // 
            btnDeleteDoctor.Location = new Point(256, 65);
            btnDeleteDoctor.Name = "btnDeleteDoctor";
            btnDeleteDoctor.Size = new Size(114, 55);
            btnDeleteDoctor.TabIndex = 10;
            btnDeleteDoctor.Text = "حذف پزشک";
            btnDeleteDoctor.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 629);
            Controls.Add(btnDeleteDoctor);
            Controls.Add(btnEditDoctor);
            Controls.Add(btnAddDoctor);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvPatients);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "سیستم مدیریت بیماران";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // ============== متغیرهای فرم ==============
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;

        // ============== بارگذاری بیماران ==============
        private void LoadPatients()
        {
            List<Patient> patients = _repository.GetAll();
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = patients;

            if (dgvPatients.Columns.Count > 0)
            {
                if (dgvPatients.Columns.Contains("Id"))
                    dgvPatients.Columns["Id"].HeaderText = "شناسه";
                if (dgvPatients.Columns.Contains("NationalCode"))
                    dgvPatients.Columns["NationalCode"].HeaderText = "کد ملی";
                if (dgvPatients.Columns.Contains("FirstName"))
                    dgvPatients.Columns["FirstName"].HeaderText = "نام";
                if (dgvPatients.Columns.Contains("LastName"))
                    dgvPatients.Columns["LastName"].HeaderText = "نام خانوادگی";
                if (dgvPatients.Columns.Contains("DateOfBirth"))
                    dgvPatients.Columns["DateOfBirth"].HeaderText = "تاریخ تولد";
                if (dgvPatients.Columns.Contains("Phone"))
                    dgvPatients.Columns["Phone"].HeaderText = "تلفن";
                if (dgvPatients.Columns.Contains("Address"))
                    dgvPatients.Columns["Address"].HeaderText = "آدرس";
                if (dgvPatients.Columns.Contains("RegistrationDate"))
                    dgvPatients.Columns["RegistrationDate"].HeaderText = "تاریخ ثبت نام";
            }
        }

        // ============== افزودن بیمار جدید ==============
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _addEditForm = new AddEditPatientForm(_repository);
            if (_addEditForm.ShowDialog() == DialogResult.OK)
            {
                LoadPatients();
            }
        }

        // ============== ویرایش بیمار ==============
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفاً یک بیمار را انتخاب کنید.", "توجه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Patient selectedPatient = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;
            _addEditForm = new AddEditPatientForm(_repository, selectedPatient);
            if (_addEditForm.ShowDialog() == DialogResult.OK)
            {
                LoadPatients();
            }
        }

        // ============== حذف بیمار ==============
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفاً یک بیمار را انتخاب کنید.", "توجه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Patient selectedPatient = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                "آیا از حذف بیمار " + selectedPatient.FirstName + " " + selectedPatient.LastName + " مطمئن هستید؟",
                "تأیید حذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = _repository.Delete(selectedPatient.Id);
                if (success)
                {
                    MessageBox.Show("بیمار با موفقیت حذف شد.", "موفقیت",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPatients();
                }
                else
                {
                    MessageBox.Show("خطا در حذف بیمار.", "خطا",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============== جستجوی پیشرفته ==============
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchForm = new SearchPatientForm(_repository);
            _searchForm.ShowDialog();
        }

        // ============== بازخوانی ==============
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatients();
            txtSearch.Clear();
        }

        // ============== جستجوی سریع ==============
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text) || txtSearch.Text.Trim() == "")
            {
                LoadPatients();
                return;
            }

            List<Patient> results = _repository.Search(txtSearch.Text);
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = results;
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            DoctorRepository doctorRepository = new DoctorRepository();

            AddEditDoctorForm doctorForm =
                new AddEditDoctorForm(doctorRepository);

            doctorForm.ShowDialog();

        }
    }
}