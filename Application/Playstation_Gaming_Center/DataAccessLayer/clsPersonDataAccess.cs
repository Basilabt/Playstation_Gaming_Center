using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLayer
{
     public class clsPersonDataAccess
    {

        public static bool getPersonByPersonID(int personID , ref string firstName , ref string secondName , ref string thirdName , ref string lastName , ref bool gender , ref string phoneNumber , ref string email)
        {
            bool isFound = false;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Database_Connection_String"].ConnectionString;

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string cmd = "SP_GetPersonByPersonID";
                    using(SqlCommand command = new SqlCommand(cmd,connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if(reader.Read())
                            {
                                isFound = true;

                                firstName = (string)reader["FirstName"];
                                secondName = (string)reader["SecondName"];
                                thirdName = (string)reader["ThirdName"];
                                lastName = (string)reader["Lastname"];
                                gender = (bool)reader["Gender"];
                                phoneNumber = (string)reader["PhoneNumber"];
                                email = (string)reader["Email"];
                            }

                        }

                    }

                }


            } catch(Exception exception)
            {
                Console.WriteLine($"DEBUG: {exception.Message}");
            }


            return isFound;
        }


    }
}
