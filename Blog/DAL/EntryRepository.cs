﻿using Blog.Models;
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
            connection.ConnectionString = "Server=localhost;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                var sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                var isPublished = 1;

                if (entry.EntryIsPublished == true)
                {
                    isPublished = 1;
                }
                else if (entry.EntryIsPublished == false)
                {
                    isPublished = 0;
                }

                command.CommandText = "INSERT INTO Entries (EntryTitle, EntryDate, EntryText, EntryIsPublished) VALUES ('" + entry.EntryTitle + "', '" + sqlFormattedDate + "', '" + entry.EntryText + "', " + isPublished + ")";
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
            connection.ConnectionString = "Server=localhost;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                var sqlFormattedDate = entry.EntryDate.ToString("yyyy MM dd HH:mm");
                DateTime dt = sqlFormattedDate.
                var isPublished = 1;

                if (entry.EntryIsPublished == true)
                {
                    isPublished = 1;
                }
                else if (entry.EntryIsPublished == false)
                {
                    isPublished = 0;
                }

                command.CommandText = "UPDATE Entries SET EntryTitle = '" + entry.EntryTitle + "', EntryDate = '" + sqlFormattedDate + "', EntryText = '" + entry.EntryText + "', EntryIsPublished = " + isPublished + " WHERE EntryID = " + entry.EntryID;
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
            connection.ConnectionString = "Server=localhost;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Entries WHERE EntryID = " + id;
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

        public EntryModel GetEntry(int id)
        {
            EntryModel result = new EntryModel();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=localhost;Database=Blog;Integrated Security=SSPI";

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
            catch (Exception ex)
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
            connection.ConnectionString = "Server=localhost;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryID, EntryTitle, EntryDate, EntryText, EntryIsPublished FROM Entries";
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