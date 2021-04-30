using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BuiHaNhi_18110168_QLTiemSach_DMS.DBLayer
{
    class DBMain
    {
        //https://www.guru99.com/c-sharp-access-database.html
        //variable declaration
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        public DBMain(string ID, string Pass)
        {
            //Set Connection String DESKTOP-BK2VBF5\SQLEXPRESS hayyyyyyy .
            string ConnStr = "Data Source=(local);Initial Catalog=QLTiemSach_DMS;User ID=" + ID + ";Password=" + Pass;
            conn = new SqlConnection(ConnStr);//assign connection
            comm = conn.CreateCommand();
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
    }
}
