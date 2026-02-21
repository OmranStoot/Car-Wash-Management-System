using System;
using System.Data;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsCashInvoiceService
    {
        public int? InvoiceServiceID { get; private set; }
        public int InvoiceID { get; set; }
        public int Sid { get; set; }
        public decimal Price { get; set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public ClsCashInvoiceService()
        {
            InvoiceServiceID = null;
            InvoiceID = -1;
            Sid = -1;
            Price = 0;
            _Mode = enMode.AddNew;
        }

        private ClsCashInvoiceService(int invoiceServiceID, int invoiceID, int sid, decimal price)
        {
            InvoiceServiceID = invoiceServiceID;
            InvoiceID = invoiceID;
            Sid = sid;
            Price = price;
            _Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.InvoiceServiceID = ClsCashInvoiceServiceData.AddNewCashInvoiceService(InvoiceID, Sid, Price);
            return InvoiceServiceID != null;
        }

        private bool _Update()
        {
            if (InvoiceServiceID == null) return false;
            return ClsCashInvoiceServiceData.UpdateCashInvoiceService(InvoiceServiceID.Value, InvoiceID, Sid, Price);
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

        public static bool Delete(int invoiceServiceID)
        {
            return ClsCashInvoiceServiceData.DeleteCashInvoiceService(invoiceServiceID);
        }

        public static bool Exists(int invoiceServiceID)
        {
            return ClsCashInvoiceServiceData.IsCashInvoiceServiceExists(invoiceServiceID);
        }

        public static ClsCashInvoiceService Find(int invoiceServiceID)
        {
            DataTable dt = ClsCashInvoiceServiceData.GetCashInvoiceServiceByID(invoiceServiceID);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new ClsCashInvoiceService(
                invoiceServiceID,
                Convert.ToInt32(row["InvoiceID"]),
                Convert.ToInt32(row["Sid"]),
                Convert.ToDecimal(row["Price"])
            );
        }

        public static DataTable GetAll()
        {
            return ClsCashInvoiceServiceData.GetAllCashInvoiceServices();
        }

        public static DataTable GetByInvoiceID(int invoiceID)
        {
            return ClsCashInvoiceServiceData.GetServicesByInvoiceID(invoiceID);
        }
    }
}
