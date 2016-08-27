using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class CityBL
    {
        public static DataSet GetAllCities()
        {
            string sqlQuery = "select * from City";
            DataSet ds = new DataSet();
            ds = DatabaseBroker.GetDataSet(sqlQuery);
            return ds;
        }
    }
}
