using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarWash.DAL
{
    public class ClsEmployerData
    {
        public static bool GetEmployerInfoByID(
            int employerID,
            ref string name,
            ref string phone,
            ref string address,
            ref DateTime dob,
            ref string role,
            ref double salary,
            ref string password,
            ref int gender,
            ref int permissions)
        {
            bool isFound = false;
            SqlParameter[] parameters = { new SqlParameter("@EmployerID", SqlDbType.Int) { Value = employerID } };
            DataTable dt = ClsDataAccessHelper.ExecuteQuery("SP_GetEmployerInfoByID", parameters);

            if(dt.Rows.Count > 0)
            {
                isFound = true;
                DataRow row = dt.Rows[0];   
                name = (string)row["Name"];
                phone = (string)row["Phone"];
                address = (string)row["Address"];
                dob = (DateTime)row["Dob"];
                role = (string)row["Role"];
                salary = Convert.ToDouble(row["Salary"]);
                password = (string)row["Password"];
                gender = (byte)row["Gender"];
                permissions = (int)row["Permissions"];
            }
            return isFound;
        }

        public static int? AddNewEmployer(string name, string phone, string address,
            DateTime dob, string role, double salary,
            string password, int gender, int permissions)

        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = name },
                new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = phone },
                new SqlParameter("@Address", SqlDbType.NVarChar, 200) { Value = address },
                new SqlParameter("@Dob", SqlDbType.Date) { Value = dob },
                new SqlParameter("@Role", SqlDbType.NVarChar, 50) { Value = role },
                new SqlParameter("@Salary", SqlDbType.Decimal) { Value = salary },
                new SqlParameter("@Password", SqlDbType.NVarChar, 50) { Value = password },
                new SqlParameter("@Gender", SqlDbType.TinyInt) { Value = gender },
                new SqlParameter("@Permissions", SqlDbType.Int) { Value = permissions }
            };
            object result = ClsDataAccessHelper.ExecuteScalar("SP_AddNewEmployer", parameters);
            return (result != null && int.TryParse(result.ToString(), out int id)) ? (int?)id : null;
        }

        public static bool UpdateEmployer(int employerID, string name, string phone, string address, DateTime dob, string role, double salary, string password, int gender, int permissions)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmployerID", SqlDbType.Int) { Value = employerID },
                new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = name },
                new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = phone },
                new SqlParameter("@Address", SqlDbType.NVarChar, 200) { Value = address },
                new SqlParameter("@Dob", SqlDbType.Date) { Value = dob },
                new SqlParameter("@Role", SqlDbType.NVarChar, 50) { Value = role },
                new SqlParameter("@Salary", SqlDbType.Decimal) { Value = salary },
                new SqlParameter("@Password", SqlDbType.NVarChar, 50) { Value = password },
                new SqlParameter("@Gender", SqlDbType.TinyInt) { Value = gender },
                new SqlParameter("@Permissions", SqlDbType.Int) { Value = permissions }
            };
            return (ClsDataAccessHelper.ExecuteNonQuery("SP_UpdateEmployer", parameters) > 0);
        }

        public static bool DeleteEmployer(int employerID)
        {
            SqlParameter[] parameters = { new SqlParameter("@EmployerID", SqlDbType.Int) { Value = employerID } };

            return (ClsDataAccessHelper.ExecuteNonQuery("SP_DeleteEmployer", parameters) > 0);
        }

        public static DataTable GetAllEmployer()
        {
           return ClsDataAccessHelper.ExecuteQuery("SP_GetAllEmployer");
        }

        public static bool IsEmployerExist(int employerID)
        {
            bool isFound = false;
            SqlParameter[] parameters = { new SqlParameter("@EmployerID", SqlDbType.Int) {Value = employerID} };

            object result = ClsDataAccessHelper.ExecuteScalar("SP_IsEmployerExist", parameters);

            if (result != null) 
                isFound = true;
            return isFound;
        }

        public static bool GetEmployerByUserNameAndPassword(
            string name, string password,
            ref int employerID,
            ref string phone,
            ref string address,
            ref DateTime dob,
            ref string role,
            ref double salary,
            ref int gender,
            ref int permissions)
                {
                    bool isFound = false;

                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@UserName", name),
                        new SqlParameter("@Password", password)
                    };
                    DataTable dt = ClsDataAccessHelper.ExecuteQuery("SP_GetEmployerByUserNameAndPassword", parameters);

                    if (dt.Rows.Count > 0)
                    {
                        isFound = true;
                        DataRow row = dt.Rows[0];
                        employerID = (int)row["EmployerID"];
                        phone = (string)row["Phone"];
                        address = (string)row["Address"];
                        dob = (DateTime)row["Dob"];
                        role = (string)row["Role"];
                        salary = Convert.ToDouble(row["Salary"]);
                        password = (string)row["Password"];
                        gender = (byte)row["Gender"];
                        permissions = (int)row["Permissions"];
            }
                    return isFound;
                }
    }
}
