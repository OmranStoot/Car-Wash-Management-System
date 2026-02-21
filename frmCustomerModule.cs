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
using static Car_Wash.frmEmployerModule;

namespace Car_Wash
{
    public partial class frmCustomerModule : Form
    {

        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;
        
        private int _CustomerID;
        private ClsCustomer _Customer;

        public frmCustomerModule()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmCustomerModule(int CustomerID)
        {
            InitializeComponent();
            _Mode=enMode.Update;
            _CustomerID = CustomerID;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Customer";
                _Customer = new ClsCustomer();
            }
            else
                lblMode.Text = "Update Customer";

            lblID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCarNo.Text = string.Empty;
            txtCarModel.Text = string.Empty;
            cbVechicalType.SelectedIndex = 0;
            txtAddress.Text = string.Empty;
            nudPoints.Value = 0;
            
        }

        private void _LoadData()
        {
            _Customer = ClsCustomer.Find(_CustomerID);

            if(_Customer == null )
            {
                MessageBox.Show($"There is no Customere with ID = {_CustomerID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            lblID.Text = _CustomerID.ToString();
            txtName.Text = _Customer.Name;
            txtPhone.Text = _Customer.Phone;
            txtCarNo.Text = _Customer.CarNo;
            txtCarModel.Text= _Customer.CarModel;
            cbVechicalType.Text = ClsVehicaleType.Find(_Customer.Vid).Name;
            txtAddress.Text = _Customer.Address;
            nudPoints.Value = _Customer.Points;
        }

        private void frmCustomerModule_Load(object sender, EventArgs e)
        {
            cbVechicalType.DataSource = ClsVehicaleType.GetAllVehicaleTypes();
            cbVechicalType.DisplayMember = "Name";
            cbVechicalType.ValueMember = "VehicaleTypeID";
            _ResetDefaultValues();
            if(_Mode == enMode.Update)
                _LoadData();
            ClsValidation.AttachValidation(this, errorProvider1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClsValidation.ClearControls(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Customer.Name = txtName.Text.Trim();
            _Customer.Phone = txtPhone.Text.Trim();
            _Customer.CarNo = txtCarNo.Text.Trim(); 
            _Customer.CarModel = txtCarModel.Text.Trim();
            _Customer.Vid = Convert.ToInt32(cbVechicalType.SelectedValue);
            _Customer.Address = txtAddress.Text.Trim();
            _Customer.Points = Convert.ToInt32(nudPoints.Value);

            if (_Customer.Save())
            {
                _Mode = enMode.Update;
                lblMode.Text = "Update Customer";
                lblID.Text = _Customer.CustomerID?.ToString();
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
