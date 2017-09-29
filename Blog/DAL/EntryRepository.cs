using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class EntryRepository
    {
        public void CreateEntry(EntryModel entry)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Entries EntryTitle, EntryDate, EntryText, EntryIsPublished VALUES ('" + entry.EntryTitle + "', " + entry.EntryDate + ", '" + entry.EntryText + "', " + entry.EntryIsPublished + ")";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateEntry(EntryModel entry)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Entries SET EntryTitle = " + entry.EntryTitle + ", EntryDate = " + entry.EntryDate + ", EntryText = " + entry.EntryText + ", EntryIsPublished = " + entry.EntryIsPublished + " WHERE EntryID = " + entry.EntryID;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteEntry(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Entries WHERE EntryID = " + id;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }

        public EntryModel GetEntry(int id)
        {
            EntryModel result = new EntryModel();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryID, EntryTitle, EntryDate, EntryText, EntryIsPublished FROM Entries WHERE EntryID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                EntryModel entry = new EntryModel();
                entry.EntryID = reader.GetInt32(0);
                entry.EntryTitle = reader.GetString(1);
                entry.EntryDate = reader.GetDateTime(2);
                entry.EntryText = reader.GetString(3);
                entry.EntryIsPublished = reader.GetBoolean(4);
                result = entry;
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public List<EntryModel> GetAllEntries()
        {
            List<EntryModel> result = new List<EntryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryID, EntryTitle, EntryDate, EntryText, EntryIsPublished FROM Entries WHERE EntryID = " + id;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EntryModel entry = new EntryModel();
                    entry.EntryID = reader.GetInt32(0);
                    entry.EntryTitle = reader.GetString(1);
                    entry.EntryDate = reader.GetDateTime(2);
                    entry.EntryText = reader.GetString(3);
                    entry.EntryIsPublished = reader.GetBoolean(4);
                    result.Add(entry);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}