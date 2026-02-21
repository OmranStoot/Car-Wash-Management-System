using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.DAL
{
    public class ClsVehicaleTypeData
    {
        public static DataTable GetAllVehicaleTypes()
        {
            return ClsDataAccessHelper.ExecuteQuery(
                "SP_GetAllVehicaleTypes"
            );
        }

        public static int? AddNewVehicaleType(string name, string @class)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@Class", SqlDbType.NVarChar, 50) { Value = @class }
            };

            object result = ClsDataAccessHelper.ExecuteScalar(
                "SP_AddNewVehicaleType",
                parameters
            );

            if (result != null && int.TryParse(result.ToString(), out int id))
                return id;

            return null;
        }

        public static bool UpdateVehicaleType(int vehicaleTypeID, string name, string @class)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@VehicaleTypeID", SqlDbType.Int) { Value = vehicaleTypeID },
                new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@Class", SqlDbType.NVarChar, 50) { Value = @class }
            };

            int rowsAffected = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_UpdateVehicaleType",
                parameters
            );

            return rowsAffected > 0;
        }

        public static bool DeleteVehicaleType(int vehicaleTypeID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@VehicaleTypeID", SqlDbType.Int) { Value = vehicaleTypeID }
            };

            int rowsAffected = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_DeleteVehicaleType",
                parameters
            );

            return rowsAffected > 0;
        }

        public static bool IsVehicaleTypeExists(int vehicaleTypeID)
        {
            bool isFound = false;
            SqlParameter[] parameters = { new SqlParameter("@VehicaleTypeID", SqlDbType.Int) { Value = vehicaleTypeID } };

            object result = ClsDataAccessHelper.ExecuteScalar("SP_IsVehicaleTypeExists", parameters);

            if (result != null)
                isFound = true;
            return isFound;

        }

        public static bool GetVehicaleTypeByID(int vehicaleTypeID, ref string name, ref string @class)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@VehicaleTypeID", SqlDbType.Int) { Value = vehicaleTypeID }
            };

            DataTable dt = ClsDataAccessHelper.ExecuteQuery(
                "SP_GetVehicaleTypeByID",
                parameters
            );

            if (dt.Rows.Count == 0)
                return false;

            DataRow row = dt.Rows[0];

            name = row["Name"].ToString();
            @class = row["Class"].ToString();

            return true;
        }
    }
}
