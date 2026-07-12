namespace WinFormsApp2.Forms
{
    partial class AddEditDoctorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFirstName = new Label();
            txtLastName = new Label();
            txtMedicalCode = new Label();
            txtSpecialties = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            doctorFirstName = new TextBox();
            doctorLastName = new TextBox();
            doctorMedicalCode = new TextBox();
            doctorSpecialties = new TextBox();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.AutoSize = true;
            txtFirstName.Location = new Point(156, 61);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(27, 20);
            txtFirstName.TabIndex = 0;
            txtFirstName.Text = "نام";
            // 
            // txtLastName
            // 
            txtLastName.AutoSize = true;
            txtLastName.Location = new Point(120, 108);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(90, 20);
            txtLastName.TabIndex = 1;
            txtLastName.Text = "نام خانوادگی";
            // 
            // txtMedicalCode
            // 
            txtMedicalCode.AutoSize = true;
            txtMedicalCode.Location = new Point(108, 159);
            txtMedicalCode.Name = "txtMedicalCode";
            txtMedicalCode.Size = new Size(131, 20);
            txtMedicalCode.TabIndex = 2;
            txtMedicalCode.Text = "شماره نظام پزشکی";
            // 
            // txtSpecialties
            // 
            txtSpecialties.AutoSize = true;
            txtSpecialties.Location = new Point(140, 202);
            txtSpecialties.Name = "txtSpecialties";
            txtSpecialties.Size = new Size(58, 20);
            txtSpecialties.TabIndex = 3;
            txtSpecialties.Text = "تخصص";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(116, 270);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "ذخیره";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(276, 270);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "انصراف";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // doctorFirstName
            // 
            doctorFirstName.Location = new Point(245, 58);
            doctorFirstName.Name = "doctorFirstName";
            doctorFirstName.Size = new Size(125, 27);
            doctorFirstName.TabIndex = 6;
            // 
            // doctorLastName
            // 
            doctorLastName.Location = new Point(245, 108);
            doctorLastName.Name = "doctorLastName";
            doctorLastName.Size = new Size(125, 27);
            doctorLastName.TabIndex = 7;
            // 
            // doctorMedicalCode
            // 
            doctorMedicalCode.Location = new Point(245, 156);
            doctorMedicalCode.Name = "doctorMedicalCode";
            doctorMedicalCode.Size = new Size(125, 27);
            doctorMedicalCode.TabIndex = 8;
            // 
            // doctorSpecialties
            // 
            doctorSpecialties.Location = new Point(245, 202);
            doctorSpecialties.Name = "doctorSpecialties";
            doctorSpecialties.Size = new Size(125, 27);
            doctorSpecialties.TabIndex = 9;
            // 
            // AddEditDoctorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 360);
            Controls.Add(doctorSpecialties);
            Controls.Add(doctorMedicalCode);
            Controls.Add(doctorLastName);
            Controls.Add(doctorFirstName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtSpecialties);
            Controls.Add(txtMedicalCode);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Name = "AddEditDoctorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ثبت / ویرایش پزشک";
            Load += AddEditDoctorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtFirstName;
        private Label txtLastName;
        private Label txtMedicalCode;
        private Label txtSpecialties;
        private Button btnSave;
        private Button btnCancel;
        private TextBox doctorFirstName;
        private TextBox doctorLastName;
        private TextBox doctorMedicalCode;
        private TextBox doctorSpecialties;
    }
}
