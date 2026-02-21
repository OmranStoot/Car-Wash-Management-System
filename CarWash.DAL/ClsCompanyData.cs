using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.DAL
{
    public class ClsCompanyData
    {
        public static DataTable GetAllCompanies()
        {
            return ClsDataAccessHelper.ExecuteQuery(
                "SP_GetAllCompanies"
            );
        }

        public static int? AddNewCompany(string companyName, string address)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50) { Value = companyName },
                new SqlParameter("@Address", SqlDbType.NVarChar, 50) { Value = address }
            };

            object result = ClsDataAccessHelper.ExecuteScalar(
                "SP_AddNewCompany",
                parameters
            );

            if (result != null && int.TryParse(result.ToString(), out int id))
                return id;

            return null;
        }

        public static bool UpdateCompany(int companyID, string companyName, string address)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = companyID },
                new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50) { Value = companyName },
                new SqlParameter("@Address", SqlDbType.NVarChar, 50) { Value = address }
            };

            int rowsAffected = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_UpdateCompany",
                parameters
            );

            return rowsAffected > 0;
        }

        public static bool DeleteCompany(int companyID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = companyID }
            };

            int rowsAffected = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_DeleteCompany",
                parameters
            );

            return rowsAffected > 0;
        }

        public static bool GetCompanyByID(int companyID, ref string companyName, ref string address)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CompanyID", SqlDbType.Int) { Value = companyID }
            };

            DataTable dt = ClsDataAccessHelper.ExecuteQuery(
                "SP_GetCompanyInfoByID",
                parameters
            );

            if (dt.Rows.Count == 0)
                return false;

            DataRow row = dt.Rows[0];

            companyName = row["CompanyName"].ToString();
            address = row["Address"].ToString();

            return true;
        }
    }
}
