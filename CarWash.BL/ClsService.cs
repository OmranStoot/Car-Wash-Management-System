using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsService
    {
        public int? ServiceID { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public ClsService()
        {
            ServiceID = null;
            Name = string.Empty;
            Price = 0;
            _Mode = enMode.AddNew;
        }

        private ClsService(int serviceID, string name, decimal price)
        {
            ServiceID = serviceID;
            Name = name;
            Price = price;
            _Mode = enMode.Update;
        }

        private bool _AddNewService()
        {
            this.ServiceID = ClsServiceData.AddNewService(
                this.Name, this.Price);

            return (ServiceID != null);
        }

        private bool _UpdateService()
        {
            if (ServiceID == null)
                return false;

            return ClsServiceData.UpdateService(
                ServiceID.Value,
                Name,
                Price
            );
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewService())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateService();
            }
            return false;
        }

        public static bool Delete(int serviceID)
        {
            return ClsServiceData.DeleteService(serviceID);
        }

        public static bool Exists(int serviceID)
        {
            return ClsServiceData.IsServiceExists(serviceID);
        }

        public static ClsService Find(int serviceID)
        {
            string name = string.Empty;
            decimal price = 0;

            if (ClsServiceData.GetServiceByID(serviceID, ref name, ref price))
                return new ClsService(serviceID, name, price);

            return null;
        }

        public static DataTable GetAllServices()
        {
            return ClsServiceData.GetAllServices();
        }
    }
}
