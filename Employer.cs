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
    public partial class Employer : BaseSecureForm
    {
        protected override Permissions RequiredPermission => Permissions.ManageEmployees;
        private DataTable _dtEmployers;

        private void _LoadEmployers()
        {
            _dtEmployers = ClsEmployer.GetAllEmployers();
            dgvEmployer.DataSource = _dtEmployers;
        }
        public Employer()
        {
            InitializeComponent();
        }

        private void Employer_Load(object sender, EventArgs e)
        {
            dgvEmployer.AutoGenerateColumns = false;
            _LoadEmployers();
        }

        private void btnAddNewEmployer_Click(object sender, EventArgs e)
        {
            Form frm = new frmEmployerModule();
            frm.ShowDialog();
            _LoadEmployers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(searchText))
            {
                _dtEmployers.DefaultView.RowFilter = "";
            }
            else
            {
                _dtEmployers.DefaultView.RowFilter =
                    $"Name LIKE '%{searchText}%' OR " +
                    $"Address LIKE '%{searchText}%' OR " +
                    $"Role LIKE '%{searchText}%'";
            }

        }

        private void dgvEmployer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int employerID = (int)dgvEmployer.Rows[e.RowIndex].Cells["ID"].Value;

                if (dgvEmployer.Columns[e.ColumnIndex].Name == "btnEditEmployer")
                {

                    Form frm = new frmEmployerModule(employerID);
                    frm.ShowDialog();
                    _LoadEmployers();
                }

                if (dgvEmployer.Columns[e.ColumnIndex].Name == "btnDeleteEmployer")
                {
                    if(MessageBox.Show("Are You Sure you Want to Delete this Employer?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (ClsEmployer.DeleteEmployer(employerID))
                        {
                            MessageBox.Show("Employer has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadEmployers();
                        }
                        else
                            MessageBox.Show("Employer is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
