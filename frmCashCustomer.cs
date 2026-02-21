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
    public partial class frmCashCustomer : Form
    {
        public class CustomerSelectedEventArgs : EventArgs
        {
            public int CustomerID { get; set; }
            public int VehicleTypeID { get; set; }
        }

        public event EventHandler<CustomerSelectedEventArgs> CustomerSelected;

        private DataTable _dtCustomers;

        private void _LoadCustomer()
        {
            _dtCustomers = ClsCustomer.GetAllCustomers();
            dgvCustomer.DataSource = _dtCustomers;
        }

        public frmCashCustomer()
        {
            InitializeComponent();
        }

        private void frmCashCustomer_Load(object sender, EventArgs e)
        {
            dgvCustomer.AutoGenerateColumns = false;
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

                if (dgvCustomer.Columns[e.ColumnIndex].Name == "btnSelect")
                {
                    int customerID = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["CustomerID"].Value);
                    int vehicleTypeID = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["VehicaleTypeID"].Value);

                    var args = new CustomerSelectedEventArgs
                    {
                        CustomerID = customerID,
                        VehicleTypeID = vehicleTypeID,
                    };

                    CustomerSelected?.Invoke(this, args);
                    this.Close();

                }

            }

        }

    }
}
