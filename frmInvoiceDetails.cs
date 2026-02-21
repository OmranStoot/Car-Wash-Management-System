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
    public partial class frmInvoiceDetails : Form
    {
        private ClsInvoiceDetailsDTO _details;
        public frmInvoiceDetails(int invoiceID)
        {
            InitializeComponent();
            _details = ClsInvoiceDetailsDTO.GetInvoiceDetails(invoiceID);
        }

        private void frmInvoiceDetails_Load(object sender, EventArgs e)
        {
            DataRow row = _details.Header.Rows[0];
            lblTransNo.Text = row["TransNo"].ToString();
            lblStatus.Text = row["Status"].ToString();
            DateTime invoiceDate = Convert.ToDateTime(row["InvoiceDate"]);
            lblDate.Text = invoiceDate.ToString("yyyyMMdd");
            lblTotal.Text = row["TotalAmount"].ToString();

            lblCustomerName.Text = row["CustomerName"].ToString();
            lblCarModel.Text = row["CarModel"].ToString();
            lblVehicaleType.Text = row["VehicleType"].ToString();
            lblClass.Text = row["Class"].ToString();

            dgvServices.DataSource = _details.Services;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvServices.Columns.Contains("ServiceName"))
            {
                dgvServices.Columns["ServiceName"].FillWeight = 150; 
                dgvServices.Columns["Price"].FillWeight = 50;
            }
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.DataSource = _details.Payments;

            decimal payments = 0.00m;
            foreach(DataRow pay in _details.Payments.Rows)
            {
                payments += Convert.ToDecimal(pay["Amount"]);
            }

            decimal remaining = Convert.ToDecimal(row["TotalAmount"]) - payments;
            lblRemaining.Text = remaining.ToString();
            lblPaid.Text = payments.ToString();

                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvServices_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowNumber = (e.RowIndex + 1).ToString();
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(rowNumber, this.Font, brush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
