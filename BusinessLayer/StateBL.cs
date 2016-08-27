using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer
{
   public  class StateBL
    {
        public static DataSet GetAllStates()
        {
            string sqlQuery = "select * from States";
            DataSet ds = new DataSet();
            ds = DatabaseBroker.GetDataSet(sqlQuery);
            return ds;
        }
    }
}
