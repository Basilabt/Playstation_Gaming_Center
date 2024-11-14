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
    public class clsAdminDataAccess
    {

       public static bool login(string username, string password)
        {
            bool isSucceed = false;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Database_Connection_String"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string cmd = "SP_Login";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                isSucceed = true;
                            }

                        }

                    }

                }


            }
            catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }


            return isSucceed;
        }

       public static bool getAdminByUsernameAndPassword(string username, string password , ref int adminID , ref int personID)
        {
            bool isFound = false;

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["Database_Connection_String"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetAdminByUsernameAndPassword";
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                adminID = (int)reader["AdminID"];
                                personID = (int)reader["PersonID"];
                            }

                        }

                    }

                }


            } catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }



            return isFound;
        }


       public static bool getAdminByAdminID(int adminID , ref int personID , ref string username , ref string password)
        {
            bool isFound = false;

            try
            {
                string connecionString = ConfigurationManager.ConnectionStrings["Database_Connection_String"].ConnectionString;

                using(SqlConnection connection = new SqlConnection(connecionString))
                {
                    connection.Open();

                    string cmd = "SP_GetAdminByAdminID";
                    using(SqlCommand command = new SqlCommand(cmd,connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            if(reader.Read())
                            {
                                isFound = true;

                                personID = (int)reader["PersonID"];
                                username = (string)reader["Username"];
                                password = (string)reader["Password"];

                            }


                        }

                    }

                }


            } catch (Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }


            return isFound;
        }

    }
}
