using ModelsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
using System.Data;
namespace BusinessLayer
{
    public class HotelBL
    {
        public static bool Save(Hotel htl)
        {
            bool returnValue = false;
            try
            {
               returnValue= PersistHotels.SaveHotels(htl);
            }
            catch (Exception e)
            {
                returnValue = false;
                throw e;
            }
            finally
            {
            }
            return returnValue;
        }

        public static DataSet GetAllHotels()
        {
            string sqlQuery = "select * from Hotels";
            DataSet ds = new DataSet();
            ds = DatabaseBroker.GetDataSet(sqlQuery);
            return ds;
        }

        public static bool DeleteHotel(int id )
        {
            bool returnValue = false;
            string sqlQuery ="delete from hotels where id='"+id+"'" ;
            returnValue=DatabaseBroker.Delete(sqlQuery);
            return returnValue;
        }

        public static bool Update(Hotel htl)
        {
            bool returnValue = false;
            try
            {
                returnValue = PersistHotels.UpdateHotels(htl);
            }
            catch (Exception e)
            {
                returnValue = false;
                throw e;
            }
            finally
            {
            }
            return returnValue;
        }
    }
}
