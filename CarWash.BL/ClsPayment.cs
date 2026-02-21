using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsPayment
    {
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
        public int PaidByEmployerID { get; private set; }

        public ClsPayment(int paidByEmployerID)
        {
            if (paidByEmployerID <= 0)
                throw new ArgumentException("Invalid EmployerID");

            PaidByEmployerID = paidByEmployerID;
        }

        public bool Save()
        {
            if (InvoiceID <= 0)
                throw new ArgumentException("Invalid InvoiceID.");

            if (Amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero.");

            if (string.IsNullOrEmpty(PaymentMethod))
                throw new ArgumentException("Payment method is required.");


            if (PaidByEmployerID <= 0)
                throw new InvalidOperationException("PaidByEmployerID is not set.");


            return ClsPaymentData.AddPayment(
                InvoiceID,
                Amount,
                PaymentMethod,
                Notes,
                PaidByEmployerID
            );
        }

        public static DataTable GetPayments(int invoiceID)
        {
            return ClsPaymentData.GetPaymentsByInvoice(invoiceID);
        }
    }
}
