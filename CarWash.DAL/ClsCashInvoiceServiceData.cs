using System;
using System.Data;
using System.Data.SqlClient;

namespace CarWash.DAL
{
    public class ClsCashInvoiceServiceData
    {
        public static DataTable GetAllCashInvoiceServices()
        {
            return ClsDataAccessHelper.ExecuteQuery("SP_GetAllCashInvoiceServices");
        }

        public static int? AddNewCashInvoiceService(int invoiceID, int sid, decimal price)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID },
                new SqlParameter("@Sid", SqlDbType.Int) { Value = sid },
                new SqlParameter("@Price", SqlDbType.Decimal) { Value = price }
            };

            object result = ClsDataAccessHelper.ExecuteScalar("SP_AddNewCashInvoiceService", parameters);
            if (result != null && int.TryParse(result.ToString(), out int id))
                return id;

            return null;
        }

        public static bool UpdateCashInvoiceService(int invoiceServiceID, int invoiceID, int sid, decimal price)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceServiceID", SqlDbType.Int) { Value = invoiceServiceID },
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID },
                new SqlParameter("@Sid", SqlDbType.Int) { Value = sid },
                new SqlParameter("@Price", SqlDbType.Decimal) { Value = price }
            };

            int rows = ClsDataAccessHelper.ExecuteNonQuery("SP_UpdateCashInvoiceService", parameters);
            return rows > 0;
        }

        public static bool DeleteCashInvoiceService(int invoiceServiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceServiceID", SqlDbType.Int) { Value = invoiceServiceID }
            };

            int rows = ClsDataAccessHelper.ExecuteNonQuery("SP_DeleteCashInvoiceService", parameters);
            return rows > 0;
        }

        public static bool IsCashInvoiceServiceExists(int invoiceServiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceServiceID", SqlDbType.Int) { Value = invoiceServiceID }
            };

            object result = ClsDataAccessHelper.ExecuteScalar("SP_IsCashInvoiceServiceExists", parameters);
            return result != null;
        }

        public static DataTable GetCashInvoiceServiceByID(int invoiceServiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceServiceID", SqlDbType.Int) { Value = invoiceServiceID }
            };

            return ClsDataAccessHelper.ExecuteQuery("SP_GetCashInvoiceServiceByID", parameters);
        }

        public static DataTable GetServicesByInvoiceID(int invoiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID }
            };

            return ClsDataAccessHelper.ExecuteQuery("SP_GetServicesByInvoiceID", parameters);
        }
    }
}
