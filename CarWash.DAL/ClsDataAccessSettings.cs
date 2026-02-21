using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.DAL
{
    public class ClsDataAccessSettings
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["CarWashConnectionString"].ConnectionString;
    }
}
