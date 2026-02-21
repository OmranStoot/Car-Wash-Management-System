using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsCostOfGood
    {
        public int? CostID { get; private set; }
        public string CostName { get; set; }
        public decimal Cost { get; set; }
        public DateTime CostDate { get; set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public ClsCostOfGood()
        {
            CostID = null;
            CostName = string.Empty;
            Cost = 0;
            CostDate = DateTime.Now;
            _Mode = enMode.AddNew;
        }

        private ClsCostOfGood(int costID, string costName, decimal cost, DateTime costDate)
        {
            CostID = costID;
            CostName = costName;
            Cost = cost;
            CostDate = costDate;
            _Mode = enMode.Update;
        }

        private bool _AddNewCostOfGood()
        {
            this.CostID = ClsCostOfGoodData.AddNewCostOfGood(
                this.CostName,
                this.Cost,
                this.CostDate);

            return (CostID != null);
        }

        private bool _UpdateCostOfGood()
        {
            if (this.CostID == null)
                return false;

            return ClsCostOfGoodData.UpdateCostOfGood(
                this.CostID.Value,
                this.CostName,
                this.Cost,
                this.CostDate);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCostOfGood())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateCostOfGood();
            }
            return false;
        }

        public static bool Delete(int costID)
        {
            return ClsCostOfGoodData.DeleteCostOfGood(costID);
        }

        public static ClsCostOfGood Find(int costID)
        {
            string costName = string.Empty;
            decimal cost = 0;
            DateTime costDate = DateTime.Now;

            bool isFound = ClsCostOfGoodData.GetCostOfGoodByID(
                costID,
                ref costName,
                ref cost,
                ref costDate);

            if (isFound)
                return new ClsCostOfGood(costID, costName, cost, costDate);

            return null;
        }

        public static DataTable GetAllCostOfGoods()
        {
            return ClsCostOfGoodData.GetAllCostOfGoods();
        }
    }
}
