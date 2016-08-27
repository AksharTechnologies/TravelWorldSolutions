using ModelsClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class PersistProposals
    {
        public static bool SaveProposals(Proposal prpsl)
        {

            bool returnValue = false;
            try
            {
                string connectionString = DatabaseBroker.GetConnection;
                SqlConnection conn = new SqlConnection(connectionString);
                String sqlQueryToSaveProposals = String.Empty;
                SqlCommand command = new SqlCommand();
                conn.Open();
                command.Connection = conn;

                sqlQueryToSaveProposals = @"INSERT INTO Proposal 
                               (
                                      ClientName ,
                                      NumberOfPersons ,
                                      NumberOfRooms ,
                                      FromDate ,
                                      ToDate ,
                                      listOfHotelIds 
                                ) 
                               VALUES
                               (
	                                  @ClientName ,
                                      @NumberOfPersons ,
                                      @NumberOfRooms ,
                                      @FromDate ,
                                      @ToDate ,
                                      @listOfHotelIds 
                               )";

                var csvHotelIds = string.Join(",", prpsl.listOfHotelIds);
                                

                command.CommandText = sqlQueryToSaveProposals;

                command.Parameters.AddWithValue("@ClientName", prpsl.ClientName);
                command.Parameters.AddWithValue("@NumberOfPersons", prpsl.NumberOfPersons);
                command.Parameters.AddWithValue("@NumberOfRooms", prpsl.NumberOfPersons);
                command.Parameters.AddWithValue("@FromDate", prpsl.FromDate);
                command.Parameters.AddWithValue("@ToDate", prpsl.ToDate);
                command.Parameters.AddWithValue("@listOfHotelIds", csvHotelIds);
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
