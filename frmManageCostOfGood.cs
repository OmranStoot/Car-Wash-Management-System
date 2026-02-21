using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CarWash.BL;

namespace Car_Wash
{
    public partial class frmManageCostOfGood : Form
    {
        public enum enMode { AddNew = 0, Update =1 }
        private enMode _Mode;

        private int _CostID;
        private ClsCostOfGood _CostOfGood;
        public frmManageCostOfGood()
        {
            InitializeComponent();
        }

        public frmManageCostOfGood(int CostID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _CostID = CostID;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New CoG";
                _CostOfGood = new ClsCostOfGood();
            }
            else
                lblMode.Text = "Update CoG";

            lblID.Text = string.Empty;
            txtCostName.Text = string.Empty;
            txtClass.Text = string.Empty;
            dtpCoG.Value = DateTime.Now; 
        }

        private void _LoadData()
        {
            _CostOfGood = ClsCostOfGood.Find(_CostID);

            if( _CostOfGood == null )
            {
                MessageBox.Show($"There is no Cost Of Good Sold with ID = {_CostID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblID.Text =  _CostOfGood.CostID.ToString();
            txtCostName.Text = _CostOfGood.CostName;
            txtClass.Text = _CostOfGood.Cost.ToString();
            dtpCoG.Value = _CostOfGood.CostDate;
        }


        private void frmManageCostOfGood_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if( _Mode == enMode.Update)
                _LoadData();
            ClsValidation.AttachValidation(this, errorProvider1);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClsValidation.ClearControls(this, DateTime.Now);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _CostOfGood.CostName = txtCostName.Text.Trim();
            _CostOfGood.Cost = Convert.ToDecimal(txtClass.Text.Trim());
            _CostOfGood.CostDate = dtpCoG.Value;

            if (_CostOfGood.Save())
            {
                _Mode = enMode.Update;
                lblMode.Text = "Update CoG";
                lblID.Text = _CostOfGood.CostID?.ToString();
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

    }
}
