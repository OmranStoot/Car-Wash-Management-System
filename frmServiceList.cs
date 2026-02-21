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
    public partial class frmServiceList : BaseSecureForm
    {
        protected override Permissions RequiredPermission => Permissions.ManageServices;

        private DataTable _dtService;

        private void _LoadService()
        {
            _dtService = ClsService.GetAllServices();
            dgvService.DataSource = _dtService;
        }
        public frmServiceList()
        {
            InitializeComponent();
        }

        private void frmServiceList_Load(object sender, EventArgs e)
        {
            dgvService.AutoGenerateColumns = false;
            _LoadService();
        }

        private void btnAddNewService_Click(object sender, EventArgs e)
        {
            ServiceModule frm = new ServiceModule();
            frm.ShowDialog();
            _LoadService();
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
                    $"Name LIKE '%{searchText}%' OR ";
            }

        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int serviceID = Convert.ToInt32(
                    dgvService.Rows[e.RowIndex].Cells["ServiceID"].Value
                );

                if (dgvService.Columns[e.ColumnIndex].Name == "btnEditService")
                {

                    Form frm = new ServiceModule(serviceID);
                    frm.ShowDialog();
                    _LoadService();
                }

                if (dgvService.Columns[e.ColumnIndex].Name == "btnDeleteService")
                {
                    if (MessageBox.Show("Are You Sure you Want to Delete this Service?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (ClsService.Delete(serviceID))
                        {
                            MessageBox.Show("Service has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadService();
                        }
                        else
                            MessageBox.Show("Service is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
