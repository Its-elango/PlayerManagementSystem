using DataManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Web;

namespace DataManagementSystem.PersonRepository
{
    public class credentialRepo
    {
        private SqlConnection connect;

        // Constructor for creating a database connection
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MVC_task"].ToString();
            connect = new SqlConnection(connectionString);
        }

        // Method for user sign-in validation
        public bool Signin(credentialModel smodel)
        {
            Connection(); // Create a database connection
            using (SqlConnection connection = new SqlConnection(connect.ConnectionString))
            {
                try
                {
                    connection.Open(); // Open the connection
                    using (SqlCommand cmd = new SqlCommand("SP_Validate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", smodel.Username);
                        cmd.Parameters.AddWithValue("@password", smodel.Password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // If there is a matching user
                            {
                                string dbUsername = reader["Username"].ToString();
                                string dbPassword = reader["Password"].ToString();

                                if (smodel.Username == dbUsername && smodel.Password == dbPassword)
                                {
                                    // Correct username and password
                                    return true;
                                }
                                else
                                {
                                    // Incorrect username or password
                                    return false;
                                }
                            }
                            else
                            {
                                // No matching user found
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
