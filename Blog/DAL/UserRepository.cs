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
                command.CommandText = "SELECT UserName FROM AspNetUsers WHERE Id = '" + id + "'";
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                UserModel user = new UserModel();
                user.UserName = reader.GetString(0);
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
    }
}