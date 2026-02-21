using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.DAL
{
    public class ClsPaymentData
    {
        public static bool AddPayment(
            int invoiceID,
            decimal amount,
            string paymentMethod,
            string notes,
            int paidByEmployerID
        )
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID },
                new SqlParameter("@Amount", SqlDbType.Decimal) { Value = amount },
                new SqlParameter("@PaymentMethod", SqlDbType.NVarChar, 50) { Value = paymentMethod },
                new SqlParameter("@Notes", SqlDbType.NVarChar, 200) { Value = notes },
                new SqlParameter("@PaidByEmployerID", SqlDbType.Int) {Value = paidByEmployerID}
            };

            int rows = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_AddNewPayment",
                parameters
            );

            return rows > 0;
        }

        public static DataTable GetPaymentsByInvoice(int invoiceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID }
            };

            return ClsDataAccessHelper.ExecuteQuery(
                "SP_GetPaymentsByInvoice",
                parameters
            );
        }
    }
}
