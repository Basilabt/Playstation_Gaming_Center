using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsReservationDataAccess
    {
        public static bool logReservation(int adminID , string customerName , DateTime reservationDate , DateTime startTime , DateTime endTime , double playedHours , double paidAmount)
        {
            int numberOfAffectedRows = 0;

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["Database_Connection_String"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string cmd = "SP_LogReservation";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AdminID", adminID);
                        command.Parameters.AddWithValue("@CustomerName", customerName);
                        command.Parameters.AddWithValue("@ReservationDate", reservationDate);
                        command.Parameters.AddWithValue("@StartTime", startTime.TimeOfDay);
                        command.Parameters.AddWithValue("@EndTime", endTime.TimeOfDay);
                        command.Parameters.AddWithValue("@PlayedHours", playedHours);
                        command.Parameters.AddWithValue("@PaidAmmount", paidAmount);

                        numberOfAffectedRows = command.ExecuteNonQuery();

                    }

                }


            }
            catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }




            return numberOfAffectedRows > 0;
        }

        public static DataTable getAllReservations()
        {
            DataTable dataTable = new DataTable();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Database_Connection_String"].ConnectionString;

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection .Open();

                    string cmd = "SP_GetAllReservations";
                    using(SqlCommand command = new SqlCommand(cmd,connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }

                        }

                    }

                }


            } catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }


            return dataTable;
        }



    }
}
