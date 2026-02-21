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
    public partial class ServiceModule : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _ServiceID;
        private ClsService _Service;

        public ServiceModule()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public ServiceModule(int serviceID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _ServiceID = serviceID;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Service";
                _Service = new ClsService();
            }
            else
                lblMode.Text = "Update Service";
            
            lblID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private void _LoadData()
        {
            _Service = ClsService.Find(_ServiceID);

            if(_Service == null)
            {
                MessageBox.Show($"There is no Vehchile Type with ID = {_ServiceID}", "Error", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            lblID.Text = _ServiceID.ToString();
            txtName.Text = _Service.Name;
            txtPrice.Text = _Service.Price.ToString();
        }

        private void ServiceModule_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
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
            _Service.Name = txtName.Text.Trim();
            _Service.Price = Convert.ToDecimal(txtPrice.Text.Trim());
            if (_Service.Save())
            {
                _Mode = enMode.Update;
                lblMode.Text = "Update Service";
                lblID.Text = _Service.ServiceID?.ToString();
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
