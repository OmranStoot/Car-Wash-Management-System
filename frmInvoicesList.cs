using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Wash.Global_Classes;
using Car_Wash.Reports;
using CarWash.BL;

namespace Car_Wash
{
    public partial class frmInvoicesList : BaseSecureForm
    {
        protected override Permissions RequiredPermission => Permissions.ViewInvoices;

        private DataTable _dtInvoicesList;

        private void _LoadInvoices()
        {
            _dtInvoicesList = ClsCashInvoice.GetInvoiecsList();
            dgvInvoices.DataSource = _dtInvoicesList;
        }

        public frmInvoicesList()
        {
            InitializeComponent();
        }

        private void frmInvoicesList_Load(object sender, EventArgs e)
        {
            dgvInvoices.AutoGenerateColumns = false;
            _LoadInvoices();
        }

        private void btnAddNewInvoice_Click(object sender, EventArgs e)
        {
            frmCash frm = new frmCash();
            frm.ShowDialog();
            _LoadInvoices();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(searchText))
            {
                _dtInvoicesList.DefaultView.RowFilter = "";
            }
            else
            {
                _dtInvoicesList.DefaultView.RowFilter =
                    $"CustomerName LIKE '%{searchText}%' OR " +
                    $"TransNo LIKE '%{searchText}%' OR " +
                    $"Class LIKE '%{searchText}%' OR " +
                    $"CarModel LIKE '%{searchText}%'";
            }


        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            int invoiceID = Convert.ToInt32(dgvInvoices.CurrentRow.Cells["InvoiceID"].Value);
            frmInvoiceReport frm = new frmInvoiceReport(invoiceID, ClsGlobal.company.CompanyName, ClsGlobal.company.Address);
            frm.ShowDialog();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            int invoiceID = Convert.ToInt32(dgvInvoices.CurrentRow.Cells["InvoiceID"].Value);
            frmPaymentSettle frm = new frmPaymentSettle(invoiceID);
            frm.ShowDialog();
            _LoadInvoices();
        }


        private void btnInvoiceDetails_Click(object sender, EventArgs e)
        {
            int invoiceID = Convert.ToInt32(dgvInvoices.CurrentRow.Cells["InvoiceID"].Value);
            frmInvoiceDetails frm = new frmInvoiceDetails(invoiceID);
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int invoiceID = Convert.ToInt32(dgvInvoices.CurrentRow.Cells["InvoiceID"].Value);
            ClsCashInvoice.CancelInvoice(invoiceID);
            _LoadInvoices();

        }
    }
}
