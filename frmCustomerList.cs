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
    public partial class frmCustomerList : BaseSecureForm
    {
        protected override Permissions RequiredPermission => Permissions.ViewCustomers;

        private DataTable _dtCustomers;

        private void _LoadCustomer()
        {
            _dtCustomers = ClsCustomer.GetAllCustomers();
            dgvCustomer.DataSource = _dtCustomers;
        }
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            dgvCustomer.AutoGenerateColumns = false;
            _LoadCustomer();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerModule frm = new frmCustomerModule();
            frm.ShowDialog();
            _LoadCustomer();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(searchText))
            {
                _dtCustomers.DefaultView.RowFilter = "";
            }
            else
            {
                _dtCustomers.DefaultView.RowFilter =
                    $"Name LIKE '%{searchText}%' OR " +
                    $"Address LIKE '%{searchText}%' OR " +
                    $"CarNo LIKE '%{searchText}%' OR " +
                    $"CarModel LIKE '%{searchText}%'";
            }


        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int customerID = Convert.ToInt32(
                    dgvCustomer.Rows[e.RowIndex].Cells["CustomerID"].Value
                ); 
                
                if (dgvCustomer.Columns[e.ColumnIndex].Name == "btnEditCustomer")
                {

                    Form frm = new frmCustomerModule(customerID);
                    frm.ShowDialog();
                    _LoadCustomer();
                }

                if (dgvCustomer.Columns[e.ColumnIndex].Name == "btnDeleteCustomer")
                {
                    if (MessageBox.Show("Are You Sure you Want to Delete this Customer?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (ClsCustomer.Delete(customerID))
                        {
                            MessageBox.Show("Customer has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadCustomer();
                        }
                        else
                            MessageBox.Show("Customer is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
