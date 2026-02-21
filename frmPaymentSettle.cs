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
using CarWash.BL;

namespace Car_Wash
{
    public partial class frmPaymentSettle : Form
    {
        private int _invoiceID = -1;
        ClsCashInvoice _invoice;
        private decimal _paidAmount = 0;
        public frmPaymentSettle(int invoiceID)
        {
            InitializeComponent();
            _invoiceID = invoiceID;
        }

        private void _LoadInvoiceSummary()
        {
            _invoice = ClsCashInvoice.Find(_invoiceID);
            if (_invoice == null)
            {
                MessageBox.Show($"There is no Invoice with this ID = {_invoiceID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblInvoiceNo.Text = _invoice.TransNo;
            lblTotalAmount.Text = _invoice.TotalAmount.ToString();
            lblStatus.Text = _invoice.Status;

            DataTable dtPayment = ClsPayment.GetPayments(_invoiceID);

            foreach (DataRow row in dtPayment.Rows)
            {
                if (row["Amount"] != DBNull.Value)
                    _paidAmount += Convert.ToDecimal(row["Amount"]);
            }

            lblPaidAmount.Text = _paidAmount.ToString("N2");
            lblRemainingAmount.Text = (_invoice.TotalAmount - _paidAmount).ToString("N2");

        }
        private void frmPaymentSettle_Load(object sender, EventArgs e)
        {
            _LoadInvoiceSummary();
            cbPaymentMethod.SelectedIndex = 0;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(_invoice.Status == "Canceled")
            {
                MessageBox.Show("Invoice Canceld Cannot Pay :-(");
                return;
            }
            if(_invoice.Status == "Paid")
            {
                MessageBox.Show("Invoice Paid Aleardy :-)");
                return;
            }
            decimal amount;

            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Invalid amount!");
                return;
            }
            decimal remaining = Convert.ToDecimal(lblRemainingAmount.Text);

            if (amount > remaining)
            {
                amount = remaining;
                MessageBox.Show(
                    $"The amount was adjusted to remaining balance: {remaining:N2}",
                    "Adjusted Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            ClsPayment payment = new ClsPayment(
                ClsGlobal.CurrentEmployer.EmployerID.Value
            )
            {
                InvoiceID = _invoiceID,
                Amount = amount,
                PaymentMethod = cbPaymentMethod.Text,
                Notes = txtNotes.Text,
            };

            try
            {
                if (payment.Save())
                {
                    MessageBox.Show("Payment added successfully.");
                    _LoadInvoiceSummary();
                    txtAmount.Clear();
                    txtNotes.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAmount.Clear();
            txtNotes.Clear();
            cbPaymentMethod.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
