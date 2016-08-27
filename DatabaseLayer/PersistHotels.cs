using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClassLibrary;
using System.Data.SqlClient;
using DatabaseLayer;
using ModelsClassLibrary;

namespace DatabaseLayer
{
   public  class PersistHotels
    {
        public static bool SaveHotels(Hotel htl)
        {
            bool returnValue = false;
            try
            {
                string connectionString = DatabaseBroker.GetConnection;
                SqlConnection conn = new SqlConnection(connectionString);
                String sqlQueryToSaveHotels = String.Empty;
                SqlCommand command = new SqlCommand();
                conn.Open();
                command.Connection = conn;

                sqlQueryToSaveHotels = @"INSERT INTO Hotels 
                               (
	                                Name ,
	                                ContactPersonName  ,
	                                Rating ,
	                                AddressLine1  ,
	                                AddressLine2 ,
	                                City ,
	                                State ,
	                                Pin ,
	                                EmailAddress1 ,
	                                EmailAddress2 ,
	                                HotelType ,
	                                PhoneNumber1 ,
	                                PhoneNumber2 
                                ) 
                               VALUES
                               (
	                                @Name ,
	                                @ContactPersonName  ,
	                                @Rating ,
	                                @AddressLine1  ,
	                                @AddressLine2 ,
	                                @City ,
	                                @State ,
	                                @Pin ,
	                                @EmailAddress1 ,
	                                @EmailAddress2 ,
	                                @HotelType ,
	                                @PhoneNumber1 ,
	                                @PhoneNumber2 
                               )";

                command.CommandText = sqlQueryToSaveHotels;
             
	            command.Parameters.AddWithValue("@Name" , htl.Name);
                command.Parameters.AddWithValue("@ContactPersonName", htl.ContactPersonName);
                command.Parameters.AddWithValue("@Rating", htl.Rating);
                command.Parameters.AddWithValue("@AddressLine1", htl.AddressLine1);
                command.Parameters.AddWithValue("@AddressLine2", htl.AddressLine2);
                command.Parameters.AddWithValue("@City", htl.City);
                command.Parameters.AddWithValue("@State", htl.State);
                command.Parameters.AddWithValue("@Pin", htl.Pin);
                command.Parameters.AddWithValue("@EmailAddress1", htl.EmailAddress1);
                command.Parameters.AddWithValue("@EmailAddress2", htl.EmailAddress2);
                command.Parameters.AddWithValue("@HotelType", htl.HotelType);
                command.Parameters.AddWithValue("@PhoneNumber1", htl.PhoneNumber1);
                command.Parameters.AddWithValue("@PhoneNumber2", htl.PhoneNumber2);
                command.ExecuteNonQuery();
                returnValue = true;
            }
            catch (Exception)
            {
                returnValue = false;
                throw;
            }
            return returnValue;
        }

        
        public static bool UpdateHotels(Hotel htl)
        {
            bool returnValue = false;
            try
            {
                string connectionString = DatabaseBroker.GetConnection;
                SqlConnection conn = new SqlConnection(connectionString);
                String sqlQueryToSaveHotels = String.Empty;
                SqlCommand command = new SqlCommand();
                conn.Open();
                command.Connection = conn;

                sqlQueryToSaveHotels = @"Update Hotels 
                                        set 
                                        Name = @Name ,
                                        ContactPersonName = @ContactPersonName   ,
                                        Rating = @Rating ,
                                        AddressLine1 = @AddressLine1   ,
                                        AddressLine2 =@AddressLine2 ,
                                        City = @City ,
                                        State =@State,
                                        Pin=@Pin ,
                                        EmailAddress1 =@EmailAddress1 ,
                                        EmailAddress2 = @EmailAddress2,
                                        HotelType =@HotelType ,
                                        PhoneNumber1=@PhoneNumber1 ,
                                        PhoneNumber2=@PhoneNumber2  where id="+htl.HotelId+"";

                command.CommandText = sqlQueryToSaveHotels;

                command.Parameters.AddWithValue("@Name", htl.Name);
                command.Parameters.AddWithValue("@ContactPersonName", htl.ContactPersonName);
                command.Parameters.AddWithValue("@Rating", htl.Rating);
                command.Parameters.AddWithValue("@AddressLine1", htl.AddressLine1);
                command.Parameters.AddWithValue("@AddressLine2", htl.AddressLine2);
                command.Parameters.AddWithValue("@City", htl.City);
                command.Parameters.AddWithValue("@State", htl.State);
                command.Parameters.AddWithValue("@Pin", htl.Pin);
                command.Parameters.AddWithValue("@EmailAddress1", htl.EmailAddress1);
                command.Parameters.AddWithValue("@EmailAddress2", htl.EmailAddress2);
                command.Parameters.AddWithValue("@HotelType", htl.HotelType);
                command.Parameters.AddWithValue("@PhoneNumber1", htl.PhoneNumber1);
                command.Parameters.AddWithValue("@PhoneNumber2", htl.PhoneNumber2);
                command.ExecuteNonQuery();

                command.ExecuteNonQuery();
                returnValue = true;
            }
            catch (Exception)
            {
                returnValue = false;
                throw;
            }
            return returnValue;
        }
    }
}
