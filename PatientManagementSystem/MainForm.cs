using System;
using System.Windows.Forms;
using PatientManagementSystem.Data;
using PatientManagementSystem.Models;
using PatientManagementSystem.Forms;
using PatientManagementSystem.Helpers;

namespace PatientManagementSystem
{
    public partial class MainForm : Form
    {
        private PatientRepository repository = new PatientRepository();

        public MainForm()
        {
            InitializeComponent();
            LoadPatients();
        }

        // ============== طراحی فرم با کد ==============
        private void InitializeComponent()
        {
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.SuspendLayout();

            // دیتاگرید
            this.dgvPatients.Location = new System.Drawing.Point(12, 50);
            this.dgvPatients.Size = new System.Drawing.Size(760, 400);
            this.dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.ReadOnly = true;

            // دکمه افزودن
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "افزودن بیمار";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // دکمه ویرایش
            this.btnEdit.Location = new System.Drawing.Point(118, 12);
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Text = "ویرایش بیمار";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // دکمه حذف
            this.btnDelete.Location = new System.Drawing.Point(224, 12);
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "حذف بیمار";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // دکمه جستجو
            this.btnSearch.Location = new System.Drawing.Point(330, 12);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // تکست باکس جستجو
            this.txtSearch.Location = new System.Drawing.Point(450, 12);
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // لیبل جستجو
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(660, 15);
            this.lblSearch.Text = "جستجو:";

            // تنظیمات فرم
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvPatients);
            this.Text = "سیستم مدیریت بیماران";
            this.RightToLeft = RightToLeft.Yes;
            this.StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ============== متغیرهای فرم ==============
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;

        // ============== بارگذاری بیماران ==============
        private void LoadPatients()
        {
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = repository.GetAll();

            // تنظیم عنوان ستون‌ها
            if (dgvPatients.Columns.Count > 0)
            {
                dgvPatients.Columns["Id"].HeaderText = "شناسه";
                dgvPatients.Columns["NationalCode"].HeaderText = "کد ملی";
                dgvPatients.Columns["FirstName"].HeaderText = "نام";
                dgvPatients.Columns["LastName"].HeaderText = "نام خانوادگی";
                dgvPatients.Columns["DateOfBirth"].HeaderText = "تاریخ تولد";
                dgvPatients.Columns["Phone"].HeaderText = "تلفن";
                dgvPatients.Columns["Address"].HeaderText = "آدرس";
                dgvPatients.Columns["RegistrationDate"].HeaderText = "تاریخ ثبت نام";
            }
        }

        // ============== رویدادهای دکمه‌ها ==============

        // افزودن بیمار جدید
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditPatientForm form = new AddEditPatientForm(repository);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPatients();
            }
        }

        // ویرایش بیمار
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفاً یک بیمار را انتخاب کنید.");
                return;
            }

            Patient selected = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;
            AddEditPatientForm form = new AddEditPatientForm(repository, selected);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPatients();
            }
        }

        // حذف بیمار
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفاً یک بیمار را انتخاب کنید.");
                return;
            }

            Patient selected = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                "آیا از حذف " + selected.FirstName + " " + selected.LastName + " مطمئن هستید؟",
                "تأیید حذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (repository.Delete(selected.Id))
                {
                    MessageBox.Show("بیمار با موفقیت حذف شد.");
                    LoadPatients();
                }
                else
                {
                    MessageBox.Show("خطا در حذف بیمار.");
                }
            }
        }

        // جستجوی پیشرفته
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPatientForm form = new SearchPatientForm(repository);
            form.ShowDialog();
        }

        // جستجوی سریع (با تایپ کردن)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadPatients();
                return;
            }

            dgvPatients.DataSource = null;
            dgvPatients.DataSource = repository.Search(txtSearch.Text);
        }
    }
}