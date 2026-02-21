using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.DAL
{
    public class ClsCustomerData
    {
        public static DataTable GetAllCustomers()
        {
            return ClsDataAccessHelper.ExecuteQuery("SP_GetAllCustomers");
        }

        public static int? AddNewCustomer(int vid, string name, string phone,
            string carNo, string carModel, string address, int points)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Vid", SqlDbType.Int) { Value = vid },
                new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = phone },
                new SqlParameter("@CarNo", SqlDbType.NVarChar, 50) { Value = carNo },
                new SqlParameter("@CarModel", SqlDbType.NVarChar, 50) { Value = carModel },
                new SqlParameter("@Address", SqlDbType.NVarChar, 200) { Value = address },
                new SqlParameter("@Points", SqlDbType.Int) { Value = points }
            };

            object result =
                ClsDataAccessHelper.ExecuteScalar("SP_AddNewCustomer", parameters);

            if (result != null && int.TryParse(result.ToString(), out int id))
                return id;

            return null;
        }

        public static bool UpdateCustomer(int customerID, int vid, string name, string phone,
            string carNo, string carModel, string address, int points)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerID },
                new SqlParameter("@Vid", SqlDbType.Int) { Value = vid },
                new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = phone },
                new SqlParameter("@CarNo", SqlDbType.NVarChar, 50) { Value = carNo },
                new SqlParameter("@CarModel", SqlDbType.NVarChar, 50) { Value = carModel },
                new SqlParameter("@Address", SqlDbType.NVarChar, 200) { Value = address },
                new SqlParameter("@Points", SqlDbType.Int) { Value = points }
            };

            int rowsAffected =
                ClsDataAccessHelper.ExecuteNonQuery("SP_UpdateCustomer", parameters);

            return rowsAffected > 0;
        }

        public static bool DeleteCustomer(int customerID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerID }
            };

            int rowsAffected =
                ClsDataAccessHelper.ExecuteNonQuery("SP_DeleteCustomer", parameters);

            return rowsAffected > 0;
        }

        public static bool IsCustomerExists(int customerID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerID }
            };

            object result =
                ClsDataAccessHelper.ExecuteScalar("SP_IsCustomerExists", parameters);

            return result != null;
        }

        public static bool GetCustomerByID(int customerID,
            ref int vid,
            ref string name,
            ref string phone,
            ref string carNo,
            ref string carModel,
            ref string address,
            ref int points)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerID }
            };

            DataTable dt =
                ClsDataAccessHelper.ExecuteQuery("SP_GetCustomerInfoByID", parameters);

            if (dt.Rows.Count == 0)
                return false;

            DataRow row = dt.Rows[0];

            vid = (int)row["Vid"];
            name = row["Name"].ToString();
            phone = row["Phone"].ToString();
            carNo = row["CarNo"].ToString();
            carModel = row["CarModel"].ToString();
            address = row["Address"].ToString();
            points = (int)row["Points"];

            return true;
        }

        public static bool UpdateCustomerPoints(int customerID, int points)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerID", SqlDbType.Int) { Value = customerID },
                new SqlParameter("@Points", SqlDbType.Int) { Value = points }
            };

            int rowsAffected =
                ClsDataAccessHelper.ExecuteNonQuery("SP_UpdateCustomerPoints", parameters);

            return rowsAffected > 0;
        }
    }
}
