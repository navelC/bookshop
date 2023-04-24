using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OnlineBookShop.Models
{
    public class Functions
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;
        public Functions()
        {
            ConStr = "Data Source=.;Initial Catalog=bookshop;Integrated Security=True";
            conn = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(string Query)
        {
            int cnt = 0;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();
            conn.Close();
            return cnt;
        }
    }
}