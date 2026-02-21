using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsCompany
    {
        public int? CompanyID { get; private set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public ClsCompany()
        {
            CompanyID = null;
            CompanyName = string.Empty;
            Address = string.Empty;
            _Mode = enMode.AddNew;
        }

        private ClsCompany(int companyID, string companyName, string address)
        {
            CompanyID = companyID;
            CompanyName = companyName;
            Address = address;
            _Mode = enMode.Update;
        }

        private bool _AddNewCompany()
        {
            this.CompanyID = ClsCompanyData.AddNewCompany(
                this.CompanyName,
                this.Address
            );

            return (CompanyID != null);
        }

        private bool _UpdateCompany()
        {
            if (CompanyID == null)
                return false;

            return ClsCompanyData.UpdateCompany(
                CompanyID.Value,
                CompanyName,
                Address
            );
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCompany())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateCompany();
            }

            return false;
        }

        public static bool Delete(int companyID)
        {
            return ClsCompanyData.DeleteCompany(companyID);
        }

        public static ClsCompany Find(int companyID)
        {
            string companyName = string.Empty;
            string address = string.Empty;

            bool isFound = ClsCompanyData.GetCompanyByID(
                companyID,
                ref companyName,
                ref address
            );

            if (isFound)
                return new ClsCompany(companyID, companyName, address);

            return null;
        }

        public static DataTable GetAllCompanies()
        {
            return ClsCompanyData.GetAllCompanies();
        }

        public static ClsCompany GetCompany()
        {
            DataTable dt = ClsCompanyData.GetAllCompanies();

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new ClsCompany(
                (int)row["CompanyID"],
                row["CompanyName"].ToString(),
                row["Address"].ToString()
            );
        }
    }
}
