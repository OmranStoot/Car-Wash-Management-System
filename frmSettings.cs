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
    public partial class frmSettings : BaseSecureForm
    {
        protected override Permissions RequiredPermission => Permissions.Settings;

        private DataTable _dtVehicaleTypes;

        private void _LoadVehicaleTypes()
        {
            _dtVehicaleTypes = ClsVehicaleType.GetAllVehicaleTypes(); 
            dgvVehicaleType.DataSource = _dtVehicaleTypes;
        }

        private DataTable _dtCostOfGoods;

        private void _LoadCostOfCoods()
        {
            _dtCostOfGoods = ClsCostOfGood.GetAllCostOfGoods();
            dgvCostOfGood.DataSource = _dtCostOfGoods;
        }

        private ClsCompany _Company;

        private void _LoadCompany()
        {
            _Company = ClsCompany.GetCompany();

            if (_Company != null)
            {
                // Company exists → Update mode
                txtCompanyName.Text = _Company.CompanyName;
                txtCompanyAddress.Text = _Company.Address;
            }
            else
            {
                // No company → Add mode
                _Company = new ClsCompany();
                txtCompanyName.Text = string.Empty;
                txtCompanyAddress.Text = string.Empty;
            }
        }
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            dgvVehicaleType.AutoGenerateColumns = false;
            _LoadVehicaleTypes();

            dgvCostOfGood.AutoGenerateColumns=false;
            _LoadCostOfCoods();

            _LoadCompany();
        }

        private void btnAddNewVT_Click(object sender, EventArgs e)
        {
            frmManageVehicaleType frm = new frmManageVehicaleType();
            frm.ShowDialog();
            _LoadVehicaleTypes();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchCoG.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(searchText))
                _dtVehicaleTypes.DefaultView.RowFilter = "";
            else
                _dtVehicaleTypes.DefaultView.RowFilter = $"Name LIKE '%{searchText}%'";
           
        }

        private void dgvVehicaleType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int vehicaleTypeID = (int)dgvVehicaleType.Rows[e.RowIndex].Cells["VehicaleTypeID"].Value;

                if (dgvVehicaleType.Columns[e.ColumnIndex].Name == "btnEditVT")
                {
                    frmManageVehicaleType frm = new frmManageVehicaleType(vehicaleTypeID);
                    frm.ShowDialog();
                    _LoadVehicaleTypes();
                }

                if (dgvVehicaleType.Columns[e.ColumnIndex].Name == "btnDeleteVT")
                {
                    if (MessageBox.Show("Are you sure you want to Delete this Vehicale Type", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (ClsVehicaleType.Delete(vehicaleTypeID))
                        {
                            MessageBox.Show("Vehicale Type has been deleted successed", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadVehicaleTypes();
                        }
                        else
                            MessageBox.Show("Vehicale Type is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnAddCostOfGood_Click(object sender, EventArgs e)
        {
            frmManageCostOfGood frm = new frmManageCostOfGood();
            frm.ShowDialog();
            _LoadCostOfCoods();
        }

        private void txtSearchCoG_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchCoG.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(searchText))
                _dtCostOfGoods.DefaultView.RowFilter = "";
            else
                _dtCostOfGoods.DefaultView.RowFilter = $"CostName LIKE '%{searchText}%'";
        }

        private void dgvCostOfGood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int CostID = (int)dgvCostOfGood.Rows[e.RowIndex].Cells["CostID"].Value;

                if (dgvCostOfGood.Columns[e.ColumnIndex].Name == "btnEditCoG")
                {
                    frmManageCostOfGood frm = new frmManageCostOfGood(CostID);
                    frm.ShowDialog();
                    _LoadCostOfCoods();
                }

                if (dgvCostOfGood.Columns[e.ColumnIndex].Name == "btnDeleteCoG")
                {
                    if (MessageBox.Show("Are you sure you want to Delete this Cost of Good Sold", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (ClsCostOfGood.Delete(CostID))
                        {
                            MessageBox.Show("Cost Of Good has been deleted successed", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadCostOfCoods();
                        }
                        MessageBox.Show("Cost Of Good is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClsValidation.ClearControls(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) ||
            string.IsNullOrWhiteSpace(txtCompanyAddress.Text))
            {
                MessageBox.Show("Please fill all company information",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Company.CompanyName = txtCompanyName.Text.Trim();
            _Company.Address = txtCompanyAddress.Text.Trim();

            if (_Company.Save())
            {
                MessageBox.Show("Company information saved successfully",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save company information",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
