using System;
using System.Data;
using System.Windows.Forms;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsCashInvoice
    {
        public int? InvoiceID { get; private set; }
        public string TransNo { get; set; }
        public int Cid { get; set; }
        public int Vid { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        public int CreatedByEmployerID { get; private set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public ClsCashInvoice(int createdByEmployerID)
        {
            InvoiceID = null;
            TransNo = string.Empty;
            Cid = -1;
            Vid = -1;
            InvoiceDate = DateTime.Now;
            Status = "Open";
            TotalAmount = 0;
            if (createdByEmployerID <= 0)
                throw new ArgumentException("Invalid EmployerID");

            CreatedByEmployerID = createdByEmployerID;
            _Mode = enMode.AddNew;
        }

        private ClsCashInvoice(int invoiceID, string transNo, int cid, int vid, DateTime invoiceDate, string status, decimal totalAmount, int createdByEmployerID)
        {
            InvoiceID = invoiceID;
            TransNo = transNo;
            Cid = cid;
            Vid = vid;
            InvoiceDate = invoiceDate;
            Status = status;
            TotalAmount = totalAmount;
            CreatedByEmployerID = createdByEmployerID;
            _Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.InvoiceID = ClsCashInvoiceData.AddNewCashInvoice(TransNo, Cid, Vid, InvoiceDate, Status, TotalAmount, CreatedByEmployerID);
            return InvoiceID != null;
        }

        private bool _Update()
        {
            if (InvoiceID == null) return false;
            return ClsCashInvoiceData.UpdateCashInvoice(InvoiceID.Value, TransNo, Cid, Vid, InvoiceDate, Status, TotalAmount);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static bool Delete(int invoiceID)
        {
            return ClsCashInvoiceData.DeleteCashInvoice(invoiceID);
        }

        public static bool Exists(int invoiceID)
        {
            return ClsCashInvoiceData.IsCashInvoiceExists(invoiceID);
        }

        public static ClsCashInvoice Find(int invoiceID)
        {
            DataTable dt = ClsCashInvoiceData.GetCashInvoiceByID(invoiceID);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new ClsCashInvoice(
                invoiceID,
                row["TransNo"].ToString(),
                Convert.ToInt32(row["Cid"]),
                Convert.ToInt32(row["Vid"]),
                Convert.ToDateTime(row["InvoiceDate"]),
                row["Status"].ToString(),
                Convert.ToDecimal(row["TotalAmount"]),
                Convert.ToInt32(row["CreatedByEmployerID"])
            );
        }

        public static DataTable GetAll()
        {
            return ClsCashInvoiceData.GetAllCashInvoices();
        }

        public static DataTable GetInvoiecsList()
        {
            return ClsCashInvoiceData.GetInvoicesList();
        }

        public static string GetLastTransNoByDate(DateTime date)
        {
            return ClsCashInvoiceData.GetLastTransNoByDate(date);
        }

        public static string GenerateTransNo()
        {
            DateTime today = DateTime.Now;
            string datePart = today.ToString("yyyyMMdd");

            string lastTransNo = ClsCashInvoice.GetLastTransNoByDate(today);
            int count = 1;

            if (!string.IsNullOrEmpty(lastTransNo))
            {
                string lastNumberStr = lastTransNo.Substring(8, 4);
                if (int.TryParse(lastNumberStr, out int lastNumber))
                {
                    count = lastNumber + 1;
                }
            }

            return datePart + count.ToString("0000");
        }

        public decimal AddService(int sid, decimal price)
        {
            if (this.InvoiceID == null)
                throw new InvalidOperationException("Invoice must be saved first.");

            MessageBox.Show($"DEBUG → InvoiceID={InvoiceID}, ServiceID={sid}");

            ClsCashInvoiceService line = new ClsCashInvoiceService
            {
                InvoiceID = this.InvoiceID.Value,
                Sid = sid,
                Price = price
            };

            line.Save();
            _UpdateTotalAmount();

            return price;
        }

        private void _UpdateTotalAmount()
        {
            if (this.InvoiceID == null)
                return;

            ClsCashInvoiceData.UpdateTotalAmount(this.InvoiceID.Value);
        }

        public static DataTable GetReport()
        {
            return ClsCashInvoiceData.GetCashInvoiceReport();
        }

        public static DataTable GetReportByID(int invoiceID)
        {
            return ClsCashInvoiceData.GetCashInvoiceReportByID(invoiceID);
        }

        public static bool CancelInvoice(int invoiceID)
        {
            ClsCashInvoice invoice = ClsCashInvoice.Find(invoiceID);
            if (invoice == null) return false;
            invoice.Status = "Canceled";
            return invoice.Save();
        }
    }
}
