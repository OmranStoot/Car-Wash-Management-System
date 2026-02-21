using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.DAL
{
    public class ClsServiceData
    {
        public static DataTable GetAllServices()
        {
            return ClsDataAccessHelper.ExecuteQuery("SP_GetAllServices");
        }

        public static int? AddNewService(string name, decimal price)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@Price", SqlDbType.Decimal)
                {
                    Value = price,
                    Precision = 18,
                    Scale = 2
                }
            };

            object result = ClsDataAccessHelper.ExecuteScalar(
                "SP_AddNewService",
                parameters
            );

            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return null;
        }

        public static bool UpdateService(int serviceID, string name, decimal price)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ServiceID", SqlDbType.Int) { Value = serviceID },
                new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@Price", SqlDbType.Decimal)
                {
                    Value = price,
                    Precision = 18,
                    Scale = 2
                }
            };

            int rowsAffected = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_UpdateService",
                parameters
            );

            return rowsAffected > 0;
        }

        public static bool DeleteService(int serviceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ServiceID", SqlDbType.Int) { Value = serviceID }
            };

            int rowsAffected = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_DeleteService",
                parameters
            );

            return rowsAffected > 0;
        }

        public static bool IsServiceExists(int serviceID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ServiceID", SqlDbType.Int) { Value = serviceID }
            };

            object result = ClsDataAccessHelper.ExecuteScalar(
                "SP_IsServiceExists",
                parameters
            );

            return result != null;
        }

        public static bool GetServiceByID(int serviceID, ref string name, ref decimal price)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@ServiceID", SqlDbType.Int) { Value = serviceID }
            };

            DataTable dt = ClsDataAccessHelper.ExecuteQuery(
                "SP_GetServiceByID",
                parameters
            );

            if (dt.Rows.Count == 0)
                return false;

            DataRow row = dt.Rows[0];

            name = row["Name"].ToString();
            price = Convert.ToDecimal(row["Price"]);

            return true;
        }
    }
}
