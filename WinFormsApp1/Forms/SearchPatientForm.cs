using System;
using System.Windows.Forms;
using PatientManagementSystem.Data;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Forms
{
    public partial class SearchPatientForm : Form
    {
        private PatientRepository _repository;
        private DataGridView _dgvResults;

        public SearchPatientForm(PatientRepository repository)
        {
            _repository = repository;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblSearchBy = new Label();
            this.cmbSearchBy = new ComboBox();
            this.txtSearchValue = new TextBox();
            this.btnSearch = new Button();
            this.btnClose = new Button();
            this._dgvResults = new DataGridView();
            this.lblResults = new Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgvResults)).BeginInit();
            this.SuspendLayout();

            // lblSearchBy
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Location = new System.Drawing.Point(520, 20);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(56, 15);
            this.lblSearchBy.TabIndex = 0;
            this.lblSearchBy.Text = "جستجو بر اساس:";

            // cmbSearchBy
            this.cmbSearchBy.Items.AddRange(new object[] {
                "همه",
                "کد ملی",
                "نام",
                "نام خانوادگی",
                "تلفن",
                "آدرس"
            });
            this.cmbSearchBy.Location = new System.Drawing.Point(370, 17);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(144, 23);
            this.cmbSearchBy.TabIndex = 1;
            this.cmbSearchBy.SelectedIndex = 0;

            // txtSearchValue
            this.txtSearchValue.Location = new System.Drawing.Point(150, 17);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(214, 23);
            this.txtSearchValue.TabIndex = 2;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(40, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(40, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "بستن";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // dgvResults
            this._dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvResults.Location = new System.Drawing.Point(12, 55);
            this._dgvResults.Name = "_dgvResults";
            this._dgvResults.Size = new System.Drawing.Size(574, 350);
            this._dgvResults.TabIndex = 5;
            this._dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this._dgvResults.ReadOnly = true;

            // lblResults
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 415);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(153, 15);
            this.lblResults.TabIndex = 6;
            this.lblResults.Text = "تعداد نتایج یافت شده: 0";

            // SearchPatientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 470);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this._dgvResults);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.lblSearchBy);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchPatientForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "جستجوی پیشرفته بیماران";
            this.RightToLeft = RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this._dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblSearchBy;
        private ComboBox cmbSearchBy;
        private TextBox txtSearchValue;
        private Button btnSearch;
        private Button btnClose;
        private Label lblResults;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchValue.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("لطفاً مقدار جستجو را وارد کنید.", "توجه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var results = _repository.SearchPatients(searchValue);

            string searchBy = cmbSearchBy.SelectedItem.ToString();
            if (searchBy != "همه")
            {
                results = results.FindAll(p =>
                {
                    switch (searchBy)
                    {
                        case "کد ملی":
                            return p.NationalCode.Contains(searchValue);
                        case "نام":
                            return p.FirstName.Contains(searchValue);
                        case "نام خانوادگی":
                            return p.LastName.Contains(searchValue);
                        case "تلفن":
                            return p.Phone.Contains(searchValue);
                        case "آدرس":
                            return p.Address.Contains(searchValue);
                        default:
                            return true;
                    }
                });
            }

            _dgvResults.DataSource = null;
            _dgvResults.DataSource = results;

            if (_dgvResults.Columns.Count > 0)
            {
                _dgvResults.Columns["Id"].HeaderText = "شناسه";
                _dgvResults.Columns["NationalCode"].HeaderText = "کد ملی";
                _dgvResults.Columns["FirstName"].HeaderText = "نام";
                _dgvResults.Columns["LastName"].HeaderText = "نام خانوادگی";
                _dgvResults.Columns["DateOfBirth"].HeaderText = "تاریخ تولد";
                _dgvResults.Columns["Phone"].HeaderText = "تلفن";
                _dgvResults.Columns["Address"].HeaderText = "آدرس";
                _dgvResults.Columns["RegistrationDate"].HeaderText = "تاریخ ثبت نام";
                _dgvResults.Columns["FullName"].HeaderText = "نام