using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using DataManagementSystem.Models;
using System.Text;
using System.IO;
using DataManagementSystem.Controllers;

namespace DataManagementSystem.PersonRepository
{
    public class personRepo
    {
        private SqlConnection connect;

        // Constructor for creating a connection to the database
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MVC_task"].ToString();
            connect = new SqlConnection(connectionString);
        }

        // Method for adding a person to the database
        public bool AddPerson(personModel smodel)
        {
            Connection(); // Create a database connection
            using (SqlConnection connection = new SqlConnection(connect.ConnectionString))
            {
                connection.Open(); // Open the connection
                using (SqlCommand cmd = new SqlCommand("SP_addPerson", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Set parameters for the stored procedure
                    cmd.Parameters.AddWithValue("@SurName", smodel.SurName);
                    cmd.Parameters.AddWithValue("@Email", smodel.Email);
                    cmd.Parameters.AddWithValue("@Contact", smodel.Contact);
                    cmd.Parameters.AddWithValue("@City", smodel.City);
                    cmd.Parameters.AddWithValue("@Picture", smodel.Picture);

                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the stored procedure
                    connection.Close(); // Close the connection

                    return rowsAffected >= 1; // Return true if one or more rows were affected
                }
            }
        }

        // Method for updating a person's information in the database
        public bool UpdatePerson(personModel smodel)
        {
            try
            {
                Connection(); // Create a database connection
                using (SqlConnection connection = new SqlConnection(connect.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_updatePerson", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Set parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@personID", smodel.PersonID);
                        cmd.Parameters.AddWithValue("@SurName", smodel.SurName);
                        cmd.Parameters.AddWithValue("@Email", smodel.Email);
                        cmd.Parameters.AddWithValue("@Contact", smodel.Contact);
                        cmd.Parameters.AddWithValue("@City", smodel.City);
                        cmd.Parameters.AddWithValue("@Picture", smodel.Picture);

                        connection.Open(); // Open the connection
                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute the stored procedure
                        connection.Close(); // Close the connection

                        return rowsAffected >= 1; // Return true if one or more rows were affected
                    }
                }
            }
            catch (Exception)
            {
                return false; // Return false if an exception is caught
            }
        }

        // Method for viewing a list of persons from the database
        public List<personModel> ViewPerson()
        {
            Connection(); // Create a database connection
            using (SqlConnection connection = new SqlConnection(connect.ConnectionString))
            {
                connection.Open(); // Open the connection
                List<personModel> personlist = new List<personModel>();

                SqlCommand cmd = new SqlCommand("SP_ViewPerson", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt); // Fill a DataTable with the results of the stored procedure
                connection.Close(); // Close the connection

                foreach (DataRow dr in dt.Rows)
                {
                    // Create personModel objects and add them to the list
                    personlist.Add(
                        new personModel
                        {
                            PersonID = Convert.ToInt32(dr["PersonID"]),
                            SurName = Convert.ToString(dr["Surname"]),
                            Email = Convert.ToString(dr["Email"]),
                            City = Convert.ToString(dr["City"]),
                            Contact = Convert.ToString(dr["Contact"]),
                            Picture = (byte[])dr["Picture"]
                        });
                }
                return personlist; // Return the list of persons
            }
        }

        // Method for viewing a specific person by ID
        public List<personModel> ViewPerso(int id)
        {
            Connection(); // Create a database connection
            using (SqlConnection connection = new SqlConnection(connect.ConnectionString))
            {
                connection.Open(); // Open the connection
                List<personModel> personlist = new List<personModel>();

                SqlCommand cmd = new SqlCommand("SP_ViewPerson", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt); // Fill a DataTable with the results of the stored procedure
                connection.Close(); // Close the connection

                foreach (DataRow dr in dt.Rows)
                {
                    // Create personModel objects and add them to the list
                    personlist.Add(
                        new personModel
                        {
                            PersonID = Convert.ToInt32(dr["PersonID"]),
                            SurName = Convert.ToString(dr["Surname"]),
                            Email = Convert.ToString(dr["Email"]),
                            City = Convert.ToString(dr["City"]),
                            Contact = Convert.ToString(dr["Contact"]),
                            Picture = (byte[])dr["Picture"]
                        });
                }
                return personlist; // Return the list of persons
            }
        }

        // Method for deleting a person from the database by ID
        public int DeletePerson(int id)
        {
            Connection(); // Create a database connection
            using (SqlConnection connection = new SqlConnection(connect.ConnectionString))
            {
                connection.Open(); // Open the connection
                using (SqlCommand cmd = new SqlCommand("SP_DeletePerson", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@personID", id); // Set the parameter for the stored procedure
                    int i = cmd.ExecuteNonQuery(); // Execute the stored procedure
                    connection.Close(); // Close the connection
                    return i; // Return the number of rows affected
                }
            }
        }
    }
}
