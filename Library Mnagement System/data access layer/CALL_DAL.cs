using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Library_Mnagement_System.data_access_layer
{
    class CALL_DAL   //call data access layer
    {
        SqlConnection con = new SqlConnection();
        public CALL_DAL()
        {
            //con.ConnectionString = "";
            con = new SqlConnection(@"Data Source=DESKTOP-6N1SK7T\ZKARIA2019;Initial Catalog=LMS;Integrated Security=True");
        }
       // method to open sqlcon
       public void open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        //method to close sqlcon
        public void close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        } 
        //fun to read data
        public DataTable read(string store , SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //excute edite,delete,insert
        public void excute(string store , SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
