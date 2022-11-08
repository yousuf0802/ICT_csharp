using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MetalappsAutomation  
{
    public class DBHandler  
    {
        
        public SqlConnection GetConnection()
        {
            string con = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(con);

            return sqlConnection;
        }
    }
}