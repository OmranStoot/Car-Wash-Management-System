using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.DAL
{
    public class ClsReportsData
    {
        public static DataTable GetTopSellingServices(DateTime startDate, DateTime endDate)
        {
            SqlParameter[] parameters =
{
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            return ClsDataAccessHelper.ExecuteQuery("SP_GetTopSellingServices", parameters);
        }

        public static DataTable GetRevenues(DateTime startDate, DateTime endDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };
            return ClsDataAccessHelper.ExecuteQuery("SP_GetRevenuePerDay", parameters);
        }

        public static DataTable GetCostOfGoods(DateTime startDate, DateTime endDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate),
            };

            return ClsDataAccessHelper.ExecuteQuery("SP_GetCostOfGoodsByDate", parameters);
        }
    }
}
