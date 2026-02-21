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
    public partial class frmCashService : Form
    {
        public class SelectedServiceDTO
        {
            public int ServiceID { get; set; }
            public string ServiceName { get; set; }
            public decimal Price { get; set; }

        }

        public class ServicesSelectedEventArgs : EventArgs
        {
            public List<SelectedServiceDTO> Services { get; set; }
        }

        public event EventHandler<ServicesSelectedEventArgs> ServicesSelected;

        private DataTable _dtService;
        private void _LoadService()
        {
            _dtService = ClsService.GetAllServices();
            dgvService.DataSource = _dtService;
        }
        
        private int _CustomerID = -1, _VehicaleTypeID = -1;

        public frmCashService(int CustomerID, int VehicaleTypeID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
            _VehicaleTypeID= VehicaleTypeID;
        }

        private void frmCashService_Load(object sender, EventArgs e)
        {
            dgvService.AutoGenerateColumns = false;
            _LoadService();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_CustomerID <= 0 || _VehicaleTypeID <= 0)
            {
                MessageBox.Show("Customer or Vehicle type is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<SelectedServiceDTO> selectedServices = new List<SelectedServiceDTO> ();
            int addedCount = 0;
            foreach (DataGridViewRow row in dgvService.Rows)
            {
                if (row.IsNewRow)
                    continue;

                bool isSelected =
                    row.Cells["Select"].Value != null &&
                    Convert.ToBoolean(row.Cells["Select"].Value);
                if (!isSelected)
                    continue;

                int sid = Convert.ToInt32(row.Cells["ServiceID"].Value);

                if (sid <= 0)
                {
                    MessageBox.Show("Invalid ServiceID detected.");
                    continue;
                }

                selectedServices.Add(new SelectedServiceDTO
                {
                    ServiceID = sid,
                    ServiceName = row.Cells["ServiceName"].Value.ToString(),
                    Price = Convert.ToDecimal(row.Cells["Price"].Value)
                });
            }
            if (selectedServices.Count == 0)
            {
                MessageBox.Show("Please Select at least one service.");
                return;
            }

            ServicesSelected?.Invoke(this, new ServicesSelectedEventArgs
            {
                Services = selectedServices
            });
            MessageBox.Show($"{addedCount} service(s) added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(searchText))
            {
                _dtService.DefaultView.RowFilter = "";
            }
            else
            {
                _dtService.DefaultView.RowFilter =
                $"Name LIKE '%{searchText}%'";
            }

        }


    }
}
