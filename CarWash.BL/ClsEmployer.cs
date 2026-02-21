using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.DAL;

namespace CarWash.BL
{
    public class ClsEmployer
    {
        public enum enMode { AddNew = 0, Update =1 }
        public enMode Mode = enMode.AddNew;
        public int? EmployerID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Dob {  get; set; }
        public string Role { get; set; }    
        public double Salary { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }

        public Permissions Permissions { get; set; }


        public ClsEmployer()
        {
            this.EmployerID = null;
            this.Name = string.Empty;
            this.Phone = string.Empty;
            this.Address = string.Empty;
            this.Dob = DateTime.MinValue;
            this.Role = string.Empty;
            this.Salary = 0;
            this.Password = string.Empty;
            this.Gender = -1;
            this.Permissions = Permissions.None;

            Mode = enMode.AddNew;
        }
        public ClsEmployer(int? employerID, string name, string phone, string address, DateTime dob, string role, double salary, string password, int gender, Permissions permissions)
        {
            Mode = enMode.Update;
            EmployerID = employerID;
            Name = name;
            Phone = phone;
            Address = address;
            Dob = dob;
            Role = role;
            Salary = salary;
            Password = password;
            Gender = gender;
            Permissions = permissions;
        }

        public static ClsEmployer Find(int EmployerID)
        {
            string name = string.Empty, phone = string.Empty, 
                address = string.Empty, role = string.Empty, 
                password = string.Empty;
            double salary = 0;
            DateTime dob = DateTime.MinValue;
            int gender = -1;
            int permissions = 0;

            bool isFound = ClsEmployerData.GetEmployerInfoByID(
                EmployerID, ref name, ref phone, ref address,
                ref dob, ref role, ref salary, ref password,
                ref gender, ref permissions);

            if (isFound)
                return new ClsEmployer(
                    EmployerID, name, phone, address,
                    dob, role, salary, password, gender,
                    (Permissions)permissions);
            else 
                return null;
        }

        private bool _AddNewEmployer()
        {
            this.EmployerID = ClsEmployerData.AddNewEmployer(
                Name, Phone, Address, Dob, Role,
                Salary, Password, Gender,
                (int)this.Permissions);
            return (EmployerID != null);
        }

        private bool _UpdateEmployer()
        {
            if(this.EmployerID == null)
                return false;
            return ClsEmployerData.UpdateEmployer(
                EmployerID.Value,
                Name, Phone, Address, Dob,
                Role, Salary, Password, Gender,
                (int)this.Permissions);
        }

        private static Permissions GetPermissionsByRole(string role)
        {
            switch (role)
            {
                case "Manager":
                    return Permissions.All;

                case "Supervisor":
                    return Permissions.ViewCustomers
                         | Permissions.ViewInvoices
                         | Permissions.ViewReports
                         | Permissions.ManageServices;

                case "Cashier":
                    return Permissions.CashOperations
                         | Permissions.ViewInvoices;

                case "Worker":
                    return Permissions.ViewCustomers;

                default:
                    return Permissions.None;
            }
        }

        public bool Save()
        {
            this.Permissions = GetPermissionsByRole(this.Role);
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewEmployer())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateEmployer();
            }
            return false;
        }

        public static DataTable GetAllEmployers()
        {
            return ClsEmployerData.GetAllEmployer();
        }

        public static bool DeleteEmployer(int employerID)
        {
            return ClsEmployerData.DeleteEmployer(employerID);
        }

        public static bool IsEmployerExist(int employerID)
        {
            return ClsEmployerData.IsEmployerExist(employerID);
        }

        public static ClsEmployer FindByUserNameAndPassword(string name, string password)
        {
            int employerID = -1;
            string phone = string.Empty,
            address = string.Empty, role = string.Empty;
            double salary = 0;
            DateTime dob = DateTime.MinValue;
            int gender = -1;
            int permissions = 0;

            bool isFound = ClsEmployerData.GetEmployerByUserNameAndPassword(
                name, password,
                ref employerID, ref phone, ref address,
                ref dob, ref role, ref salary,
                ref gender, ref permissions);

            if (isFound)
                return new ClsEmployer(
                    employerID, name, phone, address,
                    dob, role, salary, password,
                    gender, (Permissions)permissions);
            else
                return null;

        }

        public bool HasPermissions(Permissions permission)
        {
            if(Permissions == Permissions.All) return true;

            return (Permissions & permission) == permission;
        }
    }
}
