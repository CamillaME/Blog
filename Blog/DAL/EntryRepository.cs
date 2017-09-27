using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class EntryRepository
    {
        public void CreateEntry(Entry entry)
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

        public void UpdateEntry(Entry entry)
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

        public Entry GetEntry(int id)
        {
            Entry result = new Entry();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryID, EntryTitle, EntryDate, EntryText, EntryIsPublished FROM Entries WHERE EntryID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Entry entry = new Entry();
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

        public List<Entry> GetAllEntries()
        {
            List<Entry> result = new List<Entry>();

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
                    Entry entry = new Entry();
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