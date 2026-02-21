using System;
using System.Data;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsCustomer
    {
        public int? CustomerID { get; private set; }
        public int Vid { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CarNo { get; set; }
        public string CarModel { get; set; }
        public string Address { get; set; }
        public int Points { get; set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public ClsCustomer()
        {
            CustomerID = null;
            Vid = 0;
            Name = string.Empty;
            Phone = string.Empty;
            CarNo = string.Empty;
            CarModel = string.Empty;
            Address = string.Empty;
            Points = 0;

            _Mode = enMode.AddNew;
        }

        private ClsCustomer(int customerID, int vid, string name, string phone,
            string carNo, string carModel, string address, int points)
        {
            CustomerID = customerID;
            Vid = vid;
            Name = name;
            Phone = phone;
            CarNo = carNo;
            CarModel = carModel;
            Address = address;
            Points = points;

            _Mode = enMode.Update;
        }

        private bool _AddNewCustomer()
        {
            CustomerID = ClsCustomerData.AddNewCustomer(
                Vid, Name, Phone, CarNo, CarModel, Address, Points);

            return CustomerID != null;
        }

        private bool _UpdateCustomer()
        {
            if (CustomerID == null)
                return false;

            return ClsCustomerData.UpdateCustomer(
                CustomerID.Value, Vid, Name, Phone, CarNo, CarModel, Address, Points);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCustomer())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateCustomer();
            }

            return false;
        }

        public static bool Delete(int customerID)
        {
            return ClsCustomerData.DeleteCustomer(customerID);
        }

        public static bool Exists(int customerID)
        {
            return ClsCustomerData.IsCustomerExists(customerID);
        }

        public static ClsCustomer Find(int customerID)
        {
            int vid = 0;
            string name = string.Empty;
            string phone = string.Empty;
            string carNo = string.Empty;
            string carModel = string.Empty;
            string address = string.Empty;
            int points = 0;

            bool isFound = ClsCustomerData.GetCustomerByID(
                customerID, ref vid, ref name, ref phone,
                ref carNo, ref carModel, ref address, ref points);

            if (isFound)
                return new ClsCustomer(customerID, vid, name, phone, carNo, carModel, address, points);

            return null;
        }

        public static DataTable GetAllCustomers()
        {
            return ClsCustomerData.GetAllCustomers();
        }

        public bool UpdatePoints(int points)
        {
            if (CustomerID == null)
                return false;

            if (ClsCustomerData.UpdateCustomerPoints(CustomerID.Value, points))
            {
                Points = points;
                return true;
            }

            return false;
        }
    }
}
