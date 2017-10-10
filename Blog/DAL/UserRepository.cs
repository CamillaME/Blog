using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class UserRepository
    {
        public UserModel GetUser(string id)
        {
            UserModel result = new UserModel();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Email, UserName, UserDescription, UserPicturePath, UserAge FROM AspNetUsers WHERE Id = '" + id + "'";
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                UserModel user = new UserModel();
                user.UserID = reader.GetString(0);
                user.Email = reader.GetString(1);
                user.UserName = reader.GetString(2);
                user.Description = reader.GetString(3);
                user.PicturePath = reader.GetString(4);
                user.Age = reader.GetInt32(5);

                result = user;
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

        public void UpdateUser(UserModel user)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE AspNetUsers SET Email = '" + user.Email + "', UserDescription = '" + user.Description + "', UserPicturePath = '" + user.PicturePath + "', UserAge = " + user.Age + " WHERE Id = '" + user.UserID + "'";
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

        public void DeleteUser(string id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=LAPTOP-0BL0FE3D\\SQLEXPRESS;Database=Blog;Integrated Security=SSPI";

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM AspNetUsers WHERE Id = '" + id + "'";
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
    }
}