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
        public static bool SaveProposals(ProposalModel prpsl)
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
                                      listOfHotelIds ,
                                      PDFFilePath ,Persons_For_Deluxe_Rooms,Persons_For_Average_Rooms,Persons_For_Below_Average_Rooms
            
                                ) 
                               VALUES
                               (
	                                  @ClientName ,
                                      @NumberOfPersons ,
                                      @NumberOfRooms ,
                                      @FromDate ,
                                      @ToDate ,
                                      @listOfHotelIds ,
                                      @PDFFilePath,@Persons_For_Deluxe_Rooms,@Persons_For_Average_Rooms,@Persons_For_Below_Average_Rooms
                               )";

                var csvHotelIds = string.Join(",", prpsl.listOfHotelIds);
                                

                command.CommandText = sqlQueryToSaveProposals;

                command.Parameters.AddWithValue("@ClientName", prpsl.ClientName);
                command.Parameters.AddWithValue("@NumberOfPersons", prpsl.NumberOfPersons);
                command.Parameters.AddWithValue("@NumberOfRooms", prpsl.NumberOfPersons);
                command.Parameters.AddWithValue("@FromDate", prpsl.FromDate);
                command.Parameters.AddWithValue("@ToDate", prpsl.ToDate);
                command.Parameters.AddWithValue("@listOfHotelIds", csvHotelIds);
                command.Parameters.AddWithValue("@PDFFilePath", prpsl.PdfPath);

                command.Parameters.AddWithValue("@Persons_For_Average_Rooms", prpsl.Persons_For_Average_Rooms);
                command.Parameters.AddWithValue("@Persons_For_Deluxe_Rooms", prpsl.Persons_For_Deluxe_Rooms);
                command.Parameters.AddWithValue("@Persons_For_Below_Average_Rooms", prpsl.Persons_For_Below_Average_Rooms);

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


        public static bool UpdateProposals(ProposalModel prpsl)
        {

            bool returnValue = false;
            try
            {
                string connectionString = DatabaseBroker.GetConnection;
                SqlConnection conn = new SqlConnection(connectionString);
                String sqlQueryToUpdateProposals = String.Empty;
                SqlCommand command = new SqlCommand();
                conn.Open();
                command.Connection = conn;

                sqlQueryToUpdateProposals = @"update  Proposal set  
                                      ClientName = @ClientName  ,
                                      NumberOfPersons = @NumberOfPersons ,
                                      NumberOfRooms = @NumberOfRooms  ,
                                      FromDate = @FromDate ,
                                      ToDate =@ToDate where proposalid=@proposalid
                                      ";
                command.CommandText = sqlQueryToUpdateProposals;

                command.Parameters.AddWithValue("@ClientName", prpsl.ClientName);
                command.Parameters.AddWithValue("@NumberOfPersons", prpsl.NumberOfPersons);
                command.Parameters.AddWithValue("@NumberOfRooms", prpsl.NumberOfRooms);
                command.Parameters.AddWithValue("@FromDate", prpsl.FromDate);
                command.Parameters.AddWithValue("@ToDate", prpsl.ToDate);
                command.Parameters.AddWithValue("@proposalid", prpsl.ProposalId);
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
