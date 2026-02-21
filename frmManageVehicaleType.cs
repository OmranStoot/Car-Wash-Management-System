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
    public partial class frmManageVehicaleType : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int? _VehicaleTypeID;
        private ClsVehicaleType _VehicaleType;
        public frmManageVehicaleType()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmManageVehicaleType(int vehicaleTypeID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _VehicaleTypeID = vehicaleTypeID;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Type";
                _VehicaleType = new ClsVehicaleType();
            }
            else
                lblMode.Text = "Update Type";

            lblID.Text = string.Empty;
            txtName.Text = string.Empty;
            cbClass.SelectedIndex = 0;
        }

        private void _LoadData()
        {
            _VehicaleType = ClsVehicaleType.Find(_VehicaleTypeID.Value);

            if(_VehicaleType == null )
            {
                MessageBox.Show($"There is no Vehchile Type with ID = {_VehicaleTypeID.Value}", "Error", MessageBoxButtons.OK);
                this.Close();
                return;

            }

            lblID.Text = _VehicaleType.VehicaleTypeID.ToString();
            txtName.Text = _VehicaleType.Name;
            cbClass.Text = _VehicaleType.Class;
        }

        private void frmManageVehicaleType_Load(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _VehicaleType.Name = txtName.Text.Trim();
            _VehicaleType.Class = cbClass.Text.Trim();

            if (_VehicaleType.Save())
            {
                _Mode = enMode.Update;
                lblMode.Text = "Update Vehicale Type";
                lblID.Text = _VehicaleType.VehicaleTypeID?.ToString();
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClsValidation.ClearControls(this);
        }
    }
}
