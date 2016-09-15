using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseLayer
{
    public class DatabaseBroker
    {
        public static string GetConnection 
        {
            get { return "Data Source=localhost;Initial Catalog=TravelWorldSolutions;Integrated Security=True"; }
        }
        public static DataSet GetDataSet(string sqlQuery)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, new SqlConnection(GetConnection));
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool Delete(string sqlQuery)
        {
            bool returnValue = false;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = sqlQuery;
                cmd.Connection = new SqlConnection(GetConnection);
                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected>0)
                {
                    returnValue = true;
                }
                return returnValue;
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
