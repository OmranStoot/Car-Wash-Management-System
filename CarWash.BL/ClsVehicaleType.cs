using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsVehicaleType
    {
        public int? VehicaleTypeID { get; private set; }
        public string Name { get; set; }
        public string Class { get; set; }
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public ClsVehicaleType()
        {
            VehicaleTypeID = null;
            Name = string.Empty;
            Class = string.Empty;
            _Mode = enMode.AddNew;
        }

        private ClsVehicaleType(int vehicaleTypeID, string name, string @class)
        {
            VehicaleTypeID = vehicaleTypeID;
            Name = name;
            Class = @class;
            _Mode = enMode.Update;
        }

        private bool _AddNewVehicaleType()
        {
            this.VehicaleTypeID = ClsVehicaleTypeData.AddNewVehicaleType(
                this.Name, this.Class);
            return (VehicaleTypeID != null);
        }

        private bool _UpdateVehicaleType()
        {
            if (this.VehicaleTypeID == null)
                return false;
            return ClsVehicaleTypeData.UpdateVehicaleType(
                this.VehicaleTypeID.Value,
                this.Name, this.Class);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewVehicaleType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateVehicaleType();
            }
            return false;
        }

        public static bool Delete(int vehicaleTypeID)
        {
            return ClsVehicaleTypeData.DeleteVehicaleType(vehicaleTypeID);
        }

        public static bool Exists(int vehicaleTypeID)
        {
            return ClsVehicaleTypeData.IsVehicaleTypeExists(vehicaleTypeID);
        }

        public static ClsVehicaleType Find(int vehicaleTypeID)
        {
            string name = string.Empty;
            string @class = string.Empty;

            bool isFound = ClsVehicaleTypeData.GetVehicaleTypeByID(vehicaleTypeID, ref name, ref @class);
            if (isFound)
                return new ClsVehicaleType(vehicaleTypeID, name, @class);
            return null;


        }

        public static DataTable GetAllVehicaleTypes()
        {
            return ClsVehicaleTypeData.GetAllVehicaleTypes();
        }
    }
}
