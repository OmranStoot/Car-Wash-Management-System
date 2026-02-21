using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarWash.BL;

namespace Car_Wash
{
    public partial class frmEmployerModule : Form
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enum enGendor { Male = 0, Female = 1 }

        private enMode _Mode;

        private int? _EmployerID;
        private ClsEmployer _Employer;
        public frmEmployerModule()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmEmployerModule(int employerID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _EmployerID = employerID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Employer.Name = txtName.Text.Trim();
            _Employer.Phone = txtPhone.Text.Trim();
            _Employer.Dob = dtpDate.Value;
            _Employer.Address = txtAddress.Text.Trim();
            _Employer.Role = cbRole.Text.Trim();
            _Employer.Salary = Convert.ToDouble(txtSalary.Text);
            _Employer.Password = txtPassword.Text.Trim();
            _Employer.Gender = (rbtnMale.Checked) ? (int)enGendor.Male : (int)enGendor.Female;

            if (_Employer.Save())
            {
                _Mode = enMode.Update;
                lblMode.Text = "Update Employer";
                lblID.Text = _Employer.EmployerID?.ToString();
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Employer";
                _Employer = new ClsEmployer();
            }
            else
                lblMode.Text = "Update Employer";

            rbtnMale.Checked = true;
            dtpDate.MaxDate = DateTime.Now.AddYears(-18);
            dtpDate.Value = dtpDate.MaxDate;

            dtpDate.MinDate = DateTime.Now.AddYears(-100);

            lblID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cbRole.SelectedIndex = cbRole.FindString("Worker");

        }
        private void _LoadData()
        {
            _Employer = ClsEmployer.Find(_EmployerID.Value);

            if(_Employer == null)
            {
                MessageBox.Show($"There is no Employer with ID = {_EmployerID.Value}", "Error", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            lblID.Text = _Employer.EmployerID.ToString();
            txtName.Text = _Employer.Name;
            txtPhone.Text = _Employer.Phone;
            dtpDate.Value = _Employer.Dob;
            txtAddress.Text = _Employer.Address;  
            cbRole.Text = _Employer.Role;   
            txtSalary.Text = _Employer.Salary.ToString();
            txtPassword.Text = _Employer.Password;

            if (_Employer.Gender == 0)
                rbtnMale.Checked = true;
            else
                rbtnFemale.Checked = true;
        }

        private void frmEmployerModule_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
            ClsValidation.AttachValidation(this, errorProvider1); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClsValidation.ClearControls(this, dtpDate.MaxDate);
        }
    }
}
