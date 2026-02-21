using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.DAL
{
    public class ClsCostOfGoodData
    {
        public static DataTable GetAllCostOfGoods()
        {
            return ClsDataAccessHelper.ExecuteQuery(
                "SP_GetAllCostOfGoods"
            );
        }

        public static int? AddNewCostOfGood(string costName, decimal cost, DateTime costDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CostName", SqlDbType.NVarChar, 50) { Value = costName },
                new SqlParameter("@Cost", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = cost
                },
                new SqlParameter("@CostDate", SqlDbType.Date) { Value = costDate }
            };

            object result = ClsDataAccessHelper.ExecuteScalar(
                "SP_AddNewCostOfGood",
                parameters
            );

            if (result != null && int.TryParse(result.ToString(), out int id))
                return id;

            return null;
        }

        public static bool UpdateCostOfGood(int costID, string costName, decimal cost, DateTime costDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CostID", SqlDbType.Int) { Value = costID },
                new SqlParameter("@CostName", SqlDbType.NVarChar, 50) { Value = costName },
                new SqlParameter("@Cost", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Value = cost
                },
                new SqlParameter("@CostDate", SqlDbType.Date) { Value = costDate }
            };

            int rowsAffected = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_UpdateCostOfGood",
                parameters
            );

            return rowsAffected > 0;
        }

        public static bool DeleteCostOfGood(int costID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CostID", SqlDbType.Int) { Value = costID }
            };

            int rowsAffected = ClsDataAccessHelper.ExecuteNonQuery(
                "SP_DeleteCostOfGood",
                parameters
            );

            return rowsAffected > 0;
        }

        public static bool GetCostOfGoodByID(
            int costID,
            ref string costName,
            ref decimal cost,
            ref DateTime costDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@CostID", SqlDbType.Int) { Value = costID }
            };

            DataTable dt = ClsDataAccessHelper.ExecuteQuery(
                "SP_GetCostOfGoodInfoByID",
                parameters
            );

            if (dt.Rows.Count == 0)
                return false;

            DataRow row = dt.Rows[0];

            costName = row["CostName"].ToString();
            cost = Convert.ToDecimal(row["Cost"]);
            costDate = Convert.ToDateTime(row["CostDate"]);

            return true;
        }

    }
}
