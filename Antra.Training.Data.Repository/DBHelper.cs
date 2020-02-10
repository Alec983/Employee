using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Antra.Training.Data.Repository
{
    class DBHelper
    {
        string ConnectionString
        {
            get
            {
                return "Data Source=.;Initial Catalog=jan2020;Integrated Security=True";
            }
        }

        public int ExecuteDMLStatements(string str, Dictionary<string, object> cmdParameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = str;
                if (cmdParameters != null)
                {
                    foreach (var item in cmdParameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                }
                cmd.Connection = con;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return 0;
        }

        public DataTable GetDataFromTable(string str, Dictionary<string, object> cmdParameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = str;
                if (cmdParameters != null)
                {
                    foreach (var item in cmdParameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                }
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            { }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return null;
        }
    }
}
