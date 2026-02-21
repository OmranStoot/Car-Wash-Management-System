using System;
using System.Data;
using System.Data.SqlClient;

namespace CarWash.DAL
{
    public class ClsCashInvoiceData
    {
        public static DataTable GetAllCashInvoices()
        {
            return ClsDataAccessHelper.ExecuteQuery("SP_GetAllCashInvoices");
        }

        public static DataTable GetInvoicesList()
        {
            return ClsDataAccessHelper.ExecuteQuery("SP_GetInvoicesList");
        }

        public static int? AddNewCashInvoice(
            string transNo,
            int cid,
            int vid,
            DateTime invoiceDate,
            string status,
            decimal totalAmount,
            int createdByEmployerID
        )
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@TransNo", SqlDbType.NVarChar, 50) { Value = transNo },
                new SqlParameter("@Cid", SqlDbType.Int) { Value = cid },
                new SqlParameter("@Vid", SqlDbType.Int) { Value = vid },
                new SqlParameter("@InvoiceDate", SqlDbType.DateTime) { Value = invoiceDate },
                new SqlParameter("@Status", SqlDbType.NVarChar, 50) { Value = status },
                new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = totalAmount },
                new SqlParameter("@CreatedByEmployerID", SqlDbType.Int) {Value = createdByEmployerID}
            };

            object result = ClsDataAccessHelper.ExecuteScalar("SP_AddNewCashInvoice", parameters);

            if (result != null)
                return Convert.ToInt32(result);

            return null;
        }

        public static bool UpdateCashInvoice(int invoiceID, string transNo, int cid, int vid, DateTime invoiceDate, string status, decimal totalAmount)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID },
                new SqlParameter("@TransNo", SqlDbType.NVarChar, 50) { Value = transNo },
                new SqlParameter("@Cid", SqlDbType.Int) { Value = cid },
                new SqlParameter("@Vid", SqlDbType.Int) { Value = vid },
                new SqlParameter("@InvoiceDate", SqlDbType.DateTime) { Value = invoiceDate },
                new SqlParameter("@Status", SqlDbType.NVarChar, 50) { Value = status },
                new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = totalAmount }
            };

            int rows = ClsDataAccessHelper.ExecuteNonQuery("SP_UpdateCashInvoice", parameters);
            return rows > 0;
        }

        public static bool DeleteCashInvoice(int invoiceID)
        {
            SqlParameter[] parameters = { new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID } };
            int rows = ClsDataAccessHelper.ExecuteNonQuery("SP_DeleteCashInvoice", parameters);
            return rows > 0;
        }

        public static bool IsCashInvoiceExists(int invoiceID)
        {
            SqlParameter[] parameters = { new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID } };
            object result = ClsDataAccessHelper.ExecuteScalar("SP_IsCashInvoiceExists", parameters);
            return result != null;
        }

        public static DataTable GetCashInvoiceByID(int invoiceID)
        {
            SqlParameter[] parameters = { new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID } };
            return ClsDataAccessHelper.ExecuteQuery("SP_GetCashInvoiceByID", parameters);
        }

        public static string GetLastTransNoByDate(DateTime invoiceDate)
        {
            SqlParameter[] parameters = { new SqlParameter("@InvoiceDate", SqlDbType.Date) { Value = invoiceDate.Date } };
            object result = ClsDataAccessHelper.ExecuteScalar("SP_GetLastTransNoByDate", parameters);
            return result?.ToString();
        }

        public static void UpdateTotalAmount(int invoiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int)
                {
                    Value = invoiceID
                }
            };

            ClsDataAccessHelper.ExecuteNonQuery(
                "SP_UpdateInvoiceTotal",
                parameters
            );
        }

        public static DataTable GetCashInvoiceReport()
        {
            return ClsDataAccessHelper.ExecuteQuery(
                "SP_GetCashInvoiceReport");
        }

        public static DataTable GetCashInvoiceReportByID(int invoiceID)
        {
            SqlParameter[] parameters =
            {
        new SqlParameter("@InvoiceID", SqlDbType.Int)
        {
            Value = invoiceID
        }
    };

            return ClsDataAccessHelper.ExecuteQuery(
                "SP_GetCashInvoiceReportByID",
                parameters
            );
        }

        public static DataTable GetInvoiceHeader(int invoiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@invoiceID", invoiceID)
            };
            return ClsDataAccessHelper.ExecuteQuery("SP_GetInvoiceDetails_Header", parameters);
        }

        public static DataTable GetInvoiceServices(int invoiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@invoiceID", invoiceID)
            };
            return ClsDataAccessHelper.ExecuteQuery("SP_GetInvoiceServices", parameters);
        }

        public static DataTable GetInvoicePayments(int invoiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@invoiceID", invoiceID)
            };
            return ClsDataAccessHelper.ExecuteQuery("SP_GetInvoicePayments", parameters);
        }



    }
}
