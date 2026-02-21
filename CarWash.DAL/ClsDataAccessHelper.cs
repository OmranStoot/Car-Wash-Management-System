using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash.DAL
{
    public class ClsDataAccessHelper
    {
        public static DataTable ExecuteQuery(string spName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(spName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"ExecuteQuery Error\nSP: {spName}\n\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                throw;
            }

            return dt;
        }

        public static object ExecuteScalar(string spName, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(spName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    connection.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"ExecuteScalar Error\nSP: {spName}\n\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                throw;
            }
        }

        public static int ExecuteNonQuery(string spName, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(spName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"ExecuteNonQuery Error\nSP: {spName}\n\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                throw;
            }
        }
    }
}
