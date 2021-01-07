using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSys
{
    class DbConnection
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=OSAMA-IDEAPAD\SQLEXPRESS;Initial Catalog=UniManagement;Integrated Security=True;");
        public SqlCommand cmd = new SqlCommand();

        public DbConnection()
        { }

        public void Inserts(string query)
        {
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable Select(string query)
        {
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
    
}
