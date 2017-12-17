using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDLayer;

namespace BDLayer
{
    public class DAL
    {
        string ConnStr = "Data Source=DESKTOP-0LGERSH;" +
           "Initial Catalog=NongSan;" +
           "Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        public DAL()
        {
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] p)
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
        public bool MyExecuteNonQuery(string strSQL, CommandType ct,
            ref string error, params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
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
        //public DataSet ExecuteQueryDataSetView(string strSQL, CommandType ct, params SqlParameter[] p)
        //{
        //    if (conn.State == ConnectionState.Open)
        //        conn.Close();
        //    conn.Open();
        //    comm = new SqlCommand(strSQL, conn);
        //    //comm.CommandType = ct;
        //    //comm.ExecuteReader();
        //    da = new SqlDataAdapter(comm);
        //    DataSet ds = new DataSet();
        //    //da.Fill(ds);
        //    ds.Tables[0].Load(comm.ExecuteReader());
        //    return ds;
        //}
    }
}

