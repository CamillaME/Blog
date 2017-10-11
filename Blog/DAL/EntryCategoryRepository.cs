using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class EntryCategoryRepository
    {
        public void CreateEntryCategory(EntryCategoryModel entryCategory)
        {
            SqlConnection connection = new SqlConnection();
            //https://www.connectionstrings.com/store-connection-string-in-webconfig/
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnection"].ConnectionString;
            connection.ConnectionString = connStr;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO EntryCategories (EntryID, CategoryID) VALUES (" + entryCategory.EntryID + ", " + entryCategory.CategoryID + ")";
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

        public void DeleteEntryCategory(int id)
        {
            SqlConnection connection = new SqlConnection();
            //https://www.connectionstrings.com/store-connection-string-in-webconfig/
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnection"].ConnectionString;
            connection.ConnectionString = connStr;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM EntryCategories WHERE EntryCategoryID = " + id;
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

        public EntryCategoryModel GetEntryCategory(int id)
        {
            EntryCategoryModel result = new EntryCategoryModel();

            SqlConnection connection = new SqlConnection();
            //https://www.connectionstrings.com/store-connection-string-in-webconfig/
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnection"].ConnectionString;
            connection.ConnectionString = connStr;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryCategoryID, EntryID, CategoryID FROM EntryCategories WHERE CategoryID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                EntryCategoryModel entryCategory = new EntryCategoryModel();
                entryCategory.EntryCategoryID = reader.GetInt32(0);
                entryCategory.EntryID = reader.GetInt32(1);
                entryCategory.CategoryID = reader.GetInt32(2);
                result = entryCategory;
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

        public EntryCategoryModel GetEntryCategory(int entryID, int categoryID)
        {
            EntryCategoryModel result = new EntryCategoryModel();

            SqlConnection connection = new SqlConnection();
            //https://www.connectionstrings.com/store-connection-string-in-webconfig/
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnection"].ConnectionString;
            connection.ConnectionString = connStr;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryCategoryID, EntryID, CategoryID FROM EntryCategories WHERE EntryID = " + entryID + " AND CategoryID = " + categoryID;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                EntryCategoryModel entryCategory = new EntryCategoryModel();
                entryCategory.EntryCategoryID = reader.GetInt32(0);
                entryCategory.EntryID = reader.GetInt32(1);
                entryCategory.CategoryID = reader.GetInt32(2);
                result = entryCategory;
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

        public EntryCategoryModel GetEntryCategoryByEntryID(int id)
        {
            EntryCategoryModel result = new EntryCategoryModel();

            SqlConnection connection = new SqlConnection();
            //https://www.connectionstrings.com/store-connection-string-in-webconfig/
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnection"].ConnectionString;
            connection.ConnectionString = connStr;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryCategoryID, EntryID, CategoryID FROM EntryCategories WHERE EntryID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                EntryCategoryModel entryCategory = new EntryCategoryModel();
                entryCategory.EntryCategoryID = reader.GetInt32(0);
                entryCategory.EntryID = reader.GetInt32(1);
                entryCategory.CategoryID = reader.GetInt32(2);
                result = entryCategory;
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

        public List<EntryCategoryModel> GetEntryCategories()
        {
            List<EntryCategoryModel> result = new List<EntryCategoryModel>();

            SqlConnection connection = new SqlConnection();
            //https://www.connectionstrings.com/store-connection-string-in-webconfig/
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnection"].ConnectionString;
            connection.ConnectionString = connStr;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryCategoryID, EntryID, CategoryID FROM EntryCategories";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EntryCategoryModel entryCategory = new EntryCategoryModel();
                    entryCategory.EntryCategoryID = reader.GetInt32(0);
                    entryCategory.EntryID = reader.GetInt32(1);
                    entryCategory.CategoryID = reader.GetInt32(2);
                    result.Add(entryCategory);
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

        public List<EntryCategoryModel> GetEntryCategories(int id)
        {
            List<EntryCategoryModel> result = new List<EntryCategoryModel>();

            SqlConnection connection = new SqlConnection();
            //https://www.connectionstrings.com/store-connection-string-in-webconfig/
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnection"].ConnectionString;
            connection.ConnectionString = connStr;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryCategoryID, EntryID, CategoryID FROM EntryCategories WHERE EntryID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EntryCategoryModel entryCategory = new EntryCategoryModel();
                    entryCategory.EntryCategoryID = reader.GetInt32(0);
                    entryCategory.EntryID = reader.GetInt32(1);
                    entryCategory.CategoryID = reader.GetInt32(2);
                    result.Add(entryCategory);
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

        public List<EntryCategoryModel> GetEntryCategories(int entryID, int categoryID)
        {
            List<EntryCategoryModel> result = new List<EntryCategoryModel>();

            SqlConnection connection = new SqlConnection();
            //https://www.connectionstrings.com/store-connection-string-in-webconfig/
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnection"].ConnectionString;
            connection.ConnectionString = connStr;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT EntryCategoryID, EntryID, CategoryID FROM EntryCategories WHERE EntryID = " + entryID + " AND CategoryID = " + categoryID;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EntryCategoryModel entryCategory = new EntryCategoryModel();
                    entryCategory.EntryCategoryID = reader.GetInt32(0);
                    entryCategory.EntryID = reader.GetInt32(1);
                    entryCategory.CategoryID = reader.GetInt32(2);
                    result.Add(entryCategory);
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