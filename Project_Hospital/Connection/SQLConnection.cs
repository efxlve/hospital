using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project_Hospital
{
    internal class SQLConnection
    {
        public SqlConnection connect()
        {
            SqlConnection connection = new SqlConnection("Data Source=SERVERNAME;Initial Catalog=ProjectHospital;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
