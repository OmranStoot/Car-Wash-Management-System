using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsReports
    {
        public static DataTable GetTopSellingServices(DateTime startDate, DateTime endDate)
        {
            return ClsReportsData.GetTopSellingServices(startDate, endDate);
        }

        public static DataTable GetRevenues(DateTime startDate, DateTime endDate)
        {
            return ClsReportsData.GetRevenues(startDate, endDate);
        }

        public static decimal CalculateTotalRevenue(DataTable dt)
        {
            decimal total = 0.00m;

            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToDecimal(dr["TotalPrice"]);
            }

            return total;

        }

        public static DataTable GetCostOfGoods(DateTime startDate, DateTime endDate)
        {
            return ClsReportsData.GetCostOfGoods(startDate, endDate);
        }

        public static decimal CalculateTotalCosts(DataTable dt)
        {
            decimal total = 0.00m;

            foreach(DataRow dr in dt.Rows)
            {
                total += Convert.ToDecimal(dr["Cost"]);
            }
            return total;
        }

        public static decimal GetRevenueLast7Days()
        {
            DateTime endDate = DateTime.Now;
            DateTime startDate = endDate.AddDays(-6);

            DataTable dt = GetRevenues(startDate, endDate);
            return CalculateTotalRevenue(dt);
        }

        public static decimal GetCostsLast7Days()
        {
            DateTime endDate = DateTime.Now;
            DateTime startDate = endDate.AddDays(-6);

            DataTable dt = GetCostOfGoods(startDate, endDate);
            return CalculateTotalCosts(dt);

        }
    }
}
