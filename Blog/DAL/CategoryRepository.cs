using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class CategoryRepository
    {
        public void CreateCategory(CategoryModel category)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Categories (CategoryName, CategoryDescription) VALUES ('" + category.Name + "', '" + category.Description + "')";
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

        public void UpdateCategory(CategoryModel category)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Categories SET CategoryName = '" + category.Name + "', CategoryDescription = '" + category.Description + "' WHERE CategoryID = " + category.Id;
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

        public void DeleteCategory(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Categories WHERE CategoryID = " + id;
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

        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> result = new List<CategoryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT CategoryID, CategoryName, CategoryDescription FROM Categories";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CategoryModel category = new CategoryModel();
                    category.Id = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.Description = reader.GetString(2);
                    result.Add(category);
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

        public CategoryModel GetCategory(int id)
        {
            CategoryModel result = new CategoryModel();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT CategoryID, CategoryName, CategoryDescription FROM Categories WHERE CategoryID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                CategoryModel category = new CategoryModel();
                category.Id = reader.GetInt32(0);
                category.Name = reader.GetString(1);
                category.Description = reader.GetString(2);
                result = category;
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