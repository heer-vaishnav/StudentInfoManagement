using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace StudentInfoManagement.Domains
{
    public class BaseDomain
    {
        SqlConnection conn { get; set; }

        SqlCommand cmd { get; set; }

        public void getConnection()
        {
            conn = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=StudentInfo;Integrated Security=True");
            conn.Open();
        }

        public bool Add(string query)
        {
            cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                return true;
            else
                return false;
        }
        
        public SqlDataReader GetReader(string query)
        {
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
